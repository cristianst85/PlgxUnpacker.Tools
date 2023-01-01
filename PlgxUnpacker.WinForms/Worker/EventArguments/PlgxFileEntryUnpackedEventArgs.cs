using System;

namespace PlgxUnpacker.Worker.EventArguments
{
    public class PlgxFileEntryUnpackedEventArgs : EventArgs
    {
        public string FileEntryName { get; private set; }

        public int FilesProcessedCount { get; private set; }

        public int FilesTotalCount { get; private set; }

        public PlgxFileEntryUnpackedEventArgs(string fileEntryName, int filesProcessed, int filesTotalCount)
        {
            this.FileEntryName = fileEntryName;
            this.FilesProcessedCount = filesProcessed;
            this.FilesTotalCount = filesTotalCount;
        }
    }
}
