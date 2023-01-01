using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PlgxUnpacker.Windows
{
    internal static class NativeMethods
    {
        /// <summary>
        /// Determines whether the current user has administrator privileges for Windows 2000 and above.
        /// </summary>
        /// <returns></returns>
        [DllImport("shell32.dll", EntryPoint = "IsUserAnAdmin", CharSet = CharSet.Unicode)]
        internal static extern bool IsUserAnAdmin();

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        internal static extern IntPtr SendMessage(HandleRef hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        internal static void SetButtonShield(Button button, bool showShield)
        {
            // Set the button FlatStyle to FlatStyle.System.
            button.FlatStyle = FlatStyle.System;

            // BCM_SETSHIELD = 0x0000160C
            SendMessage(new HandleRef(button, button.Handle), 0x160C, IntPtr.Zero, showShield ? new IntPtr(1) : IntPtr.Zero);
        }

        [DllImport("user32.dll")]
        internal static extern bool SetProcessDPIAware();

        [DllImport("ShCore.dll")]
        internal static extern int SetProcessDpiAwareness([MarshalAs(UnmanagedType.U4)] ProcessDpiAwareness processDpiAwareness);

        internal enum ProcessDpiAwareness : uint
        {
            /// <summary>
            /// DPI unaware. This application does not scale for DPI changes and is always assumed
            /// to have a scale factor of 100% (96 DPI). It will be automatically scaled
            /// by the system on any other DPI setting.
            /// </summary>
            ProcessDpiUnaware = 0,

            /// <summary>
            /// System DPI aware. This application does not scale for DPI changes. It will query
            /// for the DPI once and use that value for the lifetime of the application. If the 
            /// DPI changes, the application will not adjust to the new DPI value. It will be
            /// automatically scaled up or down by the system when the DPI changes
            /// from the system value.
            /// </summary>
            ProcessSystemDpiAware = 1,

            /// <summary>
            /// Per monitor DPI aware. This application checks for the DPI when it is created and
            /// adjusts the scale factor whenever the DPI changes. These applications
            /// are not automatically scaled by the system.
            /// </summary>
            ProcessPerMonitorDpiAware = 2
        }
    }
}
