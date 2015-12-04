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
    public partial class NivellJugador : ControlCircular
    {
        int nivell;
        EtiquetaRedimensionable lblNivell;
       [Category("Nivell"), Description("Obté o estableix el nivell del jugador")]
        public int Nivell
        {
            get { return nivell; }
            set { nivell = value; lblNivell.Text = value + ""; lblNivell.Size = lblNivell.PreferredSize; OnResize(null); }
        }
        public NivellJugador()
        {
            InitializeComponent();
            lblNivell = new EtiquetaRedimensionable();
            Controls.Add(lblNivell);
            Nivell = 0;
            BackColor = Color.Transparent;

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            lblNivell.Size = Size;
            lblNivell.Location = new Point((Width - lblNivell.Width+Width/10) / 2, (Height - lblNivell.Height) / 2);
        }
    }
}
