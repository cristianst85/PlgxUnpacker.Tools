using System.ComponentModel;
using System.Windows.Forms;

namespace PlgxUnpacker.Controls
{
    public class ButtonEx : Button
    {
        public ButtonEx() : base()
        {
        }

        [Category("Appearance")]
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual string TextToggle { get; set; }

        public void ToggleText()
        {
            var text = TextToggle;
            TextToggle = Text;
            Text = text;
        }
    }
}
