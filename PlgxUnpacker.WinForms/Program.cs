using PlgxUnpacker.Configuration;
using PlgxUnpacker.Extensions;
using PlgxUnpacker.FileAssociation;
using PlgxUnpacker.Helpers;
using PlgxUnpacker.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using PlgxFile = PlgxUnpackerNet.PlgxFile;

namespace PlgxUnpacker
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyUtils.AssemblyResolver);
            InternalMain(args);
        }

        private static void InternalMain(string[] args)
        {
            if (!EnvironmentUtils.IsUnix())
            {
                if (EnvironmentUtils.IsAtLeastWindows10())
                {
                    NativeMethods.SetProcessDpiAwareness(NativeMethods.ProcessDpiAwareness.ProcessSystemDpiAware);
                }
                else if (EnvironmentUtils.IsAtLeastWindowsVista())
                {
                    NativeMethods.SetProcessDPIAware();
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var arguments = new List<string>(args);

            if (RegisterOptions.All.Intersect(arguments).Any())
            {
                try
                {
                    var options = RegisterOptions.ParseFromArguments(arguments);

                    // Check if the current application has elevated administrator permissions.
                    if (NativeMethods.IsUserAnAdmin())
                    {
                        Register(options);
                        Environment.Exit(0);
                    }

                    throw new Exception("Elevated administrator permissions are required to perform this operation.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", Settings.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
            else if (arguments.Contains("--openFile") || arguments.Contains("--unpackFileHere"))
            {
                if (arguments.Count == 2 && arguments[0] == "--openFile")
                {
                    var options = new PlgxFileUnpackOptions()
                    {
                        FilePath = arguments[1]
                    };

                    Application.Run(new FormMain(options));
                }
                else if (arguments.Count == 2 && arguments[0] == "--unpackFileHere")
                {
                    var filePath = arguments[1];
                    var fileName = Path.GetFileNameWithoutExtension(filePath);
                    var directoryPath = Path.GetDirectoryName(arguments[1]);

                    var options = new PlgxFileUnpackOptions()
                    {
                        FilePath = filePath,
                        DirectoryPath = Path.Combine(directoryPath, fileName)
                    };

                    Application.Run(new FormMain(options));
                }
            }
            else
            {
                var options = new PlgxFileUnpackOptions()
                {
                    FilePath = arguments.Count == 1 ? arguments[0] : null
                };

                Application.Run(new FormMain(options));
            }
        }

        internal static void Register(RegisterOptions options)
        {
            var applicationName = Settings.ApplicationName;
            var applicationPath = AssemblyUtils.GetApplicationPath();

            if (options.ShowOpenFileMenuEntry.IsTrue() || options.ShowUnpackFileHereMenuEntry.IsTrue())
            {
                ShellContextMenuHelper.CreateOrUpdateShellContextMenu(applicationName, applicationPath);

                if (options.ShowOpenFileMenuEntry.IsTrue())
                {
                    ShellContextMenuHelper.CreateOrUpdateShellContextMenuOpenFileCommand(applicationName, applicationPath);
                }
                else if (options.ShowOpenFileMenuEntry.IsFalse())
                {
                    ShellContextMenuHelper.DeleteShellContextMenuOpenFileCommand(applicationName);
                }

                if (options.ShowUnpackFileHereMenuEntry.IsTrue())
                {
                    ShellContextMenuHelper.CreateOrUpdateShellExtensionUnpackFileHereCommand(applicationName, applicationPath);
                }
                else if (options.ShowUnpackFileHereMenuEntry.IsFalse())
                {
                    ShellContextMenuHelper.DeleteShellContextMenuUnpackFileHereCommand(applicationName);
                }

                if (options.ShowIcon.IsTrue())
                {
                    ShellContextMenuHelper.CreateOrUpdateShellContextMenuIcon(applicationName, applicationPath);
                }
                else if (options.ShowIcon.IsFalse())
                {
                    ShellContextMenuHelper.DeleteShellContextMenuIcon(applicationName);
                }
            }

            if (options.ShowOpenFileMenuEntry.IsFalse() && options.ShowUnpackFileHereMenuEntry.IsFalse())
            {
                ShellContextMenuHelper.DeleteShellContextMenu(applicationName);
            }

            if (options.AssociateWithPlgxFiles.IsTrue())
            {
                FileAssociationHelper.RegisterExtension(applicationName, applicationPath, PlgxFile.Extension);
            }
            else if (options.AssociateWithPlgxFiles.IsFalse())
            {
                FileAssociationHelper.UnregisterExtension(applicationName, PlgxFile.Extension);
            }
        }
    }
}
