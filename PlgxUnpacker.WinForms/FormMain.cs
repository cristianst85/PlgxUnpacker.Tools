using PlgxUnpacker.Controls;
using PlgxUnpacker.Extensions;
using PlgxUnpacker.Helpers;
using PlgxUnpacker.Worker;
using PlgxUnpacker.Worker.EventArguments;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using PlgxFile = PlgxUnpackerNet.PlgxFile;

namespace PlgxUnpacker
{
    public partial class FormMain : Form
    {
        private PlgxFileUnpackerWorker plgxFileUnpackerWorker;
        private PlgxFile plgxFile;

        private volatile bool IsReady;
        private volatile bool IsClosing;

        public FormMain(PlgxFileUnpackOptions plgxFileUnpackOptions)
        {
            try
            {
                InitializeComponent();

                // Fix status strip right padding.
                statusStrip.Padding = new Padding(3, this.statusStrip.Padding.Top, 3, this.statusStrip.Padding.Bottom);
                statusStrip.Renderer = new StatusStripRenderer();

                // Add handlers.
                DragDrop += new DragEventHandler(FormMain_DragDrop);
                DragEnter += new DragEventHandler(FormMain_DragEnter);

                var version = AssemblyUtils.GetVersion();
                Text = Text.Replace("{version}", version.ToString(3));
                UpdateStatusStrip(Properties.Resources.DragAndDropToUnpack);

                // Handle command line arguments.
                if (plgxFileUnpackOptions.FilePath != null)
                {
                    var startupThread = new Thread(new ParameterizedThreadStart(ProcessFileDelayed))
                    {
                        Name = "processFileDelayed"
                    };

                    startupThread.Start(plgxFileUnpackOptions);
                }
                else
                {
                    buttonUnpack.Enabled = false;
                }
            }
            finally
            {
                IsReady = true;
            }
        }

        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (IsFileWorkerRunning())
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var filePaths = ((string[])e.Data.GetData(DataFormats.FileDrop));

                // Only one file can be unpacked at a time.
                if (filePaths.Length != 1)
                {
                    return;
                }

