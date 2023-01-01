using PlgxUnpacker.Configuration;
using PlgxUnpacker.FileAssociation;
using PlgxUnpacker.Helpers;
using PlgxUnpacker.Windows;
using System;
using System.Collections.Generic;
using System.IO;
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

            if (arguments.Contains("--unregister") || arguments.Contains("--register") || arguments.Contains("--extensions"))
            {
                var options = RegisterOptions.ParseFromArguments(arguments);

                // Check if the current application has elevated administrator permissions.
                if (NativeMethods.IsUserAnAdmin())
                {
                    Register(options);
                }
                else
                {
                    throw new Exception("Elevated administrator permissions are required to perform this operation.");
                }

                return;
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
                else if  (arguments.Count == 2 && arguments[0] == "--unpackFileHere")
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

            if (options.IntegrateIntoShell)
            {
                if (options.ShowOpenFileMenuEntry || options.ShowUnpackFileHereMenuEntry)
                {
                    ShellContextMenuHelper.CreateOrUpdateShellContextMenu(applicationName, applicationPath);

                    if (options.ShowOpenFileMenuEntry)
                    {
                        ShellContextMenuHelper.CreateOrUpdateShellContextMenuOpenFileCommand(applicationName, applicationPath);
                    }
                    else
                    {
                        ShellContextMenuHelper.DeleteShellContextMenuOpenFileCommand(applicationName);
                    }

                    if (options.ShowUnpackFileHereMenuEntry)
                    {
                        ShellContextMenuHelper.CreateOrUpdateShellExtensionUnpackFileHereCommand(applicationName, applicationPath);
                    }
                    else
                    {
                        ShellContextMenuHelper.DeleteShellContextMenuUnpackFileHereCommand(applicationName);
                    }

                    if (options.ShowIcons)
                    {
                        ShellContextMenuHelper.CreateOrUpdateShellContextMenuIcon(applicationName, applicationPath);
                    }
                    else
                    {
                        ShellContextMenuHelper.DeleteShellContextMenuIcon(applicationName);
                    }
                }
                else
                {
                    ShellContextMenuHelper.DeleteShellContextMenu(applicationName);
                }
            }
            else
            {
                ShellContextMenuHelper.DeleteShellContextMenu(applicationName);
            }

            if (options.AssociateWithPlgxFiles)
            {
                FileAssociationHelper.RegisterExtension(applicationName, applicationPath, PlgxFile.Extension);
            }
            else
            {
                FileAssociationHelper.UnregisterExtension(applicationName, PlgxFile.Extension);
            }
        }
    }
}
