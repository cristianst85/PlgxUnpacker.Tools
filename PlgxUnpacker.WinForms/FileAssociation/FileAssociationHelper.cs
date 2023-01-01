namespace PlgxUnpacker.FileAssociation
{
    internal static class FileAssociationHelper
    {
        internal static bool IsExtensionRegistered(string applicationName, string extension)
        {
            var programId = string.Format("{0}.{1}", applicationName, extension.TrimStart('.').ToUpper());
            var programAssociationInfo = new ProgramAssociationInfo(programId);
            var fileAssociationInfo = new FileAssociationInfo(extension.ToLower());

            return fileAssociationInfo.Exists() && fileAssociationInfo.IsFor(programId) && programAssociationInfo.Exists();
        }

        internal static void RegisterExtension(string applicationName, string applicationPath, string extension)
        {
            var programId = string.Format("{0}.{1}", applicationName, extension.TrimStart('.').ToUpper());

            var fileAssociationInfo = new FileAssociationInfo(extension.ToLower());

            if (fileAssociationInfo.Exists())
            {
                fileAssociationInfo.Delete();
            }

            fileAssociationInfo.Create(programId);

            var programAssociationInfo = new ProgramAssociationInfo(fileAssociationInfo.GetProgramId());

            if (programAssociationInfo.Exists())
            {
                programAssociationInfo.Delete();
            }

            programAssociationInfo.Create(
                string.Format("{0} File", extension.TrimStart('.').ToUpper()),
                new ProgramVerbCommand("Open", string.Format(@"{0} ""%1""", applicationPath))
            );
        }

        internal static void UnregisterExtension(string applicationName, string extension)
        {
            var programId = string.Format("{0}.{1}", applicationName, extension.TrimStart('.').ToUpper());

            var fileAssociationInfo = new FileAssociationInfo(extension.ToLower());

            if (fileAssociationInfo.Exists() && fileAssociationInfo.IsFor(programId))
            {
                fileAssociationInfo.Delete();
            }

            var programAssociationInfo = new ProgramAssociationInfo(programId);

            if (programAssociationInfo.Exists())
            {
                programAssociationInfo.Delete();
            }
        }
    }
}
