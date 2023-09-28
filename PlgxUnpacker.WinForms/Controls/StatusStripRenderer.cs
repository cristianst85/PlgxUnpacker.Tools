﻿using System.Drawing;
using System.Windows.Forms;

namespace PlgxUnpacker.Controls
{
    public class StatusStripRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (e.Item is ToolStripStatusLabel)
            {
                TextRenderer.DrawText(e.Graphics, e.Text, e.TextFont,
                    e.TextRectangle, e.TextColor, Color.Transparent,
                    e.TextFormat | TextFormatFlags.EndEllipsis);
            }
            else
            {
                base.OnRenderItemText(e);
            }
        }
    }
}
