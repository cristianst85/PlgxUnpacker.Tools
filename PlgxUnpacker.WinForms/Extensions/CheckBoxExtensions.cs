using System.Windows.Forms;

namespace PlgxUnpacker.Extensions
{
    public static class CheckBoxExtensions
    {
        public static bool IsChecked(this CheckBox checkBox)
        {
            return checkBox.CheckState == CheckState.Checked;
        }
    }
}
