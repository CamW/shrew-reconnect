using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
