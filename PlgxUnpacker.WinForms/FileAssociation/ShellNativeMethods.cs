using System;
using System.Runtime.InteropServices;

namespace PlgxUnpacker.FileAssociation
{
    internal static class ShellNativeMethods
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern void SHChangeNotify(
            long wEventId,
            uint uFlags,
            IntPtr dwItem1,
            IntPtr dwItem2);

        internal static void ChangeNotify()
        {
            SHChangeNotify(
                (long)ShellChangeNotificationEvents.SHCNE_ASSOCCHANGED,
                (uint)(ShellChangeNotificationFlags.SHCNF_IDLIST | ShellChangeNotificationFlags.SHCNF_FLUSHNOWAIT),
                IntPtr.Zero,
                IntPtr.Zero);
        }

        [Flags]
        private enum ShellChangeNotificationEvents : uint
        {
            /// <summary>
            /// A file type association has changed. SHCNF_IDLIST must be specified in the uFlags parameter. dwItem1 and dwItem2 are not used and must be NULL. This event should also be sent for registered protocols.
            /// </summary>
            SHCNE_ASSOCCHANGED = 0x08000000
        }

        private enum ShellChangeNotificationFlags
        {
            /// <summary>
            /// dwItem1 and dwItem2 are the addresses of ITEMIDLIST structures that represent the item(s) affected by the change. Each ITEMIDLIST must be relative to the desktop folder. 
            /// </summary>
            SHCNF_IDLIST = 0x0000,

            /// <summary>
            /// The function should begin delivering notifications to all affected components but should return as soon as the notification process has begun. As this flag modifies other data-type flags, it cannot by used by itself. This flag includes SHCNF_FLUSH.
            /// </summary>
            SHCNF_FLUSHNOWAIT = 0x2000
        }
    }
}
