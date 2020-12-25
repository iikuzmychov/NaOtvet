using System;
using System.Drawing;
using System.Windows.Forms;

namespace NaOtvet.Controls
{
    public class PanelNoScrollOnFocus : Panel
    {
        protected override Point ScrollToControl(Control activeControl)
        {
            return DisplayRectangle.Location;
        }
    }
}
