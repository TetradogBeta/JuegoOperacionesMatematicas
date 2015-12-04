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
    partial class Resta : OperacionsAmbDosFiles
    {
            public Resta()
        {
            InitializeComponent();
            Signe = "-";
            CalculaOperació();
            Pista = "Es una resta";
        }
        protected override void CalculaResultat()
        {
            ResultatOperació = NumeroLinea1 - NumeroLinea2;
            if (NumeroLinea1.ToString().Length > NumeroLinea2.ToString().Length)
            {
                Temps = NumeroLinea1.ToString().Length * 3;
            }
            else
                Temps = NumeroLinea2.ToString().Length * 3;
            if (DificultatExercici < Operació.Dificultat.normal)
                Temps *= 2;
            if (DificultatExercici.Equals(Operació.Dificultat.moltDificil))
                Temps /= 2;

        }
    
    }
}
