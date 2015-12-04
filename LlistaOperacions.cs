using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Operacions
{
    public partial class LlistaOperacions : UserControl,IEnumerable<Operació>
    {
        Stack<Operació> operacions;
        Operació centinela;
        public LlistaOperacions()
        {
            InitializeComponent();
            operacions = new Stack<Operació>();
            operacions.Push(new Operació());
            centinela = operacions.Peek();
            centinela.Location=new Point(0,Height+Height/10);
            AutoScroll = true;
         }
        public bool HiHaEspai
        {
            get { return operacions.Peek().Location.Y - (Height / 10) > 0; }
        }
        public void Afegir(Operació operacio)
        {
            Controls.Add(operacio);
            operacions.Push(operacio);
            operacio.Height = Height / 10;
            if (!HiHaEspai)
                FesEspai();
            operacio.Location = new Point(0, operacions.Peek().Location.Y - operacio.Height-Separació);
          
        }

        private void FesEspai()
        {
            foreach (Operació op in operacions)
                op.Location = new Point(0, op.Location.Y + Height / 10+Separació);
        }
        public int Separació 
        {
            get { return Height / 40; }
        }

        protected override void OnResize(EventArgs e)
        {
            centinela.Height = Height / 10;
            Width = centinela.Width+centinela.Width/4;
            Stack<Operació> operacionsAux = new Stack<Operació>();
            Stack<Operació> opPosades=new Stack<Operació>();
            foreach (Operació operació in operacions)
                operacionsAux.Push(operació);
            opPosades.Push(operacionsAux.Pop());
            if(operacions.Count<10)
            centinela.Location=new Point(0,Height+Height/10+Separació);
            else
            centinela.Location=new Point(0,Height+((Height/10+Separació)*(operacions.Count-9)));
            foreach (Operació operació in operacionsAux)
            {
                operació.Height = Height / 10;
                operació.Location = new Point(0, opPosades.Peek().Location.Y - Height / 10-Separació);
                opPosades.Push(operació);
            }
        }


        public IEnumerator<Operació> GetEnumerator()
        {
            return operacions.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        
    }
}
