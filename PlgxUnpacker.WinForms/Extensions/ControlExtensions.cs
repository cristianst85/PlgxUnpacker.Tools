using System.ComponentModel;
using System.Windows.Forms;

namespace PlgxUnpacker.Extensions
{
    public static class ControlExtensions
    {
        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            ((ISynchronizeInvoke)control).InvokeIfRequired(action);
        }

        private static void InvokeIfRequired(this ISynchronizeInvoke obj, MethodInvoker action)
        {
            if (obj.InvokeRequired)
            {
                obj.Invoke(action, new object[0]);
            }
            else
            {
                action();
            }
        }
    }
}
