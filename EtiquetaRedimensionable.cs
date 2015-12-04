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
    public partial class EtiquetaRedimensionable : Label
    {
        public EtiquetaRedimensionable()
        {
            Text = " ";
            InitializeComponent();
            
        }
        protected override void OnResize(EventArgs e)
        {
            try
            {
               // base.OnResize(e);
                int amplada = Width;
                do
                {
                    Font = new Font("Arial", amplada--, GraphicsUnit.Pixel);

                } while (PreferredSize.Width > Width);
                Height = PreferredSize.Height;
            }
            catch { }
        }
    }
}
