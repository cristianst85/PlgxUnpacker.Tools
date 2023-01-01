using System;

namespace PlgxUnpacker.FileAssociation
{
    public class ProgramVerbCommand
    {
        public string Verb { get; private set; }

        public string Command { get; private set; }

        public ProgramVerbCommand(string verb, string command)
        {
            if (verb == null)
            {
                throw new ArgumentNullException(nameof(verb));
            }

            if (verb == string.Empty)
            {
                throw new ArgumentException($"The parameter '{nameof(verb)}' cannot be an empty string.", nameof(verb));
            }

            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (command == string.Empty)
            {
                throw new ArgumentException($"The parameter '{nameof(command)}' cannot be an empty string.", nameof(command));
            }

            this.Verb = verb;
            this.Command = command;
        }
    }
}
