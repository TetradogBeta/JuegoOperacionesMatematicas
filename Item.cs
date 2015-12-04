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
    partial class Item : UserControl
    {
        
        public Item()
        {
            InitializeComponent();
        }
        public virtual void RealizaFunció(Fitxa fitxa)
        { }
    }
}
