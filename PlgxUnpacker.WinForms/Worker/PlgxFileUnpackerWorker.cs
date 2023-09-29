using PlgxUnpacker.Extensions;
using PlgxUnpacker.Worker.EventArguments;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using PlgxFile = PlgxUnpackerNet.PlgxFile;

namespace PlgxUnpacker.Worker
{
    public class PlgxFileUnpackerWorker : IDisposable
    {
        public delegate void PlgxFileEntryUnpackedEventHandler(object sender, PlgxFileEntryUnpackedEventArgs e);
        public delegate void PlgxFileUnpackingErrorEventHandler(object sender, PlgxFileUnpackingErrorEventArgs e);
        public delegate void PlgxFileUnpackingCompletedEventHandler(object sender, EventArgs e);
        public delegate void PlgxFileUnpackingCancelledEventHandler(object sender, EventArgs e);

        public delegate FileOverwritePromptResult RemoteFileOverwritePromptCallback(object sender, string fileName);

        public event PlgxFileEntryUnpackedEventHandler PlgxFileEntryUnpacked;
        public event PlgxFileUnpackingErrorEventHandler PlgxFileUnpackingError;
        public event PlgxFileUnpackingCompletedEventHandler PlgxFileUnpackingCompleted;
        public event PlgxFileUnpackingCompletedEventHandler PlgxFileUnpackingCancelled;

        public RemoteFileOverwritePromptCallback FileOverwritePromptCallback { get; set; }

        private readonly PlgxFile plgxFile;
        private readonly PlgxFileUnpackOptions plgxFileUnpackOptions;

        private volatile bool isRunning;
        private Task task;

        public CancellationTokenSource CancellationSource { get; private set; }

        public PlgxFileUnpackerWorker(PlgxFile plgxFile, PlgxFileUnpackOptions plgxFileUnpackOptions)
        {
            this.plgxFile = plgxFile;
            this.plgxFileUnpackOptions = plgxFileUnpackOptions;
            this.CancellationSource = new CancellationTokenSource();
        }

        public bool IsRunning()
        {
            return isRunning;
        }

        public Task Run()
        {
            if (isRunning)
            {
                return task;
            }

            task = Task.Factory.StartNew(() =>
            {
                isRunning = true;

                try
                {
                    var filesTotalCount = plgxFile.Info.FileNames.Count;
                    var filesProcessedCount = 0;

                    FileOverwritePromptResult? fileOverwritePromptResult = null;

                    foreach (var plgxFileEntry in plgxFile.GetUnpackedFiles())
                    {
                        if (CancellationSource.IsCancellationRequested)
                        {
                            break;
                        };

                        var filePath = Path.Combine(plgxFileUnpackOptions.DirectoryPath, plgxFileEntry.Name);
                        var directoryPath = Path.GetDirectoryName(filePath);

                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        if (fileOverwritePromptResult.IsNullOrUnknown() && File.Exists(filePath))
                        {
                            fileOverwritePromptResult = FileOverwritePromptCallback?.Invoke(this, plgxFileEntry.Name);
                            
                            if (fileOverwritePromptResult == FileOverwritePromptResult.Cancel)
                            {
                                CancellationSource.Cancel();
                                break;
                            }
                        }

                        if (fileOverwritePromptResult.IsNullOrUnknown() || fileOverwritePromptResult.IsYesOrYesAll())
                        {
                            File.WriteAllBytes(filePath, plgxFileEntry.Content);
                        }

                        if (fileOverwritePromptResult.IsYesOrNo())
                        {
                            fileOverwritePromptResult = FileOverwritePromptResult.Unknown;
                        }

                        OnPlgxFileEntryUnpacked(plgxFileEntry.Name, ++filesProcessedCount, filesTotalCount);
                    }
                }
                catch (Exception exception)
                {
                    OnFileUnpackingError(exception);
                }
                finally
                {
                    if (CancellationSource.Token.IsCancellationRequested)
                    {
                        OnCancelled();
                    }
                    else
                    {
                        OnCompleted();
                    }

                    isRunning = false;
                }
            }, CancellationSource.Token);

            return task;
        }

        protected virtual void OnPlgxFileEntryUnpacked(string fileEntryName, int filesProcessedCount, int filesProcessedTotal)
        {
            PlgxFileEntryUnpacked?.Invoke(this, new PlgxFileEntryUnpackedEventArgs(fileEntryName, filesProcessedCount, filesProcessedTotal));
        }

        protected virtual void OnFileUnpackingError(Exception exception)
        {
            PlgxFileUnpackingError?.Invoke(this, new PlgxFileUnpackingErrorEventArgs(exception));
        }

        protected virtual void OnCompleted()
        {
            PlgxFileUnpackingCompleted?.Invoke(this, new EventArgs());
        }

        protected virtual void OnCancelled()
        {
            PlgxFileUnpackingCancelled?.Invoke(this, new EventArgs());
        }

        public void Dispose()
        {
            if (task != null)
            {
                task.Dispose();
            }
        }
    }
}
