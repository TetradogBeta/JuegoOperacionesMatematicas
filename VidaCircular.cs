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
    public partial class VidaCircular : UserControl
    {
        float vida;
        const float VIDACOMPLETA = 180f;
        Color[] colorVida;
        int[] tantPerCentColor;
        public VidaCircular()
        {
            Vida = 100;
            InitializeComponent();
            colorVida=new Color[]{Color.Blue,Color.Green,Color.Orange,Color.Red};
            tantPerCentColor = new int[] { 75, 50, 25, 0 };
            
            BackColor = Color.Transparent;
        }
        [Category("Vida"), Description("Obté o estableix la vida [0,100]")]
        public int Vida
        {
            get { return Convert.ToInt32(vida/1.8); }
            set {
                if (value > 100)
                    value = 100;
                else if (value < 0)
                    value = 0;
                vida = value * 1.8f; Refresh(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Pen pen = new Pen(DonamColor(), Width / 25);
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            e.Graphics.DrawArc(pen, new Rectangle(new Point(Width/5,Height/5),new Size(Width-Width/5 , Height-Height/3)), 90f, vida);
        }

        private Color DonamColor()
        {
          Color colorVidaActual=Color.Blue;
          if (tantPerCentColor[0] < vida / 1.8)
              colorVidaActual = colorVida[0];
          else if (tantPerCentColor[1] < vida / 1.8)
              colorVidaActual = colorVida[1];
          else if (tantPerCentColor[2] < vida / 1.8)
              colorVidaActual = colorVida[2];
          else 
              colorVidaActual = colorVida[3];
          return colorVidaActual;

        }
    }
}
