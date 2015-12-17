using com.waldron.shrewReconnect.Shrew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.waldron.shrewReconnect.Util
{
    public class UpdateAvailableArgs : EventArgs
    {
        public UpdateAvailableArgs(Version NewVersion)
        {
            this.Version = NewVersion;
        }
        public Version Version { get; private set; }
    }
}
