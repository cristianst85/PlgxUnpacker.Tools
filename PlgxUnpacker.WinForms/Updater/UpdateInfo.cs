using System;

namespace PlgxUnpacker.Updater
{
    public class UpdateInfo
    {
        public Version Version { get; set; }

        public string DownloadPage { get; set; }

        public string DownloadUrl { get; set; }

        public bool IsNewVersionAvailable(Version currentVersion)
        {
            return Version.CompareTo(GetVersionWithoutRevision(currentVersion)) == 1;
        }

        public bool IsCurrentVersionNewer(Version currentVersion)
        {
            return Version.CompareTo(GetVersionWithoutRevision(currentVersion)) == -1;
        }

        private Version GetVersionWithoutRevision(Version version)
        {
            return new Version(version.Major, version.Minor, version.Build);
        }
    }
}
