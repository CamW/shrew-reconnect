using com.waldron.shrewReconnect.Shrew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace com.waldron.shrewReconnect
{
    internal static class DaemonUtils
    {

        private const int SERVICE_RESTART_TIMEOUT = 40000; //40 secs
        private const int SERVICE_START_TIMEOUT = 20000; //20 secs

        internal static bool checkDaemon(string daemonName)
        {
            ShrewNotifier.Log(string.Format("Checking daemon status: {0}", daemonName), ShrewConnectionStatus.Pending);

            ServiceController sc = new ServiceController(daemonName);

            try
            {
                var scName = sc.ServiceName;
            } catch (InvalidOperationException exc) {
                throw new InvalidOperationException(String.Format("Service \"{0}\" does not exist or is not available.", daemonName), exc);
            }

            switch (sc.Status)
            {
                case ServiceControllerStatus.Running:
                    ShrewNotifier.Log("    Running", ShrewConnectionStatus.Pending);
                    return true;
                case ServiceControllerStatus.Stopped:
                    ShrewNotifier.Log("    Stopped", ShrewConnectionStatus.Pending);
                    return StartService(daemonName);
                case ServiceControllerStatus.Paused:
                    ShrewNotifier.Log("    Paused, aborting vpn connect.", ShrewConnectionStatus.Disconnected);
                    return false;
                case ServiceControllerStatus.StopPending:
                    ShrewNotifier.Log("    Stopping, aborting vpn connect.", ShrewConnectionStatus.Disconnected);
                    return false;
                case ServiceControllerStatus.StartPending:
                    ShrewNotifier.Log("    Starting, aborting vpn connect.", ShrewConnectionStatus.Disconnected);
                    return false;
                default:
                    ShrewNotifier.Log("    Unknown state, aborting vpn connect.", ShrewConnectionStatus.Disconnected);
                    return false;
            }

        }

        internal static bool StartService(string daemonName)
        {
            ServiceController sc = new ServiceController(daemonName);
            ShrewNotifier.Log("    Starting daemon...", ShrewConnectionStatus.Pending);
            sc.Start();
            try
            {
                sc.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 0, 0, SERVICE_START_TIMEOUT));
            }
            catch (Exception)
            {
                ShrewNotifier.Log("    Unable to start daemon.", ShrewConnectionStatus.Disconnected);
                return false;
            }
            ShrewNotifier.Log("    Daemon running.", ShrewConnectionStatus.Pending);
            return true;
        }

        internal static bool ResartService(string daemonName)
        {
            ServiceController sc = new ServiceController(daemonName);

            ShrewNotifier.Log(string.Format("Restarting daemon: {0}", daemonName), ShrewConnectionStatus.Pending);
            sc.Refresh();
            Thread.Sleep(2000);
            sc.Refresh();
            try
            {
                sc.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 0, 0, SERVICE_RESTART_TIMEOUT));
            }
            catch (Exception)
            {
                ShrewNotifier.Log("    Unable to restart daemon.", ShrewConnectionStatus.Disconnected);
                return false;
            }
            ShrewNotifier.Log("    Daemon running.", ShrewConnectionStatus.Pending);
            return true;
        }
    }
}
