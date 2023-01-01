using Microsoft.Win32;
using System;

namespace PlgxUnpacker.FileAssociation
{
    public class FileAssociationInfo
    {
        public string Extension { get; private set; }

        public FileAssociationInfo(string extension)
        {
            if (extension == null)
            {
                throw new ArgumentNullException(nameof(extension));
            }

            if (extension == string.Empty)
            {
                throw new ArgumentException($"The parameter '{nameof(extension)}' cannot be an empty string.", nameof(extension));
            }

            if (!extension.StartsWith("."))
            {
                throw new ArgumentException($"The value '{extension}' for '{nameof(extension)}' parameter is not a valid extension. The extension value must start with a period.", nameof(extension));
            }

            this.Extension = extension.ToLowerInvariant();
        }

        internal bool Exists()
        {
            using (var rootRegistryKey = Registry.ClassesRoot)
            {
                using (var extensionRegistryKey = rootRegistryKey.OpenSubKey(this.Extension))
                {
                    return extensionRegistryKey != null;
                }
            }
        }

        public void Create(string programId)
        {
            if (Exists())
            {
                Delete();
            }

            using (var rootRegistryKey = Registry.ClassesRoot)
            {
                rootRegistryKey.CreateSubKey(this.Extension);
            }

            SetProgramId(programId);

            ShellNativeMethods.ChangeNotify();
        }

        public void Delete()
        {
            using (var rootRegistryKey = Registry.ClassesRoot)
            {
                using (var extensionRegistryKey = rootRegistryKey.OpenSubKey(this.Extension))
                {
                    if (extensionRegistryKey != null)
                    {
                        rootRegistryKey.DeleteSubKeyTree(this.Extension);
                    }
                }
            }
        }

        public bool IsFor(string programId)
        {
            if (programId == null)
            {
                return false;
            }

            return GetProgramId() == programId;
        }

        public string GetProgramId()
        {
            using (var rootRegistryKey = Registry.ClassesRoot)
            {
                using (var extensionRegistryKey = rootRegistryKey.OpenSubKey(this.Extension))
                {
                    if (extensionRegistryKey == null)
                    {
                        return null;
                    }

                    return extensionRegistryKey.GetValue(string.Empty)?.ToString();
                }
            }
        }

        private void SetProgramId(string programId)
        {
            using (var rootRegistryKey = Registry.ClassesRoot)
            {
                using (var programRegistryKey = rootRegistryKey.OpenSubKey(this.Extension, true))
                {
                    if (programRegistryKey != null)
                    {
                        programRegistryKey.SetValue(string.Empty, programId);
                    }
                }
            }
        }
    }
}