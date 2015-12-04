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
    public partial class Operació : UserControl,IComparable<Operació>
    {
        public enum Dificultat
        {
            moltFàcil,fàcil,normal,dificil,moltDificil
        }

        Dificultat dificultatOperació;


        int operacionsFetesBé;


        int totalOperacions;


        int vida;


        int punts;

        Pregunta preguntaOperacio;
        int estrellesAconseguides;





        bool esObligatoria;
     
        Label lblNomOperació;
        PictureBox[] pbsEstrellesDificultat;

        public event PuntsIVidaPreguntaEventHandler PuntsIVidaOperacióFeta;

        public Operació()
        {
            InitializeComponent();

            lblNomOperació = new Label();
            pbsEstrellesDificultat = new PictureBox[5];
            for (int i = 0; i < 5; i++)
            {
                pbsEstrellesDificultat[i] = new PictureBox();
                pbsEstrellesDificultat[i].SizeMode = PictureBoxSizeMode.Zoom;
                pbsEstrellesDificultat[i].Image = new Bitmap(imatges.estrellaSinConseguir);
                Controls.Add(pbsEstrellesDificultat[i]);
            }

            this.PreguntaOperacio =new Suma();
            TotalOperacions++;
            this.Inicialitza();
            Controls.Add(lblNomOperació);
            OnResize(null);
            DificultatOperació = Dificultat.normal;
            Refresh();

        }
        public Operació(Pregunta.TipusOperació tipus):this()
        {
            this.preguntaOperacio = Operacions.Pregunta.DonamPregunta(tipus);
            this.Inicialitza();
        }
        public Operació(Pregunta.TipusOperació tipus, Dificultat dificultat)
            : this(tipus)
        {
            DificultatOperació = dificultat;
        }
        #region Propietats
        [Category("Operacio"), Description("Diu la dificultat de la operació")]
        public Dificultat DificultatOperació
        {
            get { return dificultatOperació; }
            set { dificultatOperació = value; PosaFons(); preguntaOperacio.DificultatExercici = value; preguntaOperacio.PosaPregunta(); }
        }

        [Category("Operacio"), Description("Diu quantes operacions s'han respost bé")]
        public int OperacionsFetesBé
        {
            get { return operacionsFetesBé; }
            protected    set { operacionsFetesBé = value; }
        }
        [Category("Operacio"), Description("Diu el total de operacions")]
        public int TotalOperacions
        {
            get { return totalOperacions; }
            protected   set { totalOperacions = value; }
        }
        [Category("Operacio"), Description("Diu els punts que te la operació")]
        public int Punts
        {
            get { return punts; }

        }
        [Category("Operacio"), Description("Estableix si la operacio es obligatoria")]
        public bool EsObligatoria
        {
            get { return esObligatoria; }
            set { esObligatoria = value; }
        }
        [Category("Operacio"), Description("Estableix  quina pregunta es")]
        public Pregunta.TipusOperació Pregunta
        {
            get { return preguntaOperacio.Tipus; }
            private  set { PreguntaOperacio = Operacions.Pregunta.DonamPregunta(value); Inicialitza(); }
        }
        [Category("Operacio"), Description("Estableix  les estrelles aconseguides")]
        public int EstrellesAconseguides
        {
            get { return estrellesAconseguides; }
            set {
                if (value > 5) value = 5;
                else if (value < 0) value = 0;
                if(value!=estrellesAconseguides){estrellesAconseguides = value; PosaEstrelles();} }
        }


        private Pregunta PreguntaOperacio
        {
            get { return preguntaOperacio; }
            set
            {
                if (value != null)
                {
                    preguntaOperacio = value;
                    preguntaOperacio.RespostaCorrecte += new RespostaCorrectaEventHandler(LaPreguntaEstaBé);
                    preguntaOperacio.PuntsIVida += new PuntsIVidaPreguntaEventHandler(PuntsIVidaOperacio);
                }
            }
        }

        private void PuntsIVidaOperacio(int punts, int vida)
        {
            if (PuntsIVidaOperacióFeta != null)
                PuntsIVidaOperacióFeta(punts, vida);
            this.punts += punts;

        }
        private void Inicialitza()
        {
            lblNomOperació.Text = Pregunta + ""; OnResize(null);

        }
        private void PosaEstrelles()
        {
            
            for (int i = 0; i < EstrellesAconseguides; i++)
                pbsEstrellesDificultat[i].Image = new Bitmap(imatges.estrella);
            for (int i = estrellesAconseguides; i < 5; i++)
                pbsEstrellesDificultat[i].Image = new Bitmap(imatges.estrellaSinConseguir);
        }
        private void LaPreguntaEstaBé()
        {
            operacionsFetesBé++;
        }
        #endregion
        private void PosaFons()
        {
            Color color = Color.DarkViolet;
            switch (DificultatOperació)
            {
                case Dificultat.moltFàcil: color = Color.FromArgb(255, 224, 192); break;
                case Dificultat.fàcil: color = Color.LightYellow; break;
                case Dificultat.normal: color = Color.LightGreen; break;
                case Dificultat.dificil: color = Color.LightBlue; break;
                case Dificultat.moltDificil: color = Color.Violet; break;

            }
            BackColor = color;
        }
        protected override void OnResize(EventArgs e)
        {
            int ampladaEstrella;
            int ampladaEstrellaTotal;
            Width = Height * 2;
            try
            {
                lblNomOperació.Font = new Font("Arial", Width / 12, FontStyle.Regular);
                lblNomOperació.Size = lblNomOperació.PreferredSize;
                lblNomOperació.Location = new Point((Width - lblNomOperació.PreferredSize.Width) / 2, Height / 5);
                ampladaEstrella = Width / 7;
                ampladaEstrellaTotal = ampladaEstrella;
                foreach (PictureBox pbEstrella in pbsEstrellesDificultat)
                {
                    pbEstrella.Location = new Point(ampladaEstrellaTotal, 4 * Height / 7);
                    ampladaEstrellaTotal += ampladaEstrella;
                    pbEstrella.Size = new Size(ampladaEstrella, ampladaEstrella);
                }
            }
            catch { }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect=ClientRectangle;
            rect.Inflate(-Width / 40, -Height / 40);
            e.Graphics.DrawRectangle(DonamColor(),rect);
        }

        private Pen DonamColor()
        {
            Color color=Color.DarkViolet;
            
            switch (DificultatOperació)
            {
                case Dificultat.moltFàcil: color = Color.Orange; break;
                case Dificultat.fàcil: color = Color.Yellow; break;
                case Dificultat.normal: color = Color.Green; break;
                case Dificultat.dificil: color = Color.Blue; break;
                case Dificultat.moltDificil: color = Color.DarkViolet; break;
             
            }
            return new Pen(color, Width / 20);
        }
        public void PosaUnaAltrePregunta()
        {
            preguntaOperacio.PosaPregunta();
            TotalOperacions++;
            
            
        }
        public static Operació DonamOperació(Pregunta.TipusOperació tipus)
        {
           
            Operació operació = new Operació();
            operació.PreguntaOperacio = Operacions.Pregunta.DonamPregunta(tipus);
            operació.TotalOperacions++;
            operació.Inicialitza();
            return operació;
        }


        public int CompareTo(Operació other)
        {
            if (preguntaOperacio.Tipus.CompareTo(other.preguntaOperacio.Tipus) == 0)
                return dificultatOperació.CompareTo(other.dificultatOperació);
            else
                return preguntaOperacio.Tipus.CompareTo(other.preguntaOperacio.Tipus);
        }
    }
}
