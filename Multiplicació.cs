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
    partial class Multiplicació : OperacionsAmbDosFiles
    {
        public Multiplicació()
        {
            InitializeComponent();
            Signe = "x";
            CalculaOperació();
            Pista = "Es una multiplicació";
            
        }
        protected override void CalculaResultat()
        {
            ResultatOperació = NumeroLinea1 * NumeroLinea2;
            int numFila1 = lblnum1.Text.Length;
            int numFila2 = lblnum2.Text.Length;
            decimal num1 = Convert.ToDecimal(lblnum1.Text);
            decimal num2 = Convert.ToDecimal(lblnum2.Text);
            int temps1 = numFila1 * numFila2 * 3;
            int temps2 = 0;
            if (numFila2 < numFila1)
                for (int i = 0; i < numFila2; i++)
                {
                    if(lblnum1.Text[i]!=',')
                    temps2 += (Convert.ToInt32(lblnum2.Text[i]) * num1).ToString().Length;
                }
            else
                for (int i = 0; i < numFila1; i++)
                {
                    if (lblnum2.Text[i] != ',')
                        temps2 += (Convert.ToInt32(lblnum1.Text[i]) * num2).ToString().Length;
                }
            temps2 *= 2;
            Temps= temps1 + temps2;

        
    }
    }
}
