using System;

namespace NaOtvet
{
    public class OnErrorArgs : EventArgs
    {
        public Exception Exception { get; set; }

        public OnErrorArgs(Exception exception)
        {
            Exception = exception;
        }
    }
}
