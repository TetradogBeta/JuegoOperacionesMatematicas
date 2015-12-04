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
    public partial class Fitxa : UserControl
    {
        Pregunta pregunta;
        bool estaSeleccionada;
        int numMaxValidacions;


        public Fitxa()
        {
            InitializeComponent();
            Pregunta = new Divisió();
            Dificultat = Operació.Dificultat.normal;
            Pregunta.TreurePistaFentClic = true;
            Pregunta.RespostaCorrecte += new RespostaCorrectaEventHandler(Correcte);
            Pregunta.UsuariValidaResposta += new UsuariValidaRespostaEventHandler(Valida);
            NumMaxValidacions = 3;
            
        }

        private void Valida()
        {
            if (numMaxValidacions > 0)
                numMaxValidacions--;
            else
            {
                Pregunta.MostraResultatCorrecte();
                BackColor = Color.Red;
            }
        }

        private void Correcte()
        {
            BackColor = Color.Green;
        }
        public int NumMaxValidacions
        {
            get { return numMaxValidacions; }
            set { numMaxValidacions = value-1; }
        }
        public Pregunta Pregunta
        {
            get { return pregunta; }
            set {
                if(pregunta!=null)
                Controls.Remove(pregunta);
                pregunta = value;
                Controls.Add(pregunta);
                OnResize(null);
                Dificultat = Dificultat;
                Pregunta.BackColor = Color.WhiteSmoke;
            }
        }
        public Operació.Dificultat Dificultat
        {
            get { return Pregunta.DificultatExercici; }
            set { Pregunta.DificultatExercici = value; PosaFons(); }
        }

        private void PosaFons()
        {
            Color color = Color.DarkViolet;
            switch (Dificultat)
            {
                case Operació.Dificultat.moltFàcil: color = Color.FromArgb(255, 224, 192); break;
                case Operació.Dificultat.fàcil: color = Color.LightYellow; break;
                case Operació.Dificultat.normal: color = Color.LightGreen; break;
                case Operació.Dificultat.dificil: color = Color.LightBlue; break;
                case Operació.Dificultat.moltDificil: color = Color.Violet; break;

            }
            BackColor = color;
        }
        protected override void OnResize(EventArgs e)
        {
         
                Pregunta.Height = Height / 2;
                Pregunta.Location = new Point((Width - Pregunta.Width) / 2, Height / 3);
     
        }
         
    }
}
