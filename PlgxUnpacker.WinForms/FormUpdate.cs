using PlgxUnpacker.Commons.Formatting;
using PlgxUnpacker.Extensions;
using PlgxUnpacker.Helpers;
using PlgxUnpacker.Updater;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PlgxUnpacker
{
    public partial class FormUpdate : Form
    {
        private UpdateInfo updateInfo;

        public FormUpdate()
        {
            InitializeComponent();

            buttonCheck.Enabled = false;
            buttonGoToDownloadPage.Enabled = false;

            CheckForUpdatesAsync();
        }

        private void CheckForUpdatesAsync()
        {
            var checkForUpdatesThread = new Thread(new ThreadStart(delegate { CheckForUpdates(); }))
            {
                Name = "asyncCheckForUpdatesThread"
            };

            checkForUpdatesThread.Start();
        }

        private void CheckForUpdates()
        {
            UpdateStatusImage(Properties.Resources.information);
            UpdateStatusText("Checking for updates, please wait a few seconds...");
            UpdateButtonState(buttonCheck, false);
            UpdateButtonState(buttonGoToDownloadPage, false);

            try
            {
                updateInfo = new GitHubWebUpdater().Check(Configuration.Settings.UpdateUrl);
                var currentVersion = AssemblyUtils.GetVersion();

                if (updateInfo.IsNewVersionAvailable(currentVersion))
                {
                    UpdateStatusText($"A new version of PlgxUnpacker ({updateInfo.Version}) is available.");

                    if (updateInfo.DownloadPageUrl.IsNotNullOrEmpty())
                    {
                        UpdateButtonState(buttonGoToDownloadPage, true);
                    }

                    UpdateButtonState(buttonCheck, true);
                }
                else if (updateInfo.IsCurrentVersionNewer(currentVersion))
                {
                    UpdateStatusText("You are using a newer version of PlgxUnpacker.");
                }
                else
                {
                    UpdateStatusText("You are using the latest version of PlgxUnpacker.");
                }

                UpdateButtonText(buttonCheck, "&Check");
            }
            catch (Exception ex)
            {
                UpdateStatusImage(Properties.Resources.exclamation);
                UpdateStatusText($"An error occurred while checking for updates: {TextStyleFormatter.LowercaseFirst(ex.Message).TrimEnd('.')}.");
                UpdateButtonText(buttonCheck, "&Retry");
                UpdateButtonState(buttonCheck, true);
                UpdateButtonState(buttonGoToDownloadPage, false);
            }
        }

        private void UpdateStatusText(string text)
        {
            this.InvokeIfRequired(() =>
            {
                labelStatus.Text = text;
            });
        }

        private void UpdateButtonState(Button button, bool isEnabled)
        {
            this.InvokeIfRequired(() =>
            {
                button.Enabled = isEnabled;
            });
        }

        private void UpdateButtonText(Button button, string text)
        {
            this.InvokeIfRequired(() =>
            {
                button.Text = text;
            });
        }

        private void UpdateStatusImage(Image image)
        {
            pictureBoxStatus.Image = image;
        }

        private void ButtonCheck_Click(object sender, EventArgs e)
        {
            CheckForUpdatesAsync();
        }

        private void ButtonGoToDownloadPage_Click(object sender, EventArgs e)
        {
            if (updateInfo.DownloadPageUrl.IsNotNullOrEmpty())
            {
                Process.Start(updateInfo.DownloadPageUrl);
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}