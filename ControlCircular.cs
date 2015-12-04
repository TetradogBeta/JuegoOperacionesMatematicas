using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Operacions
{
    public partial class ControlCircular : UserControl
    {
        private GraphicsPath camiC;
        public ControlCircular()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            camiC = new GraphicsPath();
            camiC.AddEllipse(new Rectangle(new Point(0, 0), new System.Drawing.Size(Width, Height)));
            Region =new Region(camiC);
        }
        protected override void OnResize(EventArgs e)
        {
            Width = Height;
        }
    }
}