                // Drag & Drop effect when a file is dragged over the UI.
                e.Effect = File.Exists(filePaths[0]) ? DragDropEffects.Copy : DragDropEffects.None;
            }
        }

        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            var filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (filePaths.Length > 0)
            {
                var plgxFileUnpackOptions = new PlgxFileUnpackOptions()
                {
                    FilePath = filePaths[0]
                };

                ProcessFile(plgxFileUnpackOptions);
            }
        }

        private void ProcessFileDelayed(object parameter)
        {
            if (!(parameter is PlgxFileUnpackOptions plgxFileUnpackOptions))
            {
                return;
            }

            while (!IsReady)
            {
                Thread.Sleep(100);
            }

            ProcessFile(plgxFileUnpackOptions);
        }

        private void ProcessFile(PlgxFileUnpackOptions plgxFileUnpackOptions)
        {
            if (IsFileWorkerRunning())
            {
                return;
            }

            // Reset UI controls.
            ResetControls();

            try
            {
                // Force get the full path instead of a short path.
                var filePath = Path.GetFullPath(plgxFileUnpackOptions.FilePath);
                var fileExtension = Path.GetExtension(filePath);

                if (!PlgxFileHelper.IsPlgxFileExtension(fileExtension))
                {
                    throw new Exception(Properties.Resources.PlgxFileInvalid);
                }

                plgxFile = PlgxFile.LoadFromFile(filePath);

                this.InvokeIfRequired(() =>
                {
                    textBoxPluginName.Text = plgxFile.Info.PluginName;
                    textBoxCreationDate.Text = plgxFile.Info.PluginCreationDateTime.ToString("o");
                    textBoxToolName.Text = plgxFile.Info.PluginCreationToolName;
                });

                if (plgxFileUnpackOptions.DirectoryPath != null)
                {

                    ToggleControls(enabled: false);
                    UnpackFileAsync(plgxFileUnpackOptions);
                    ToggleUnpackButtonText(enabled: true);
                }
                else
                {
                    ToggleControls(enabled: true);
                    UpdateStatusStrip(Properties.Resources.PressUnpackButtonToUnpack);
                }
            }
            catch (Exception exception)
            {
                this.InvokeIfRequired(() =>
                {
                    MessageBox.Show(this, exception.Message, Properties.Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UpdateStatusStrip(Properties.Resources.DragAndDropToUnpack);
                });
            }
        }

        private async void UnpackFileAsync(PlgxFileUnpackOptions plgxFileUnpackOptions)
        {
            if (IsFileWorkerRunning())
            {
                return;
            }

            if (plgxFileUnpackerWorker != null)
            {
                plgxFileUnpackerWorker.PlgxFileEntryUnpacked -= PlgxFileUnpackerProcessor_PlgxFileEntryUnpacked;
                plgxFileUnpackerWorker.PlgxFileUnpackingError -= PlgxFileUnpackerProcessor_PlgxFileUnpackingError;
                plgxFileUnpackerWorker.PlgxFileUnpackingCompleted -= PlgxFileUnpackerProcessor_PlgxFileUnpackingCompleted;
                plgxFileUnpackerWorker.PlgxFileUnpackingCancelled -= PlgxFileUnpackerProcessor_PlgxFileUnpackingCancelled;
                plgxFileUnpackerWorker.FileOverwritePromptCallback -= PlgxFileUnpackerProcessor_FileOverwritePromptCallback;

                plgxFileUnpackerWorker = null;
            }

            plgxFileUnpackerWorker = new PlgxFileUnpackerWorker(plgxFile, plgxFileUnpackOptions);

            plgxFileUnpackerWorker.PlgxFileEntryUnpacked += PlgxFileUnpackerProcessor_PlgxFileEntryUnpacked;
            plgxFileUnpackerWorker.PlgxFileUnpackingError += PlgxFileUnpackerProcessor_PlgxFileUnpackingError;
            plgxFileUnpackerWorker.PlgxFileUnpackingCompleted += PlgxFileUnpackerProcessor_PlgxFileUnpackingCompleted;
            plgxFileUnpackerWorker.PlgxFileUnpackingCancelled += PlgxFileUnpackerProcessor_PlgxFileUnpackingCancelled;
            plgxFileUnpackerWorker.FileOverwritePromptCallback += PlgxFileUnpackerProcessor_FileOverwritePromptCallback;

            await plgxFileUnpackerWorker.Run();
        }

        private void PlgxFileUnpackerProcessor_PlgxFileEntryUnpacked(object sender, PlgxFileEntryUnpackedEventArgs e)
        {
            progressBar.InvokeIfRequired(() =>
            {
                progressBar.Maximum = e.FilesTotalCount;
                progressBar.Value = e.FilesProcessedCount;
                UpdateStatusStrip($"Unpacking file {e.FilesProcessedCount} of {e.FilesTotalCount} ({e.FileEntryName})");
            });
        }

        private void PlgxFileUnpackerProcessor_PlgxFileUnpackingError(object sender, PlgxFileUnpackingErrorEventArgs e)
        {
            this.InvokeIfRequired(() =>
            {
                MessageBox.Show(this, $"{Properties.Resources.Error}: {e.Exception.Message}", Properties.Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatusStrip(Properties.Resources.UnpackingFailed);
            });
        }

        private void PlgxFileUnpackerProcessor_PlgxFileUnpackingCompleted(object sender, EventArgs e)
        {
            this.InvokeIfRequired(() =>
            {
                ToggleControls(enabled: true);
                UpdateStatusStrip(Properties.Resources.UnpackingCompleted);
                ToggleUnpackButtonText(enabled: true);
            });
        }

        private void PlgxFileUnpackerProcessor_PlgxFileUnpackingCancelled(object sender, EventArgs e)
        {
            this.InvokeIfRequired(() =>
            {
                ToggleControls(enabled: true);
                UpdateStatusStrip(Properties.Resources.UnpackingInterrupted);
                ToggleUnpackButtonText(enabled: true);
            });
        }

        private FileOverwritePromptResult PlgxFileUnpackerProcessor_FileOverwritePromptCallback(object sender, string fileName)
        {
            using (var formConfirmFileOverwrite = new FormConfirmFileOverwrite(fileName))
            {
                this.InvokeIfRequired(() =>
                {
                    formConfirmFileOverwrite.ShowDialog(this);
                });

                return formConfirmFileOverwrite.FileOverwritePromptResult;
            }
        }

        private bool IsFileWorkerRunning()
        {
            return plgxFileUnpackerWorker != null && plgxFileUnpackerWorker.IsRunning();
        }

        private void StopFileWorker()
        {
            if (plgxFileUnpackerWorker != null)
            {
                plgxFileUnpackerWorker.CancellationSource.Cancel();
            }
        }

        private void ResetControls()
        {
            this.InvokeIfRequired(() =>
            {
                textBoxPluginName.Text = string.Empty;
                textBoxCreationDate.Text = string.Empty;
                textBoxToolName.Text = string.Empty;
                progressBar.Value = 0;
                progressBar.Maximum = 0;
                buttonUnpack.Enabled = false;
            });
        }

        private void ToggleControls(bool enabled)
        {
            this.InvokeIfRequired(() =>
            {
                buttonUnpack.Enabled = enabled;
                openToolStripMenuItem.Enabled = enabled;
            });
        }

        private void ToggleUnpackButtonText(bool enabled)
        {
            this.InvokeIfRequired(() =>
            {
                buttonUnpack.Enabled = enabled;
                buttonUnpack.ToggleText();
            });
        }

        private void UpdateStatusStrip(string text)
        {
            if (!IsClosing)
            {
                statusStrip.InvokeIfRequired(() =>
                {
                    toolStripStatusLabel.Text = text;
                    statusStrip.Update();
                });
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseApplication();
        }

        private void CloseApplication()
        {
            IsClosing = true;
            Close();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = false;
                openFileDialog.FileName = string.Empty;
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.Title = Properties.Resources.OpenPlgxFile;
                openFileDialog.Filter = "*.plgx|*.plgx";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog.FileName.Length > 0)
                    {
                        if (PlgxFileHelper.IsPlgxFileExtension(Path.GetExtension(openFileDialog.FileName)))
                        {
                            var plgxFileUnpackOptions = new PlgxFileUnpackOptions()
                            {
                                FilePath = openFileDialog.FileName
                            };

                            ProcessFile(plgxFileUnpackOptions);
                        }
                        else
                        {
                            MessageBox.Show(this, Properties.Resources.PlgxFileInvalid, Properties.Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var formOptions = new FormOptions())
            {
                formOptions.ShowDialog(this);
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var formAbout = new FormAbout())
            {
                formAbout.Text = formAbout.Text.Replace("{title}", Application.ProductName);
                formAbout.Update();

                formAbout.ShowDialog(this);
            }
        }

        private void ButtonUnpack_Click(object sender, EventArgs e)
        {
            buttonUnpack.Enabled = false;

            if (buttonUnpack.Text == Properties.Resources.Cancel)
            {
                if (IsFileWorkerRunning())
                {
                    StopFileWorker();
                    return;
                }
            }

            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.ShowNewFolderButton = true;
                folderBrowserDialog.Description = Properties.Resources.SelectDirectoryToUnpack;

                var plgxFileUnpackOptions = new PlgxFileUnpackOptions()
                {
                    FilePath = plgxFile.Path
                };

                if (Directory.Exists(plgxFileUnpackOptions.DirectoryPath))
                {
                    folderBrowserDialog.SelectedPath = plgxFileUnpackOptions.DirectoryPath;
                }
                else if (plgxFileUnpackOptions.FilePath != null)
                {
                    var directoryPath = Path.GetDirectoryName(plgxFileUnpackOptions.FilePath);
                    folderBrowserDialog.SelectedPath = directoryPath;
                }

                var dialogResult = folderBrowserDialog.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    plgxFileUnpackOptions.DirectoryPath = folderBrowserDialog.SelectedPath;

                    ToggleControls(enabled: false);
                    UnpackFileAsync(plgxFileUnpackOptions);
                    ToggleUnpackButtonText(enabled: true);
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    buttonUnpack.Enabled = true;
                }
            }
        }
    }
}
