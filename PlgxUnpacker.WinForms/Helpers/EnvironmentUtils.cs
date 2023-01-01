using PlgxUnpacker.Windows;
using System;

namespace PlgxUnpacker.Helpers
{
    internal static class EnvironmentUtils
    {
        internal static bool IsUnix()
        {
            var platformId = Environment.OSVersion.Platform;

            return platformId == PlatformID.Unix || platformId == PlatformID.MacOSX || (int)platformId == 128;
        }

        internal static bool IsAtLeastWindowsVista()
        {
            return Environment.OSVersion.Version.Major >= 6;
        }

        internal static bool IsAtLeastWindows10()
        {
            if (int.TryParse(RegistryUtils.GetCurrentMajorVersionNumber(), out int majorVersionNumber))
            {
                return majorVersionNumber >= 10;
            }

            return false;
        }
    }
}
