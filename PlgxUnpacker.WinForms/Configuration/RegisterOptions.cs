using System;
using System.Collections.Generic;
using System.Text;

namespace PlgxUnpacker.Configuration
{
    public class RegisterOptions
    {
        private static readonly ICollection<string> validRegisterOptions = new List<string>() { "shell", "icons", "openFile", "unpackFileHere" };
        private static readonly ICollection<string> validExtensionsOptions = new List<string>() { "plgx" };

        public bool IntegrateIntoShell { get; set; }

        public bool ShowOpenFileMenuEntry { get; set; }

        public bool ShowUnpackFileHereMenuEntry { get; set; }

        public bool ShowIcons { get; set; }

        public bool AssociateWithPlgxFiles { get; set; }

        public RegisterOptions()
        {
        }

        public static RegisterOptions ParseFromArguments(IList<string> arguments)
        {
            var options = new RegisterOptions();

            if (arguments.Count == 1 && arguments[0].Equals("--unregister"))
            {
                return options;
            }
            else if (arguments.Count > 1 && arguments.Count % 2 == 0)
            {
                for (int i = 0; i < arguments.Count; i = i + 2)
                {
                    var arg = arguments[i];

                    if (arg.Equals("--register"))
                    {
                        string[] values = arguments[i + 1].Split('-');

                        foreach (var value in values)
                        {
                            if (validRegisterOptions.Contains(value))
                            {
                                if (value.Equals("shell"))
                                {
                                    options.IntegrateIntoShell = true;
                                }

                                if (value.Equals("openFile"))
                                {
                                    options.ShowOpenFileMenuEntry = true;
                                }

                                if (value.Equals("unpackFileHere"))
                                {
                                    options.ShowUnpackFileHereMenuEntry = true;
                                }

                                if (value.Equals("icons"))
                                {
                                    options.ShowIcons = true;
                                }

                            }
                            else
                            {
                                throw new Exception("Invalid value for --register option.");
                            }
                        }
                    }
                    else if (arg.Equals("--extensions"))
                    {
                        string[] values = arguments[i + 1].Split('-');

                        foreach (var value in values)
                        {
                            if (validExtensionsOptions.Contains(value))
                            {
                                if (value.Equals("plgx"))
                                {
                                    options.AssociateWithPlgxFiles = true;
                                }
                            }
                            else
                            {
                                throw new Exception("Invalid value for --extensions option.");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid options.");
                    }
                }
            }
            else
            {
                throw new Exception("Invalid number of options.");
            }
            return options;
        }


        public string ToArguments()
        {
            var command = new StringBuilder();

            if (this.IntegrateIntoShell)
            {
                command.Append("--register shell");

                if (this.ShowOpenFileMenuEntry)
                {
                    command.Append("-openFile");
                }

                if (this.ShowUnpackFileHereMenuEntry)
                {
                    command.Append("-unpackFileHere");
                }

                if (this.ShowIcons)
                {
                    command.Append("-icons");
                }
            }

            if (this.AssociateWithPlgxFiles)
            {
                if (command.Length > 0)
                {
                    command.Append(" ");
                }

                command.Append("--extensions ");

                if (this.AssociateWithPlgxFiles)
                {
                    command.Append("plgx");
                }
            }

            if (command.Length == 0)
            {
                command.Append("--unregister");
            }

            return command.ToString();
        }
    }
}
