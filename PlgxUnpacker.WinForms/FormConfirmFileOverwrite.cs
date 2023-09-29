using System.Windows.Forms;

namespace PlgxUnpacker
{
    public partial class FormConfirmFileOverwrite : Form
    {
        public FileOverwritePromptResult FileOverwritePromptResult { get; private set; }

        public FormConfirmFileOverwrite(string fileName)
        {
            InitializeComponent();
            label.Text = label.Text.Replace("{fileName}", fileName);
            FileOverwritePromptResult = FileOverwritePromptResult.Cancel;
        }

        private void ButtonYes_Click(object sender, System.EventArgs e)
        {
            FileOverwritePromptResult = FileOverwritePromptResult.Yes;
            Close();
        }

        private void ButtonYesAll_Click(object sender, System.EventArgs e)
        {
            FileOverwritePromptResult = FileOverwritePromptResult.YesAll;
            Close();
        }

        private void ButtonNo_Click(object sender, System.EventArgs e)
        {
            FileOverwritePromptResult = FileOverwritePromptResult.No;
            Close();
        }

        private void ButtonNoAll_Click(object sender, System.EventArgs e)
        {
            FileOverwritePromptResult = FileOverwritePromptResult.NoAll;
            Close();
        }

        private void ButtonCancel_Click(object sender, System.EventArgs e)
        {
            FileOverwritePromptResult = FileOverwritePromptResult.Cancel;
            Close();
        }
    }
}
