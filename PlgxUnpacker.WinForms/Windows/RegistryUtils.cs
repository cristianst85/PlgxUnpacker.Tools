using Microsoft.Win32;

namespace PlgxUnpacker.Windows
{
    internal static class RegistryUtils
    {
        internal static string GetCurrentMajorVersionNumber()
        {
            using (var registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", false))
            {
                return registryKey.GetValue("CurrentMajorVersionNumber", string.Empty)?.ToString();
            }
        }
    }
}
