using com.waldron.shrewReconnect.Shrew;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;

namespace com.waldron.shrewReconnect.Util
{
    public static class UpdateChecker
    {
        private static string VERSION_URL = "http://www.waldron.co.za/downloads/versions/ShrewReconnect?uid={0}";
        private static string DOWNLOAD_URL = "http://www.waldron.co.za/downloads/installers/ShrewReconnectLatest.msi";
        private static int UPDATE_CHECK_INTERVAL_MINS = 10080; //7 days
        private static Thread updateCheckThread;

        public static event UpdateAvailableHandler UpdateAvailable;
        public delegate void UpdateAvailableHandler(Object o, UpdateAvailableArgs e);

        public static void InitLatestDownload()
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(DOWNLOAD_URL);
            Process.Start(sInfo);
        }

        public static void CheckForUpdate() {
            updateCheckThread = new Thread(new ThreadStart(CompleteCheck));
            updateCheckThread.Start();
        }

        private static void CompleteCheck()
        {
            try
            {
                ShrewProperties properties = ShrewConfiguration.LoadProperties();
                if (properties == null)
                {
                    properties = new ShrewProperties();
                    properties.userId = Guid.NewGuid();
                    ShrewConfiguration.SaveProperties(properties);
                }
                if (properties.lastUpdateCheck != null && properties.lastUpdateCheck.AddMinutes(UPDATE_CHECK_INTERVAL_MINS) > DateTime.UtcNow)
                {
                    return;
                }
                //userID used to track active user count.
                WebRequest request = HttpWebRequest.Create(string.Format(VERSION_URL, properties.userId));
                WebResponse response = request.GetResponse();
                StreamReader rdr = new StreamReader(response.GetResponseStream());
                char[] buffer = new char[response.ContentLength];
                rdr.Read(buffer, 0, (Int32)response.ContentLength);
                Version latest = new Version(new String(buffer));
                Version local = Assembly.GetExecutingAssembly().GetName().Version;
                bool newVersionAvailable = latest.CompareTo(local) > 0;
                if (newVersionAvailable && UpdateAvailable != null)
                {
                    UpdateAvailable(null, new UpdateAvailableArgs(latest));
                }
                properties.lastUpdateCheck = DateTime.UtcNow;
                ShrewConfiguration.SaveProperties(properties);
            }
            catch (Exception exc)
            {
                //Eat all errors
            }
        }
        
    }
}
