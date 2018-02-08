using com.waldron.shrewReconnect.Shrew;
using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;

namespace com.waldron.shrewReconnect
{
    public class ShrewConnection
    {
        private const int CONNECT_TIMEOUT_MS = 15000; //15 secs
        private const int MONITOR_INTERVAL_MS = 2000; //2 secs
        private const int RETRY_INTERVAL_MS = 60000; //1 min
        private const int WAIT_INTERVAL_MS = 1000; //1 sec

        private const string IKE_DAEMON_NAME = "ShrewSoft IKE Daemon";
        private const string IPSEC_DAEMON_NAME = "ShrewSoft IPSEC Daemon";

        private Thread primaryThread { get; set; }
        private Timer monitorTimer { get; set; }
        private int failedConnectAttempts { get; set; }
        private bool shuttingDown { get; set; }
        private ShrewClientService vpnClient { get; set; }
        private string networkHost { get; set; }

        public ShrewConnection(ShrewCredentials credentials)
        {
            vpnClient = new ShrewClientService(credentials);
            this.networkHost = GetShrewConfigLine("network-host", credentials.siteConfigPath);
            this.shuttingDown = false;
            this.failedConnectAttempts = 0;
        }

        public string GetShrewConfigLine(string configLine, string siteConfigPath)
        {
            string[] lines = System.IO.File.ReadAllLines($@"{Environment.GetEnvironmentVariable("LOCALAPPDATA")}\Shrew Soft VPN\sites\{siteConfigPath}");
            Char delimiter = ':';
            foreach (string line in lines)
            {
                String[] settings = line.Split(delimiter);
                if (settings[1] == configLine)
                {
                    return settings[2];
                }
            }
            throw new Exception();
        }

        public void Connect()
        {
            this.shuttingDown = false;
            this.primaryThread = new Thread(new ThreadStart(ConnectProcess));
            this.primaryThread.IsBackground = true;
            this.primaryThread.Start();
        }

        private void ConnectProcess()
        {
            try
            {
                this.failedConnectAttempts = 0;
                if (!DaemonUtils.checkDaemon(IKE_DAEMON_NAME)) return;
                if (!DaemonUtils.checkDaemon(IPSEC_DAEMON_NAME)) return;
                ShrewNotifier.Log("Starting connect attempts.", ShrewConnectionStatus.Pending);
                while (!this.ConnectAttempt() && !this.shuttingDown)
                {
                    ShrewNotifier.SetStatus(ShrewConnectionStatus.Disconnected);
                    failedConnectAttempts++;
                    if (this.failedConnectAttempts % 10 == 0)
                    {
                        ShrewNotifier.Log("Failed 10 connect attempts in a row, restarting daemons.", ShrewConnectionStatus.Pending);
                        DaemonUtils.ResartService(IKE_DAEMON_NAME);
                        DaemonUtils.ResartService(IPSEC_DAEMON_NAME);
                    }
                    ShrewNotifier.Log(string.Format("Connect attempt {0} failed!", failedConnectAttempts), ShrewConnectionStatus.Disconnected);
                }
                if (this.shuttingDown) return;
                ShrewNotifier.SetStatus(ShrewConnectionStatus.Connected);
                ShrewNotifier.Log("Connection established.", ShrewConnectionStatus.Connected);
                ShrewNotifier.Log("------------------------------------------------", ShrewConnectionStatus.Pending);
            }
            catch (Exception exc)
            {
                ShrewNotifier.SetStatus(ShrewConnectionStatus.Disconnected);
                ShrewNotifier.Log(string.Format("Error while trying to connect: {0}\r\n\r\n {1}", exc.Message, exc.StackTrace), ShrewConnectionStatus.Disconnected);
            }
        }

        private bool ConnectAttempt()
        {
            CleanUp();
            vpnClient.ExecuteClient();
            long startTimeTicks = DateTime.UtcNow.Ticks;
            ShrewNotifier.Log("Waiting for shrew connection...", ShrewConnectionStatus.Pending);
            while (DateTime.UtcNow.Ticks < startTimeTicks + (TimeSpan.TicksPerMillisecond * CONNECT_TIMEOUT_MS))
            {
                if (VerifyConnected())
                {
                    StartMonitorThread();
                    return true;
                }
                Thread.Sleep(WAIT_INTERVAL_MS);
            }
            return false;
        }

        private void StartMonitorThread()
        {
            if (this.monitorTimer != null)
            {
                this.monitorTimer.Dispose();
                this.monitorTimer = null;
            }
            this.monitorTimer = new Timer(RunMonitorProcess, null, MONITOR_INTERVAL_MS, MONITOR_INTERVAL_MS);
        }

        private void RunMonitorProcess(object state)
        {
            lock (this)
            {
                if (!VerifyConnected())
                {
                    ShrewNotifier.Log("Shrew connection lost!", ShrewConnectionStatus.Disconnected);
                    ShrewNotifier.SetStatus(ShrewConnectionStatus.Pending);
                    Connect();
                }
            }
        }

        private bool VerifyConnected()
        {
            NetworkInterface[] netInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();

            // try to verify connection using domain method
            foreach (NetworkInterface adapter in netInterfaces)
            {
                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                if (adapterProperties.DnsSuffix == this.networkHost)
                {
                    return true;
                }
                if (this.networkHost.Contains(adapterProperties.DnsSuffix) && (adapterProperties.DnsSuffix != ""))
                {
                    return true;
                }
            }

            NetworkInterface vpnInterface = netInterfaces.FirstOrDefault(x => x.Description.Equals("Shrew Soft Virtual Adapter"));
            if (vpnInterface != null)
            {
                return vpnInterface.OperationalStatus == OperationalStatus.Up;
            }
            return false;
        }

        private void CleanUp()
        {
            ShrewNotifier.Log("Destroying any pre-existing vpn clients.", ShrewConnectionStatus.Pending);
            if (this.monitorTimer != null)
            {
                this.monitorTimer.Dispose();
                this.monitorTimer = null;
            }
            vpnClient.KillAll();
        }

        public void Shutdown()
        {
            this.shuttingDown = true;
            ShrewNotifier.SetStatus(ShrewConnectionStatus.Pending);
            this.CleanUp();
        }

        public void ToggleShrewVisible()
        {
            vpnClient.ToggleShrewVisible();
        }

    }
}