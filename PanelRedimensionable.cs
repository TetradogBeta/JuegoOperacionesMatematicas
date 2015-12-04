using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operacions
{
    public partial class PanelRedimensionable : Panel
    {
        int WidthAnt;
        int HeightAnt;
        private  bool redimensionarControl;
        public PanelRedimensionable()
        {
            InitializeComponent();
            WidthAnt = Width;
            HeightAnt = Height;
        }
        [Category("Panell"), Description("obté o estableix si es manté la proporció del control")]
        public bool MantenirProporcionsControl
        {
            get { return redimensionarControl; }
            set { redimensionarControl = value; }
        }

        protected override void OnResize(EventArgs e)
        {
            try
            {
                base.OnResize(e);
               
                double proporció = (Height / (HeightAnt*1.0));
                if (MantenirProporcionsControl)
                {
                    Width = Convert.ToInt32(Width * proporció);
                }
                if (!DesignMode)
                {
                    if (proporció.CompareTo(0) != 0)
                    {
                        foreach (Control control in Controls)
                        {
                            control.Location = new Point(Convert.ToInt32(proporció * control.Location.X), Convert.ToInt32(proporció * control.Location.Y));
                            control.Size = new Size(Convert.ToInt32(control.Width * proporció), Convert.ToInt32(control.Height * proporció));
                            control.Refresh();
                        }

                        WidthAnt = Width;
                        HeightAnt = Height;
                    }
                }
            }
            catch
            {
               
            }
       
        }
    }
}
