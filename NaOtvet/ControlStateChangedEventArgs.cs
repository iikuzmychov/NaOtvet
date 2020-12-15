using System;

namespace NaOtvet
{
    public class ControlStateChangedEventArgs : EventArgs
    {
        public bool IsMinimized { get; set; }

        public ControlStateChangedEventArgs(bool isMinimized)
        {
            IsMinimized = isMinimized;
        }
    }
}
