using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTAnnotation
{
    public class Label
    {
        public string name;
        public ushort index;
        public Color color;

        public Label(string name, ushort index, Color color)
        {
            this.name = name;
            this.index = index;
            this.color = color;
        }
    }
}
