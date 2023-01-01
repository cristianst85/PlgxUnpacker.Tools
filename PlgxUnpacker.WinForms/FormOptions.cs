using PlgxUnpacker.Helpers;
using PlgxUnpacker.Configuration;
using PlgxUnpacker.FileAssociation;
using PlgxUnpacker.Windows;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

using PlgxFile = PlgxUnpackerNet.PlgxFile;

namespace PlgxUnpacker
{
    // This form does not have the standard buttons "OK", "Cancel", and "Apply" buttons,
    // but only "OK" and "Cancel" because elevated Administrator permissions may be required
    // to update the Windows registry configuration (due to UAC). When user presses the "OK"
    // button another process will be launched with elevated administrator permissions to 
    // update the settings into the registry.
    public partial class FormOptions : Form
    {
        public FormOptions()
        {
            InitializeComponent();

            // Read settings from the registry.
            checkBoxShowOpenFileMenuItem.Checked = ShellContextMenuHelper.IsShellContextMenuOpenFileCommandSet(Settings.ApplicationName);
            checkBoxShowUnpackFileHereMenuItem.Checked = ShellContextMenuHelper.IsShellContextMenuUnpackFileHereCommandSet(Settings.ApplicationName);
            checkBoxShowIcons.Checked = ShellContextMenuHelper.IsShellContextMenuIconSet(Settings.ApplicationName);
            checkBoxShowIcons.Enabled = false;

            checkBoxEnableWindowsShellIntegration.Checked = checkBoxShowOpenFileMenuItem.Checked || checkBoxShowUnpackFileHereMenuItem.Checked || checkBoxShowIcons.Checked;
            checkBoxAssociateWithPlgxFiles.Checked = FileAssociationHelper.IsExtensionRegistered(Settings.ApplicationName, PlgxFile.Extension);

            // Update UI controls state based on the current settings.
            // checkBoxShowIcons.Enabled = checkBoxEnableWindowsShellIntegration.Checked;
            checkBoxShowOpenFileMenuItem.Enabled = checkBoxEnableWindowsShellIntegration.Checked;
            checkBoxShowUnpackFileHereMenuItem.Enabled = checkBoxEnableWindowsShellIntegration.Checked;

            // Decorate the "OK" button with an UAC shield.
            if (EnvironmentUtils.IsAtLeastWindowsVista())
            {
                NativeMethods.SetButtonShield(buttonOK, true);
            }
            else
            {
                checkBoxShowIcons.Enabled = false;
            }

            // Add event handlers.
            checkBoxEnableWindowsShellIntegration.CheckedChanged += CheckBoxIntegrateIntoShell_CheckedChanged;
        }

        private void CheckBoxIntegrateIntoShell_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEnableWindowsShellIntegration.Checked)
            {
                checkBoxShowOpenFileMenuItem.Checked = ShellContextMenuHelper.IsShellContextMenuOpenFileCommandSet(Settings.ApplicationName);
                checkBoxShowUnpackFileHereMenuItem.Checked = ShellContextMenuHelper.IsShellContextMenuUnpackFileHereCommandSet(Settings.ApplicationName);
                checkBoxShowIcons.Checked = ShellContextMenuHelper.IsShellContextMenuIconSet(Settings.ApplicationName);
                checkBoxShowIcons.Enabled = false;

                checkBoxShowOpenFileMenuItem.Enabled = true;
                checkBoxShowUnpackFileHereMenuItem.Enabled = true;

                if (EnvironmentUtils.IsAtLeastWindowsVista())
                {
                    // checkBoxShowIcons.Enabled = true;
                }
            }
            else
            {
                checkBoxShowOpenFileMenuItem.Checked = false;
                checkBoxShowUnpackFileHereMenuItem.Checked = false;
                checkBoxShowIcons.Checked = false;
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            bool isProcessElevationCanceled = false;

            var options = new RegisterOptions
            {
                IntegrateIntoShell = checkBoxEnableWindowsShellIntegration.Checked,
                ShowOpenFileMenuEntry = checkBoxShowOpenFileMenuItem.Checked,
                ShowUnpackFileHereMenuEntry = checkBoxShowUnpackFileHereMenuItem.Checked,
                ShowIcons = checkBoxShowIcons.Checked,
                AssociateWithPlgxFiles = checkBoxAssociateWithPlgxFiles.Checked,
            };

            if (NativeMethods.IsUserAnAdmin())
            {
                Program.Register(options);
            }
            else
            {
                Process process = null;
                try
                {
                    process = new Process();
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.FileName = AssemblyUtils.GetApplicationPath();
                    process.StartInfo.Arguments = options.ToArguments();
                    process.StartInfo.Verb = "runas";
                    process.Start();
                    process.WaitForExit();
                }
                catch (Win32Exception ex)
                {
                    // ERROR_CANCELLED: "The operation was canceled by the user".
                    if (ex.NativeErrorCode == 1223)
                    {
                        isProcessElevationCanceled = true;
                    }
                    else
                    {
                        throw;
                    }
                }
                finally
                {
                    if (process != null)
                    {
                        process.Dispose();
                    }
                }
            }

            if (!isProcessElevationCanceled)
            {
                Close();
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
