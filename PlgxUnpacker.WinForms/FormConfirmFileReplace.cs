using System.Windows.Forms;

namespace PlgxUnpacker
{
    public partial class FormConfirmFileReplace : Form
    {
        public FileReplacePromptResult FileReplacePromptResult { get; private set; }

        public FormConfirmFileReplace(string fileName)
        {
            InitializeComponent();
            label.Text = string.Format(label.Text, fileName);
            FileReplacePromptResult = FileReplacePromptResult.Cancel;
        }

        private void ButtonYes_Click(object sender, System.EventArgs e)
        {
            FileReplacePromptResult = FileReplacePromptResult.Yes;
            Close();
        }

        private void ButtonYesAll_Click(object sender, System.EventArgs e)
        {
            FileReplacePromptResult = FileReplacePromptResult.YesAll;
            Close();
        }

        private void ButtonNo_Click(object sender, System.EventArgs e)
        {
            FileReplacePromptResult = FileReplacePromptResult.No;
            Close();
        }

        private void ButtonNoAll_Click(object sender, System.EventArgs e)
        {
            FileReplacePromptResult = FileReplacePromptResult.NoAll;
            Close();
        }

        private void ButtonCancel_Click(object sender, System.EventArgs e)
        {
            FileReplacePromptResult = FileReplacePromptResult.Cancel;
            Close();
        }
    }
}
