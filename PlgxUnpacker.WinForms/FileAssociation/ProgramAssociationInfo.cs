using Microsoft.Win32;
using System;

namespace PlgxUnpacker.FileAssociation
{
    internal class ProgramAssociationInfo
    {
        public string ProgramId { get; private set; }
    
        public ProgramAssociationInfo(string programId)
        {
            if (programId == null)
            {
                throw new ArgumentNullException(nameof(programId));
            }
           
            if (programId == string.Empty)
            {
                throw new ArgumentException($"The parameter '{nameof(programId)}' cannot be an empty string.", nameof(programId));
            }

            this.ProgramId = programId;
        }

        public bool Exists()
        {
            using (var rootRegistryKey = Registry.ClassesRoot)
            {
                using (var programRegistryKey = rootRegistryKey.OpenSubKey(this.ProgramId))
                {
                    return programRegistryKey != null;
                }
            }
        }

        public ProgramVerbCommand Read(string programVerb)
        {
            using (var registryKey = Registry.ClassesRoot.OpenSubKey($"{ProgramId}\\shell\\{programVerb}\\command"))
            {
                if (registryKey == null)
                {
                    return null;
                }

                return new ProgramVerbCommand(programVerb, registryKey.GetValue(null).ToString());
            }
        }

        public void Create(string description, ProgramVerbCommand programVerbCommand)
        {
            if (description == null)
            {
                throw new ArgumentNullException(nameof(description));
            }

            if (description == string.Empty)
            {
                throw new ArgumentException($"The parameter '{nameof(description)}' cannot be an empty string.", nameof(description));
            }

            if (programVerbCommand == null)
            {
                throw new ArgumentNullException(nameof(programVerbCommand));
            }

            if (Exists())
            {
                Delete();
            }

            using (var rootRegistryKey = Registry.ClassesRoot)
            {
                rootRegistryKey.CreateSubKey(this.ProgramId);
            }

            SetDescription(description);
            SetProgramVerbCommand(programVerbCommand);

            ShellNativeMethods.ChangeNotify();
        }

        public void Delete()
        {
            using (var rootRegistryKey = Registry.ClassesRoot)
            {
                using (var programRegistryKey = rootRegistryKey.OpenSubKey(this.ProgramId))
                {
                    if (programRegistryKey != null)
                    {
                        rootRegistryKey.DeleteSubKeyTree(this.ProgramId);
                    }
                }
            }
        }

        private void SetDescription(string description)
        {
            using (var rootRegistryKey = Registry.ClassesRoot)
            {
                using (var programRegistryKey = rootRegistryKey.OpenSubKey(this.ProgramId, true))
                {
                    if (programRegistryKey != null)
                    {
                        programRegistryKey.SetValue(string.Empty, description);
                    }
                }
            }
        }

        private void SetProgramVerbCommand(ProgramVerbCommand programVerbCommand)
        {
            using (var rootRegistryKey = Registry.ClassesRoot)
            {
                using (var programRegistryKey = rootRegistryKey.OpenSubKey(this.ProgramId, true))
                {
                    var shellRegistryKey = programRegistryKey.OpenSubKey("shell", true);
                    
                    if (shellRegistryKey != null)
                    {
                        programRegistryKey.DeleteSubKey("shell");
                    }

                    shellRegistryKey = programRegistryKey.CreateSubKey("shell");

                    using (var verbRegistryKey = shellRegistryKey.CreateSubKey(programVerbCommand.Verb.ToLower()))
                    {
                        using (var commandRegistryKey = verbRegistryKey.CreateSubKey("command"))
                        {
                            commandRegistryKey.SetValue(string.Empty, programVerbCommand.Command, RegistryValueKind.ExpandString);
                        }
                    }

                    shellRegistryKey.Close();
                    shellRegistryKey.Dispose();
                }
            }
        }
    }
}
