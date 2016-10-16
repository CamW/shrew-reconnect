using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace com.waldron.shrewReconnect.Shrew
{
    internal class ShrewClientService
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Unicode)]
        private static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_HIDE = 0;
        private const int SW_RESTORE = 9;
        private const string SHREW_ARGS = "-r \"{0}\" -u {1} -p \"{2}\" -a";
        private const string SHREW_CAPTION = "VPN Connect - {0}";

        private IntPtr hwndShrew { get; set; }
        private bool shrewVisible { get; set; }
        private ShrewCredentials credentials { get; set; }

        internal ShrewClientService(ShrewCredentials credentials)
        {
            this.hwndShrew = IntPtr.Zero;
            this.shrewVisible = false;
            this.credentials = credentials;
        }
        internal void ExecuteClient()
        {
            string args = string.Format(SHREW_ARGS, 
                credentials.siteConfigPath, 
                credentials.username, 
                credentials.password);

            ProcessStartInfo psi = new ProcessStartInfo(@"C:\Program Files\ShrewSoft\VPN Client\ipsecc.exe", args);
            psi.UseShellExecute = true;
            Process clientProcess = new Process();
            clientProcess.StartInfo = psi;
            ShrewNotifier.Log("Starting new vpn client.", ShrewConnectionStatus.Pending);
            hwndShrew = IntPtr.Zero;
            clientProcess.Start();
            Thread.Sleep(1000);
            if (!this.shrewVisible)
            {
                HideShrew();
            }
        }

        internal void HideShrew()
        {
            if (hwndShrew == IntPtr.Zero)
            {
                hwndShrew = FindWindowByCaption(IntPtr.Zero, string.Format(SHREW_CAPTION, credentials.siteConfigPath));
            }
            ShowWindow(hwndShrew, SW_HIDE);
            shrewVisible = false;
        }

        internal void ShowShrew()
        {
            ShowWindow(hwndShrew, SW_RESTORE);
            shrewVisible = true;
        }

        internal void ToggleShrewVisible()
        {
            if (this.shrewVisible)
            {
                HideShrew();
            }
            else
            {
                ShowShrew();
            }
        }

        internal void KillAll() {
            foreach (var process in Process.GetProcessesByName("ipsecc"))
            {
                process.Kill();
            }
        }
    }
}
