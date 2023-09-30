using Microsoft.Win32;
using PlgxUnpacker.Extensions;

namespace PlgxUnpacker.Windows
{
    internal static class ShellContextMenuHelper
    {
        internal static bool IsShellContextMenuOpenFileCommandSet(string applicationName)
        {
            using (var registryKey = Registry.ClassesRoot.OpenSubKey(string.Format(@"*\shell\{0}\shell\1OpenFile\command", applicationName), false))
            {
                return registryKey != null;
            }
        }

        internal static bool IsShellContextMenuOpenFileCommandSetForApplicationPath(string applicationName, string applicationPath)
        {
            using (var registryKey = Registry.ClassesRoot.OpenSubKey(string.Format(@"*\shell\{0}\shell\1OpenFile\command", applicationName), false))
            {
                var commandValue = registryKey?.GetValue(null)?.ToString();
                return commandValue == string.Format(@"""{0}"" --openFile ""%1""", applicationPath);
            }
        }

        internal static void CreateOrUpdateShellContextMenuOpenFileCommand(string applicationName, string applicationPath, bool? setIcon)
        {
            var commandRegistryKey = Registry.ClassesRoot.OpenSubKey(string.Format(@"*\shell\{0}\shell\1OpenFile\command", applicationName), true);

            if (commandRegistryKey == null)
            {
                commandRegistryKey = Registry.ClassesRoot.CreateSubKey(string.Format(@"*\shell\{0}\shell\1OpenFile\command", applicationName));
            }

            commandRegistryKey.SetValue(null, string.Format(@"""{0}"" --openFile ""%1""", applicationPath));
            commandRegistryKey.Close();
            commandRegistryKey.Dispose();

            using (var registryKey = Registry.ClassesRoot.OpenSubKey(string.Format(@"*\shell\{0}\shell\1OpenFile", applicationName), true))
            {
                registryKey.SetValue("MUIVerb", "Open File...");

                if (setIcon.IsTrue())
                {
                    registryKey.SetValue("Icon", string.Format(@"""{0}"",0", applicationPath), RegistryValueKind.ExpandString);
                }
                else if (setIcon.IsFalse())
                {
                    registryKey.DeleteValue("Icon", false);
                }
            }
        }

        internal static void DeleteShellContextMenuOpenFileCommand(string applicationName)
        {
            using (var registryKey = Registry.ClassesRoot.OpenSubKey(string.Format(@"*\shell\{0}\shell\1OpenFile", applicationName), true))
            {
                if (registryKey != null)
                {
                    registryKey.DeleteValue("MUIVerb", false);
                    registryKey.DeleteValue("Icon", false);
                    registryKey.DeleteSubKey("command", false);
                    registryKey.Close();
                }
            }

            using (var registryKey = Registry.ClassesRoot.OpenSubKey(string.Format(@"*\shell\{0}\shell", applicationName), true))
            {
                if (registryKey != null)
                {
                    registryKey.DeleteSubKey("1OpenFile", false);
                    registryKey.Close();
                }
            }
        }

        internal static bool IsShellContextMenuUnpackFileHereCommandSet(string applicationName)
        {
            using (var registryKey = Registry.ClassesRoot.OpenSubKey(string.Format(@"*\shell\{0}\shell\2UnpackFileHere\command", applicationName), false))
            {
                return registryKey != null;
            }
        }

        internal static bool IsShellContextMenuUnpackFileHereCommandSetForApplicationPath(string applicationName, string applicationPath)
        {
            using (var registryKey = Registry.ClassesRoot.OpenSubKey(string.Format(@"*\shell\{0}\shell\2UnpackFileHere\command", applicationName), false))
            {
                var commandValue = registryKey?.GetValue(null)?.ToString();
                return commandValue == string.Format(@"""{0}"" --unpackFileHere ""%1""", applicationPath);
            }
        }

        internal static void CreateOrUpdateShellExtensionUnpackFileHereCommand(string applicationName, string applicationPath, bool? setIcon)
        {
            var commandRegistryKey = Registry.ClassesRoot.OpenSubKey(string.Format(@"*\shell\{0}\shell\2UnpackFileHere\command", applicationName), true);

            if (commandRegistryKey == null)
            {
                commandRegistryKey = Registry.ClassesRoot.CreateSubKey(string.Format(@"*\shell\{0}\shell\2UnpackFileHere\command", applicationName));
            }

            commandRegistryKey.SetValue(null, string.Format(@"""{0}"" --unpackFileHere ""%1""", applicationPath));
            commandRegistryKey.Close();
            commandRegistryKey.Dispose();

            using (var registryKey = Registry.ClassesRoot.OpenSubKey(string.Format(@"*\shell\{0}\shell\2UnpackFileHere", applicationName), true))
            {
                registryKey.SetValue("MUIVerb", "Unpack File Here");

                if (setIcon.IsTrue())
                {
                    registryKey.SetValue("Icon", string.Format(@"""{0}"",0", applicationPath), RegistryValueKind.ExpandString);
                }
                else if (setIcon.IsFalse())
                {
                    registryKey.DeleteValue("Icon", false);
                }
            }
        }

        internal static void DeleteShellContextMenuUnpackFileHereCommand(string applicationName)
        {
            using (var registryKey = Registry.ClassesRoot.OpenSubKey(string.Format(@"*\shell\{0}\shell\2UnpackFileHere", applicationName), true))
            {
                if (registryKey != null)
                {
                    registryKey.DeleteValue("MUIVerb", false);
                    registryKey.DeleteValue("Icon", false);
                    registryKey.DeleteSubKey("command", false);
                    registryKey.Close();
                }
            }

            using (var registryKey = Registry.ClassesRoot.OpenSubKey(string.Format(@"*\shell\{0}\shell", applicationName), true))
            {
                if (registryKey != null)
                {
                    registryKey.DeleteSubKey("2UnpackFileHere", false);
                    registryKey.Close();
                }
            }
        }

        internal static void CreateOrUpdateShellContextMenu(string applicationName, string applicationPath)
        {
            var registryKey = Registry.ClassesRoot.OpenSubKey(string.Format(@"*\shell\{0}\shell\", applicationName), true);

            if (registryKey == null)
            {
                registryKey = Registry.ClassesRoot.CreateSubKey(string.Format(@"*\shell\{0}\shell\", applicationName));
                registryKey.Close();
                registryKey.Dispose();
            }

            registryKey = Registry.ClassesRoot.OpenSubKey(string.Format(@"*\shell\{0}\", applicationName), true);

            registryKey.SetValue("MUIVerb", "PlgxUnpacker");
            registryKey.SetValue("ExtendedSubCommandsKey", string.Format(@"*\shell\{0}", applicationName));

            registryKey.Close();
            registryKey.Dispose();
        }

        internal static void DeleteShellContextMenu(string applicationName)
        {
            using (var registryKey = Registry.ClassesRoot.OpenSubKey(string.Format(@"*\shell\{0}", applicationName), true))
            {
                if (registryKey != null)
                {
                    Registry.ClassesRoot.DeleteSubKeyTree(string.Format(@"*\shell\{0}", applicationName));
                    registryKey.Close();
                }
            }
        }

        internal static bool IsShellContextMenuIconSet(string applicationName)
        {
            using (var registryKey = Registry.ClassesRoot.OpenSubKey(string.Format(@"*\shell\{0}", applicationName), false))
            {
                return (registryKey != null && registryKey.GetValue("Icon") != null);
            }
        }

        /// <summary>
        /// Adding a Shell icon is working only in Windows Vista or later, but not in Windows XP.
        /// </summary>
        /// <param name="applicationName"></param>
        /// <param name="applicationPath"></param>
        /// <param name="iconPath"></param>
        internal static void CreateOrUpdateShellContextMenuIcon(string applicationName, string applicationPath, string iconPath = null)
        {
            var registryKey = Registry.ClassesRoot.OpenSubKey(string.Format(@"*\shell\{0}", applicationName), true);

            if (registryKey == null)
            {
                registryKey = Registry.ClassesRoot.CreateSubKey(string.Format(@"*\shell\{0}", applicationName));
            }

            if (iconPath == null)
            {
                iconPath = applicationPath; // Use the icon embedded into the executable if no icon path was provided.
            }

            registryKey.SetValue("Icon", string.Format(@"""{0}"",0", iconPath), RegistryValueKind.ExpandString);
            registryKey.Close();
            registryKey.Dispose();
        }

        internal static void DeleteShellContextMenuIcon(string applicationName)
        {
            using (var registryKey = Registry.ClassesRoot.OpenSubKey(string.Format(@"*\shell\{0}", applicationName), true))
            {
                if (registryKey != null)
                {
                    registryKey.DeleteValue("Icon", false);
                    registryKey.Close();
                }
            }
        }
    }
}
