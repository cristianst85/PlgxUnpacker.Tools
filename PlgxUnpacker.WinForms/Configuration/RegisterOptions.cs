using PlgxUnpacker.Extensions;
using System;
using System.Collections.Generic;

namespace PlgxUnpacker.Configuration
{
    public class RegisterOptions
    {
        public static IReadOnlyCollection<string> All = new List<string>()
        {
            RegisterShellOpenFile,
            UnRegisterShellOpenFile,
            RegisterShellUnpackFileHere,
            UnRegisterShellUnpackFileHere,
            RegisterIcon,
            UnRegisterIcon,
            RegisterExtension,
            UnRegisterExtension
        };

        private const string RegisterShellOpenFile = "--register-shell:openFile";
        private const string UnRegisterShellOpenFile = "--unregister-shell:openFile";

        private const string RegisterShellUnpackFileHere = "--register-shell:unpackFileHere";
        private const string UnRegisterShellUnpackFileHere = "--unregister-shell:unpackFileHere";

        private const string RegisterIcon = "--register-shell:icon";
        private const string UnRegisterIcon = "--unregister-shell:icon";

        private const string RegisterExtension = "--register-extension";
        private const string UnRegisterExtension = "--unregister-extension";

        public bool? ShowOpenFileMenuEntry { get; set; }

        public bool? ShowUnpackFileHereMenuEntry { get; set; }

        public bool? ShowIcon { get; set; }

        public bool? AssociateWithPlgxFiles { get; set; }

        public RegisterOptions()
        {
        }

        public static RegisterOptions ParseFromArguments(IList<string> arguments)
        {
            var options = new RegisterOptions();

            foreach (var argument in arguments)
            {
                if (argument.Equals(RegisterShellOpenFile))
                {
                    options.ShowOpenFileMenuEntry = true;
                }
                else if (argument.Equals(UnRegisterShellOpenFile))
                {
                    options.ShowOpenFileMenuEntry = false;
                }
                else if (argument.Equals(RegisterShellUnpackFileHere))
                {
                    options.ShowUnpackFileHereMenuEntry = true;
                }
                else if (argument.Equals(UnRegisterShellUnpackFileHere))
                {
                    options.ShowUnpackFileHereMenuEntry = false;
                }
                else if (argument.Equals(RegisterIcon))
                {
                    options.ShowIcon = true;
                }
                else if (argument.Equals(UnRegisterIcon))
                {
                    options.ShowIcon = false;
                }
                else if (argument.Equals(RegisterExtension))
                {
                    options.AssociateWithPlgxFiles = true;
                }
                else if (argument.Equals(UnRegisterExtension))
                {
                    options.AssociateWithPlgxFiles = false;
                }
                else
                {
                    throw new Exception($"Invalid '{argument}' argument.");
                }
            }

            return options;
        }

        public string ToArguments()
        {
            var options = new List<string>();

            if (ShowOpenFileMenuEntry.IsTrue())
            {
                options.Add(RegisterShellOpenFile);
            }
            else if (ShowOpenFileMenuEntry.IsFalse())
            {
                options.Add(UnRegisterShellOpenFile);
            }

            if (ShowUnpackFileHereMenuEntry.IsTrue())
            {
                options.Add(RegisterShellUnpackFileHere);
            }
            else if (ShowUnpackFileHereMenuEntry.IsFalse())
            {
                options.Add(UnRegisterShellUnpackFileHere);
            }

            if (ShowIcon.IsTrue())
            {
                options.Add(RegisterIcon);
            }
            else if (ShowIcon.IsFalse())
            {
                options.Add(UnRegisterIcon);
            }

            if (AssociateWithPlgxFiles.IsTrue())
            {
                options.Add(RegisterExtension);
            }
            else if (AssociateWithPlgxFiles.IsFalse())
            {
                options.Add(UnRegisterExtension);
            }

            return options.Join();
        }
    }
}
