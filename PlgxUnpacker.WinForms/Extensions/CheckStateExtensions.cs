using System.Windows.Forms;
using System;

namespace PlgxUnpacker.Extensions
{
    public static class CheckStateExtensions
    {
        public static bool? ToBool(this CheckState checkState)
        {
            if (checkState == CheckState.Checked)
            {
                return true;
            }
            else if (checkState == CheckState.Unchecked)
            {
                return false;
            }
            else if (checkState == CheckState.Indeterminate)
            {
                return null;
            }

            throw new NotSupportedException($"The conversion of value '{checkState}' from {typeof(CheckState)} to {typeof(bool?)} is not supported.");
        }
    }
}
