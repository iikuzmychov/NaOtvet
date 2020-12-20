using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NaOtvet
{
    public class CustomizableLabel : Label
    {
        private Color disabledForeColor;

        [Description("Цвет текста в выключенном состоянии"), Category("Appearance")]
        public Color DisabledForeColor
        {
            get
            {
                return disabledForeColor;
            }

            set
            {
                disabledForeColor = value;
                Refresh();
            }
        }

        public CustomizableLabel() : base() 
        {
            DisabledForeColor = ForeColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Enabled)
            {
                base.OnPaint(e);
                return;
            }

            base.OnPaintBackground(e);

            var rectangle = new Rectangle(0, 0, Size.Width, Size.Height);
            var textFormatFlags = HelpClass.TextAlignToFormatFlags(TextAlign);

            TextRenderer.DrawText(e.Graphics, Text, Font, rectangle, DisabledForeColor, textFormatFlags);
        }
    }
}
