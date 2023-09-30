using PlgxUnpacker.Configuration;
using PlgxUnpacker.Extensions;
using PlgxUnpacker.FileAssociation;
using PlgxUnpacker.Helpers;
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
            checkBoxAssociateWithPlgxFiles.Checked = FileAssociationHelper.IsExtensionRegistered(Settings.ApplicationName, PlgxFile.Extension);

            if (checkBoxShowOpenFileMenuItem.Checked)
            {
                checkBoxShowOpenFileMenuItem.CheckState =
                     ShellContextMenuHelper.IsShellContextMenuOpenFileCommandSetForApplicationPath(Settings.ApplicationName, AssemblyUtils.GetApplicationPath())
                        ? CheckState.Checked
                        : CheckState.Indeterminate;
            }

            if (checkBoxShowUnpackFileHereMenuItem.Checked)
            {
                checkBoxShowUnpackFileHereMenuItem.CheckState =
                     ShellContextMenuHelper.IsShellContextMenuUnpackFileHereCommandSetForApplicationPath(Settings.ApplicationName, AssemblyUtils.GetApplicationPath())
                        ? CheckState.Checked
                        : CheckState.Indeterminate;
            }

            if (checkBoxAssociateWithPlgxFiles.Checked)
            {
                checkBoxAssociateWithPlgxFiles.CheckState =
                    FileAssociationHelper.IsExtensionRegisteredForApplicationPath(Settings.ApplicationName, AssemblyUtils.GetApplicationPath(), PlgxFile.Extension)
                        ? CheckState.Checked
                        : CheckState.Indeterminate;
            }

            // Decorate the "OK" button with an UAC shield.
            if (EnvironmentUtils.IsAtLeastWindowsVista())
            {
                NativeMethods.SetButtonShield(buttonOK, true);
            }

            ToggleCheckBoxShowIcons();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            var options = new RegisterOptions
            {
                ShowOpenFileMenuEntry = checkBoxShowOpenFileMenuItem.CheckState.ToBool(),
                ShowUnpackFileHereMenuEntry = checkBoxShowUnpackFileHereMenuItem.CheckState.ToBool(),
                ShowIcon = checkBoxShowIcons.CheckState.ToBool(),
                AssociateWithPlgxFiles = checkBoxAssociateWithPlgxFiles.CheckState.ToBool(),
            };

            if (NativeMethods.IsUserAnAdmin())
            {
                Program.Register(options);
                Close();
                return;
            }

            RegisterOptionsWithElevatedProcess(options);
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RegisterOptionsWithElevatedProcess(RegisterOptions registerOptions)
        {
            bool isProcessElevationCanceled = false;

            Process process = null;
            try
            {
                process = new Process();
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.FileName = AssemblyUtils.GetApplicationPath();
                process.StartInfo.Arguments = registerOptions.ToArguments();
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

            if (!isProcessElevationCanceled)
            {
                Close();
            }
        }

        private void CheckBoxShowOpenFileMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            ToggleCheckBoxShowIcons();
            ToggleCheckBoxShowIconsChecked();
        }

        private void CheckBoxShowUnpackFileHereMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            ToggleCheckBoxShowIcons();
            ToggleCheckBoxShowIconsChecked();
        }

        private void ToggleCheckBoxShowIcons()
        {
            if (EnvironmentUtils.IsAtLeastWindowsVista())
            {
                checkBoxShowIcons.Enabled = checkBoxShowOpenFileMenuItem.IsChecked() || checkBoxShowUnpackFileHereMenuItem.IsChecked();
            }
            else
            {
                checkBoxShowIcons.Enabled = false;
                checkBoxShowIcons.Text = Properties.Resources.ShowIconsTextWindowsVistaOrLater;
            }
        }

        private void ToggleCheckBoxShowIconsChecked()
        {
            if (!checkBoxShowOpenFileMenuItem.Checked && !checkBoxShowUnpackFileHereMenuItem.Checked)
            {
                checkBoxShowIcons.Checked = false;
            }
        }
    }
}
