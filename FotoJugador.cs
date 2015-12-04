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
    public partial class FotoJugador : ControlCircular
    {
        PictureBox pbJugador;
        public FotoJugador()
        {
            InitializeComponent();
            pbJugador = new PictureBox();
            pbJugador.SizeMode = PictureBoxSizeMode.Zoom;
            Controls.Add(pbJugador);
            pbJugador.Dock = DockStyle.Fill;
        }
        public Bitmap Imatge
        {
            get { return (Bitmap)pbJugador.Image; }
            set { pbJugador.Image = value; Refresh(); }
        }

    }
}
