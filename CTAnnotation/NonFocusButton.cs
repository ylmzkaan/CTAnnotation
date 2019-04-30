using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTAnnotation
{
    public class NonFocusButton : Button
    {
        public NonFocusButton()
        {
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
