using com.waldron.shrewReconnect.Shrew;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;

namespace com.waldron.shrewReconnect.Util
{
    public static class UpdateChecker
    {
        private static string VERSION_URL = "https://www.waldron.co.za/downloads/versions/ShrewReconnect?uid={0}&ver={1}&arch={2}";
#if X64
        private static string DOWNLOAD_URL = "https://github.com/CamW/shrew-reconnect/raw/master/installers/ShrewReconnectLatest64.msi";
#endif
#if X86
        private static string DOWNLOAD_URL = "https://github.com/CamW/shrew-reconnect/raw/master/installers/ShrewReconnectLatest32.msi";
#endif

        private static long UPDATE_CHECK_INTERVAL_MILLIS = 604800000; //7 days
        private static Timer updateCheckTimer;

        public static event UpdateAvailableHandler UpdateAvailable;
        public delegate void UpdateAvailableHandler(Object sender, UpdateAvailableArgs e);

        public static void InitLatestDownload()
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(DOWNLOAD_URL);
            Process.Start(sInfo);
        }

        public static void CheckForUpdate() {
            ShrewProperties properties = ShrewConfiguration.LoadProperties();
            if (properties == null)
            {
                properties = new ShrewProperties();
                properties.userId = Guid.NewGuid();
                ShrewConfiguration.SaveProperties(properties);
            }
            long initalDelay = 0;
            if (properties.lastUpdateCheck != null)
            {
                initalDelay = (long)properties.lastUpdateCheck.AddMilliseconds(UPDATE_CHECK_INTERVAL_MILLIS)
                                                            .Subtract(DateTime.UtcNow).TotalMilliseconds;
                if (initalDelay < 0) initalDelay = 0;
            }

            updateCheckTimer = new Timer(UpdateChecker.PerformCheck, null, initalDelay, UPDATE_CHECK_INTERVAL_MILLIS);
        }

        private static void PerformCheck(Object stateInfo)
        {
            try
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                ShrewProperties properties = ShrewConfiguration.LoadProperties();

                Version localVersion = Assembly.GetExecutingAssembly().GetName().Version;                   

                //userID used to track active user count.
                WebRequest request = HttpWebRequest.Create(string.Format(VERSION_URL, properties.userId, localVersion.ToString(), getArch()));
                WebResponse response = request.GetResponse();
                StreamReader rdr = new StreamReader(response.GetResponseStream());
                char[] buffer = new char[response.ContentLength];
                rdr.Read(buffer, 0, (Int32)response.ContentLength);
                Version latestVersion = new Version(new String(buffer));
                bool newVersionAvailable = latestVersion.CompareTo(localVersion) > 0;
                if (newVersionAvailable && UpdateAvailable != null)
                {
                    UpdateAvailable(null, new UpdateAvailableArgs(latestVersion));
                }
                properties.lastUpdateCheck = DateTime.UtcNow;
                ShrewConfiguration.SaveProperties(properties);
            }
            catch (Exception exc)
            {
                //Eat all errors
            }
        }


        private static ProcessorArchitecture getArch() {
            var myAssemblyName = AssemblyName.GetAssemblyName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            return myAssemblyName.ProcessorArchitecture;
        }

}
}
