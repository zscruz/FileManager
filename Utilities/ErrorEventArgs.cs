using System;

namespace Utilities
{
    public class ErrorEventArgs : EventArgs
    {
        public string Header { get; set; }

        public string Message { get; set; }
    }
}