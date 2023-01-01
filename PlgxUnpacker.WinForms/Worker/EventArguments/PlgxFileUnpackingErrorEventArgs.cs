using System;

namespace PlgxUnpacker.Worker.EventArguments
{
    public class PlgxFileUnpackingErrorEventArgs : EventArgs
    {
        public Exception Exception { get; private set; }

        public PlgxFileUnpackingErrorEventArgs(Exception exception)
        {
            this.Exception = exception;
        }
    }
}
