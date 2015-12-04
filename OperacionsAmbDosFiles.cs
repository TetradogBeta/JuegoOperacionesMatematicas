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
    
    partial class OperacionsAmbDosFiles : Pregunta
    {
        protected Label lblPista;
        protected Label lblnum1;
        protected Label lblnum2;
        protected Label lblsigne;
        Label lblSeparació;
        NumerosUpDown nudResultat;
        decimal resultatOperació;

        public OperacionsAmbDosFiles()
        {
            InitializeComponent();
            lblPista = new Label();
            lblsigne = new Label();
            lblnum1 = new Label();
            lblnum2 = new Label();
            lblSeparació = new Label();

            lblnum1.Font = new System.Drawing.Font("Arial", Height / 10);
            lblnum2.Font = new System.Drawing.Font("Arial", Height / 10);
            lblPista.Font = new System.Drawing.Font("Arial", Height / 13);
            lblsigne.Font = new System.Drawing.Font("Arial", Height / 10);

            lblPista.Click += new EventHandler(Clic);

            lblSeparació.Text = DonamSeparacio();
            nudResultat = new NumerosUpDown();
            PnlOperacio.Controls.Add(lblnum1);
            PnlOperacio.Controls.Add(lblsigne);
            PnlOperacio.Controls.Add(lblnum2);
            PnlOperacio.Controls.Add(lblSeparació);
            PnlOperacio.Controls.Add(nudResultat);
            PnlPista.Controls.Add(lblPista);
            lblnum2.BringToFront();
            lblnum1.BringToFront();

            lblSeparació.BringToFront();
            lblnum1.Size = new System.Drawing.Size(Width / 4, Height / 4);
            lblnum2.Size = lblnum1.Size;
            nudResultat.TextAlign = HorizontalAlignment.Right;
            nudResultat.KeyPress += new KeyPressEventHandler(ValidatResultat);
            lblPista.Width = Width;
    
        }
        protected string Pista
        {
            set { lblPista.Text = value; lblPista.Size = lblPista.PreferredSize; OnResize(null); }
        }
        protected decimal NumeroLinea1
        {
            get{return Convert.ToDecimal(lblnum1.Text);}
        }
        protected decimal NumeroLinea2
        {
            get{return Convert.ToDecimal(lblnum2.Text);}
        }
        protected string Signe
        {
            get { return lblsigne.Text; }
            set { lblsigne.Text = value; }
        }
        protected decimal ResultatOperació
        {
            get { return resultatOperació; }
            set { resultatOperació = value; }
        }
        private void Clic(object sender, EventArgs e)
        {
            base.OnClick(null);
        }

        private void ValidatResultat(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
            {
                ValidaExercici();
            }
        }



        private string DonamSeparacio()
        {
            StringBuilder separacio = new StringBuilder();
            for (int i = 0; i < 40; i++)
                separacio.Append('-');
            return separacio.ToString();
        }
        protected virtual void CalculaOperació()
        {

            switch (DificultatExercici)
            {
                case Operació.Dificultat.moltFàcil:
                    lblnum1.Text = llavor.Next(0, 10) + "";
                    lblnum2.Text = llavor.Next(0, 10) + "";
                    break;
                case Operació.Dificultat.fàcil:
                    lblnum1.Text = llavor.Next(0, 20) + "";
                    lblnum2.Text = llavor.Next(0, 20) + "";
                    break;
                case Operació.Dificultat.normal:
                    lblnum1.Text = llavor.Next(0, 100) + "";
                    lblnum2.Text = llavor.Next(0, 100) + "";
                    break;
                case Operació.Dificultat.dificil:
                    lblnum1.Text = llavor.Next(0, 100) + "" + "," + llavor.Next(0, 10) + "";
                    lblnum2.Text = llavor.Next(0, 100) + "" + "," + llavor.Next(0, 10) + "";
                    break;
                case Operació.Dificultat.moltDificil:
                    lblnum1.Text = llavor.Next(0, 100) + "" + "," + llavor.Next(0, 100) + "";
                    lblnum2.Text = llavor.Next(0, 100) + "" + "," + llavor.Next(0, 100) + "";
                    break;
            }
            if (DificultatExercici < Operació.Dificultat.normal)
            {
                if (NumeroLinea1 < NumeroLinea2)
                {
                    lblnum2.Tag = lblnum1.Text;
                    lblnum1.Text = lblnum2.Text;
                    lblnum2.Text = (string)lblnum2.Tag;
                }
            }
            CalculaResultat();
            try
            {
                nudResultat.DecimalPlaces = ResultatOperació.ToString().Split(',')[1].Length;
            }
            catch { nudResultat.DecimalPlaces = 0; }
            nudResultat.Maximum = (decimal)(Math.Pow(10, ResultatOperació.ToString().Split(',')[0].Length) * 9);
            nudResultat.Minimum = (-1) * nudResultat.Maximum;
            OnResize(null);
        }
        protected override bool EstaBéLaResposta()
        {
            return ResultatOperació.Equals(nudResultat.Value);
        }
        public override void MostraResultatCorrecte()
        {
            nudResultat.Value = ResultatOperació;
            nudResultat.Enabled = false;
            Refresh();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (lblSeparació != null)
            {
                int separacioExtra1 = 0;
                int separacioExtra2 = 0;

                if (lblnum1.Text.Length > 2)
                {
                    if (lblnum1.Text.Split(',')[0].Length == 1)
                        separacioExtra1 = Width / 17;
                }
                else if (lblnum1.Text.Length == 1)
                    separacioExtra1 = Width / 17;

                if (lblnum2.Text.Length > 2)
                {
                    if (lblnum2.Text.Split(',')[0].Length == 1)
                        separacioExtra2 = Width / 17;
                }
                else if (lblnum2.Text.Length == 1)
                    separacioExtra2 = Width / 17;

                lblPista.Location = new Point((Width-lblPista.PreferredSize.Width)/2, Height / 3);

                lblnum1.Location = new Point(Width / 2 + separacioExtra1 - Width / 15, Height / 9);
                lblsigne.Location = new Point(Width / 5, Height / 2 - Height / 8);
                lblnum2.Location = new Point(Width / 2 + separacioExtra2 - Width / 15, Height / 2 - Height / 9);
                lblSeparació.Location = new Point(Width / 5 + Width / 10, Height / 2 + Height / 10);
                nudResultat.Location = new Point(Width / 4, Height * 4 / 5);
                lblnum1.Width = Width;
                lblnum2.Width = Width;
            }
        }
        public override void PosaPregunta()
        {
            CalculaOperació();
        }
    }
}
