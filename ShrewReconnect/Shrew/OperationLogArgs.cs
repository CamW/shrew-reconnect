using System;

namespace com.waldron.shrewReconnect.Shrew
{
    public class OperationLogArgs : EventArgs
    {
        public OperationLogArgs(string Message, ShrewConnectionStatus Status)
        {
            this.Message = Message;
            this.Status = Status;
        }
        public string Message { get; private set; }
        public ShrewConnectionStatus Status { get; private set; }
    }
}
