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
    public delegate void UsuariValidaRespostaEventHandler();
    public delegate void RespostaCorrectaEventHandler();
    public delegate void PuntsIVidaPreguntaEventHandler(int punts,int vida);
    public partial class Pregunta : UserControl
    {
        
         public enum TipusOperació
        {
            Suma,Resta,Multiplicació,Divisió
        }

        Panel pnlOperacio;
        Panel pnlPista;

        Operació.Dificultat dificultatExercici;

        bool esTreuPistaFentClic;
        int punts;
        int temps;

        private bool esPosaASobreOnMouseHover;
        protected static Random llavor = new Random();
        public event UsuariValidaRespostaEventHandler UsuariValidaResposta;
        public event RespostaCorrectaEventHandler RespostaCorrecte;
        public event PuntsIVidaPreguntaEventHandler PuntsIVida;
        public Pregunta()
        {
            InitializeComponent();
            pnlOperacio = new Panel();
            pnlPista = new Panel();
            Controls.Add(pnlPista);
            Controls.Add(pnlOperacio);
            pnlOperacio.Dock = DockStyle.Fill;
            pnlPista.Dock = DockStyle.Fill;
            pnlPista.BringToFront();
            esTreuPistaFentClic = false;
            pnlOperacio.Visible = false;
            

          
        }


        #region Propietats
        [Category("Pregunta"), Description("Estableix la dificultat de l'exercici")]
        public Operació.Dificultat DificultatExercici
        {
            get { return dificultatExercici; }
            set { if (value != dificultatExercici) { dificultatExercici = value; PosaPregunta(); } }
        }
        [Category("Pregunta"), Description("Estableix si es veu la operacio, fent que la pista no es vegi")]
        public bool EsVeuOperació
        {
            get { return pnlOperacio.Visible; }
            set
            {
                if (value != pnlOperacio.Visible)
                {
                    pnlPista.Visible = !value;
                    pnlOperacio.Visible = value;
                }
            }
        }

        [Category("Pregunta"), Description("Estableix si es treu la pista fent clic")]
        public bool TreurePistaFentClic
        {
            get { return esTreuPistaFentClic; }
            set {
                if (esTreuPistaFentClic != value)
                {
                    if (esTreuPistaFentClic)
                        pnlPista.Click -= clicTreuPista;
                    else
                        pnlPista.Click += new EventHandler(clicTreuPista);
                    esTreuPistaFentClic = value;
                }
            }
        }
        [Category("Pregunta"), Description("Estableix si al pasar el mouse per sobre es vingui al primer pla")]
        public bool PosarASobreOnMouseHover
        {
            get { return esPosaASobreOnMouseHover; }
            set
            {
                if (esPosaASobreOnMouseHover != value)
                {
                    if (esPosaASobreOnMouseHover)
                        pnlPista.MouseHover -= posarASobreEvent;
                    else
                        pnlPista.MouseHover += new EventHandler(posarASobreEvent);
                    esPosaASobreOnMouseHover = value;
                }
            }
        }

        [Category("Pregunta"), Description("Punts que s'obtenen de l'exercici")]
        public int Punts
        {
            get { return punts; }
            protected set { punts = value; }
        }

        [Category("Pregunta"), Description("Temps per fer l'exercici")]
        public int Temps
        {
            get { return temps; }
            protected set { temps = value; }
        }
        [Category("Pregunta"), Description("Diu si esta o no bé la resposta donada")]
        public bool EstaBé
        {
            get { return EstaBéLaResposta(); }

        }
        [Category("Pregunta"), Description("Diu el tipus que es")]
        public Pregunta.TipusOperació Tipus
        {
            get {
                string tipus=ToString().Split('.')[1];
                if (tipus.Contains(']'))
                    tipus = tipus.Substring(0, tipus.Length - 1);
                return (TipusOperació)Enum.Parse(typeof(TipusOperació),tipus ); }
        }

        protected Panel PnlPista
        {
            get { return pnlPista; }
        }
        protected Panel PnlOperacio
        {
            get { return pnlOperacio; }

        }
        #endregion

        private void clicTreuPista(object sender, EventArgs e)
        {
            pnlPista.Visible = false;
            pnlOperacio.Visible = true;
        }
        private void posarASobreEvent(object sender, EventArgs e)
        {
            BringToFront();
        }

        protected void ValidaExercici()
        {

            if (EstaBé)
            {
                if (RespostaCorrecte != null)
                    RespostaCorrecte();
            }
            else
                if (UsuariValidaResposta != null)
                    UsuariValidaResposta();
        }

        public static Pregunta DonamPregunta(Pregunta.TipusOperació tipus)
        {
            Type tipusOperació = Type.GetType("Operacions." + tipus);
            return  Activator.CreateInstance(tipusOperació) as Pregunta;
        }
        #region Herencia
        public virtual void MostraResultatCorrecte()
        { }
        public virtual void PosaPregunta()
        { }
        protected virtual void CalculaResultat() { }
        protected virtual bool EstaBéLaResposta()
        {
            return false;
        }
        #endregion
    }
}
