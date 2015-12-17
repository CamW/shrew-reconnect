using com.waldron.shrewReconnect.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.waldron.shrewReconnect.Shrew
{
    public static class ShrewNotifier
    {
        public static event OperationLoggedHandler OperationLogged;
        public delegate void OperationLoggedHandler(Object o, OperationLogArgs e);

        public static event ConnectionStatusChangedHandler ConnectionStatusChanged;
        public delegate void ConnectionStatusChangedHandler(Object o, ShrewConnectionStatusArgs e);

        private static DateTime lastLogDate = DateTime.Now.AddDays(-1);

        public static void ResetLog()
        {
            lastLogDate = DateTime.Now.AddDays(-1);
        }

        public static void Log(string message, ShrewConnectionStatus status)
        {
            if (OperationLogged != null)
            {
                if (lastLogDate.Date != DateTime.Now.Date)
                {
                    lastLogDate = DateTime.Now;
                    OperationLogged(null, new OperationLogArgs(string.Format("----------------------- {0} -----------------------\r\n", lastLogDate.ToString("yyyy-MM-dd")), ShrewConnectionStatus.Pending));
                }
                else
                {
                    lastLogDate = DateTime.Now;
                }
                OperationLogged(null, new OperationLogArgs(string.Format("{0}: {1}\r\n", lastLogDate.ToString("HH:mm:ss"), message), status));
            }
        }

        public static void SetStatus(ShrewConnectionStatus status)
        {
            if (ConnectionStatusChanged != null)
            {
                ConnectionStatusChanged(null, new ShrewConnectionStatusArgs(status));
            }
        }
    }
}
