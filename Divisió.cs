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
    partial class Divisió : Pregunta
    {
        decimal numerador;


        decimal divisor;


        PictureBox pbDivisor;
        PictureBox pbResidu;
        Label lblDivident;
        Label lblDivisor;
        Label lblPista;
        NumerosUpDown nudResidu;
        NumerosUpDown nudQuocient;
        public Divisió()
        {
            InitializeComponent();
            pbDivisor = new PictureBox();
            pbDivisor.Image = new Bitmap(imatges.divisorContenidor);
            pbResidu = new PictureBox();
            pbResidu.Image = new Bitmap(imatges.residuContenidor);
            lblDivident = new Label();
            lblDivisor = new Label();
            lblPista = new Label();
            nudQuocient = new NumerosUpDown();
            nudResidu = new NumerosUpDown();
            pbDivisor.SizeMode = PictureBoxSizeMode.Zoom;
            pbResidu.SizeMode = PictureBoxSizeMode.Zoom;
            PnlPista.Controls.Add(lblPista);
            PnlOperacio.Controls.Add(nudResidu);
            PnlOperacio.Controls.Add(nudQuocient);
           PnlOperacio.Controls.Add(lblDivisor);
           PnlOperacio.Controls.Add(lblDivident);
           PnlOperacio.Controls.Add(pbResidu);
           PnlOperacio.Controls.Add(pbDivisor);
           lblPista.Text = "Es una Divisió";
           lblPista.Click += new EventHandler(Clic);

           nudQuocient.TextAlign = HorizontalAlignment.Right;
           nudQuocient.KeyPress += new KeyPressEventHandler(ValidatResultat);

           nudResidu.TextAlign = HorizontalAlignment.Right;
           nudResidu.KeyPress += new KeyPressEventHandler(ValidatResultat);
           PosaPregunta();
           nudQuocient.TabIndex = 0;
           nudResidu.TabIndex = 1;

           nudQuocient.Maximum = 99999;
           nudQuocient.Minimum = (-1) * 99999;
           nudResidu.Maximum = 9999;
           nudResidu.Minimum = -9999;

        }
        #region Propietats
        private decimal Divisor
        {
            get { return divisor; }
            set { divisor = value; lblDivisor.Text = divisor + ""; lblDivisor.Size = lblDivisor.PreferredSize; OnResize(null); }
        }
        private decimal Numerador
        {
            get { return numerador; }
            set { numerador = value; lblDivident.Text = numerador + ""; lblDivident.Size = lblDivident.PreferredSize; OnResize(null); }
        }
        private int Residu
        {
            get { return Convert.ToInt32(numerador) % Convert.ToInt32(divisor); }
        }
        private int Quocient
        {
            get { return Convert.ToInt32(numerador) / Convert.ToInt32(divisor); }
        }
        private int NumDecimalsResultat
        {
            get
            {
                try
                {
                    return (Convert.ToInt32(numerador) / Convert.ToInt32(divisor)).ToString().Split(',')[1].Length;
                }
                catch { return 0; }
            }
        }
        private int LongitudResultat
        {
            get { return Quocient + NumDecimalsResultat; }
        }
        #endregion
        private void ValidatResultat(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
            {
               ValidaExercici();
            }
        }
        private void Clic(object sender, EventArgs e)
        {
            base.OnClick(null);
        }
        public override void PosaPregunta()
        {
            nudResidu.Enabled = true;
            nudQuocient.Enabled = true;
            switch (DificultatExercici)
            {
                case Operació.Dificultat.moltFàcil:
                    do
                    {
                        Divisor = llavor.Next(1, 11);
                        Numerador = llavor.Next(0, 101);
                    } while (Residu != 0);
                    nudResidu.Value = 0;
                    nudResidu.Enabled = false;
                    break;
                case Operació.Dificultat.fàcil:
                    do
                    {
                        Divisor = llavor.Next(1, 11);
                        Numerador = llavor.Next(0, 1001);
                    } while (Residu != 0);
                    nudResidu.Value = 0;
                    nudResidu.Enabled = false;
                    break;
                case Operació.Dificultat.normal:
                    do
                    {
                        Divisor = llavor.Next(1, 11);
                        Numerador = llavor.Next(0, 1001);
                    } while (NumDecimalsResultat <0 && NumDecimalsResultat > 4);
                    nudQuocient.DecimalPlaces = NumDecimalsResultat;
                    nudResidu.Enabled = true;
                    break;
                case Operació.Dificultat.dificil:
                    do
                    {
                        Divisor =Convert.ToDecimal( llavor.Next(1, 101));
                        Numerador = Convert.ToDecimal(llavor.Next(1, 1001) + "," + llavor.Next(1, 101));
                    } while (NumDecimalsResultat>4);
                    nudQuocient.DecimalPlaces = NumDecimalsResultat;
                    nudResidu.Enabled = true;
                    break;
                case Operació.Dificultat.moltDificil:
                    do
                    {
                        Divisor = Convert.ToDecimal(llavor.Next(1, 101) + "," + llavor.Next(1, 11));
                        Numerador = Convert.ToDecimal(llavor.Next(1, 1001) + "," + llavor.Next(1, 101));
                    } while (LongitudResultat>=4&&LongitudResultat<=7);
                    nudQuocient.DecimalPlaces = NumDecimalsResultat;
                    nudResidu.Enabled = true;
                    break;
            }

            OnResize(null);
        }
        protected override void OnResize(EventArgs e)
        {
            Width =Convert.ToInt32( Height * 1.5);
            int altura = Height / 13;
           
            lblDivident.Location = new Point(0, altura);

            pbDivisor.Location = new Point(Width / 2, 0);
            pbDivisor.Size = new Size(Width / 2 - Width / 15, Height / 2 - Width / 15);

            lblDivisor.Location = new Point(Width / 2 + Width / 15, altura);
            

            nudResidu.Size = new Size(Width / 3, Height / 2);
            nudResidu.Location = new Point(0, Height / 2);

            pbResidu.Location = new Point(nudResidu.Width + Width / 180, Height / 2);
            pbResidu.Size = new Size(lblDivident.Width / 4 , Height / 2);

            nudQuocient.Size = pbDivisor.Size;
            nudQuocient.Location = new Point(Width / 2, Height / 2);

            lblDivident.Font = new Font("Arial", Width / 12);
            lblDivisor.Font = lblDivident.Font;
            lblDivident.Size = lblDivident.PreferredSize;
            lblDivisor.Size = lblDivisor.PreferredSize;
           
            lblPista.Font = new System.Drawing.Font("Arial", Height / 13);
            lblPista.Size = lblPista.PreferredSize;
            lblPista.Location = new Point((Width - lblPista.PreferredSize.Width) / 2, Height / 3);
        }
        protected override bool EstaBéLaResposta()
        {
            return Residu == nudResidu.Value && Quocient == nudQuocient.Value;
        }
        public override void MostraResultatCorrecte()
        {
            nudQuocient.Value = Quocient;
            nudResidu.Value = Residu;
            nudResidu.Enabled = false;
            nudQuocient.Enabled = false;
        }

    }
}
