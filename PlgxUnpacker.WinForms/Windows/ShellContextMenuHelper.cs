using Microsoft.Win32;

namespace PlgxUnpacker.Windows
{
    public static class ShellContextMenuHelper
    {
        public static bool IsShellContextMenuOpenFileCommandSet(string applicationName)
        {
            using (var registryKey = Registry.ClassesRoot.OpenSubKey(string.Format(@"*\shell\{0}\shell\1OpenFile\command", applicationName), false))
            {
                return registryKey != null;
            }
        }

        public static void CreateOrUpdateShellContextMenuOpenFileCommand(string applicationName, string applicationPath)
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
            }
        }

        public static void DeleteShellContextMenuOpenFileCommand(string applicationName)
        {
            using (var registryKey = Registry.ClassesRoot.OpenSubKey(string.Format(@"*\shell\{0}\shell\1OpenFile", applicationName), true))
            {
                if (registryKey != null)
                {
                    registryKey.DeleteValue("MUIVerb", false);
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

        public static bool IsShellContextMenuUnpackFileHereCommandSet(string applicationName)
        {
            using (var registryKey = Registry.ClassesRoot.OpenSubKey(string.Format(@"*\shell\{0}\shell\2UnpackFileHere\command", applicationName), false))
            {
                return registryKey != null;
            }
        }

        public static void CreateOrUpdateShellExtensionUnpackFileHereCommand(string applicationName, string applicationPath)
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
            }
        }

        public static void DeleteShellContextMenuUnpackFileHereCommand(string applicationName)
        {
            using (var registryKey = Registry.ClassesRoot.OpenSubKey(string.Format(@"*\shell\{0}\shell\2UnpackFileHere", applicationName), true))
            {
                if (registryKey != null)
                {
                    registryKey.DeleteValue("MUIVerb", false);
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

        public static void CreateOrUpdateShellContextMenu(string applicationName, string applicationPath)
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

        public static void DeleteShellContextMenu(string applicationName)
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

        public static bool IsShellContextMenuIconSet(string applicationName)
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
        public static void CreateOrUpdateShellContextMenuIcon(string applicationName, string applicationPath, string iconPath = null)
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

        public static void DeleteShellContextMenuIcon(string applicationName)
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
