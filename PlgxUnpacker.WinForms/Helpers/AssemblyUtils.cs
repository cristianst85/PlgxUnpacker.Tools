using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace PlgxUnpacker.Helpers
{
    internal static class AssemblyUtils
    {
        internal static string GetApplicationPath()
        {
            return new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath;
        }

        internal static string GetApplicationDirPath()
        {
            return Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath);
        }

        internal static Version GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version;
        }

        internal static string GetProductVersion()
        {
            return FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
        }

        internal static string GetProductVersion(string assemblyName)
        {
            var attributes = Assembly.Load(assemblyName).GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false);
            return attributes.Length == 0 ? GetVersion(assemblyName).ToString() : ((AssemblyInformationalVersionAttribute)attributes[0]).InformationalVersion;
        }

        internal static Version GetVersion(string assemblyName)
        {
            return Assembly.Load(assemblyName).GetName().Version;
        }

        internal static Assembly AssemblyResolver(object sender, ResolveEventArgs args)
        {
            string resourceName = args.Name.EndsWith(".dll") ? args.Name : new AssemblyName(args.Name).Name + ".dll";
            string resource = Array.Find(Assembly.GetExecutingAssembly().GetManifestResourceNames(), element => element.EndsWith(resourceName));

            if (resource != null)
            {
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    byte[] assemblyData = new byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            }

            return null;
        }
    }
}
