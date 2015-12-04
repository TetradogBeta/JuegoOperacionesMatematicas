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
    partial class NumerosUpDown : NumericUpDown
    {
        public NumerosUpDown()
        {
            InitializeComponent();
           
           
        }
        protected override void OnTextBoxTextChanged(object source, EventArgs e)
        {
            TextBox text = source as TextBox;
            if (text != null)
                if (text.Text.Contains('.'))
                {
                    text.Text = text.Text.Replace('.', ',');
                    text.SelectionStart = text.Text.Length;
                }
            base.OnTextBoxTextChanged(source, e);
        }
    }
}
