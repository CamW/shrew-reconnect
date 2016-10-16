using System;

namespace com.waldron.shrewReconnect.Shrew
{
    public class ShrewConnectionStatusArgs : EventArgs
    {
        public ShrewConnectionStatusArgs(ShrewConnectionStatus status)
        {
            this.status = status;
        }

        public ShrewConnectionStatus status { get; private set; }
    }
}
