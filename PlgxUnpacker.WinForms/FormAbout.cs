using PlgxUnpacker.Helpers;
using PlgxUnpacker.Configuration;
using System.Diagnostics;
using System.Windows.Forms;

namespace PlgxUnpacker
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();

            labelVersion.Text = labelVersion.Text.Replace("{version}", AssemblyUtils.GetProductVersion());
            richTextBoxCopyright.Text = richTextBoxCopyright.Text.Replace("{plgxUnpackerNetLibVersion}", AssemblyUtils.GetProductVersion("PlgxUnpackerNet.dll").ToString());

            KeyDown += new KeyEventHandler(FormAbout_KeyPress);

            richTextBoxCopyright.LinkClicked += new LinkClickedEventHandler(RichTextBoxCopyright_LinkClicked);
            linkLabelContact.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkLabelContact_LinkClicked);
            linkLabelSource.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkLabelSource_LinkClicked);
        }

        private void FormAbout_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void RichTextBoxCopyright_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void LinkLabelContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(string.Format("mailto:{0}?subject=About {1} v{2}", this.linkLabelContact.Text, Settings.ApplicationName, AssemblyUtils.GetVersion()));
        }

        private void LinkLabelSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/cristianst85/PlgxUnpacker.Tools");
        }
    }
}