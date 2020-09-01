using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ejercicios09Punto01.Windows
{
    public partial class FrmCuadradosAE : Form
    {
        public FrmCuadradosAE()
        {
            InitializeComponent();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            /* Devuelvo un valor de tipo DialogResult.Cancel
             esto es cancelando el ingreso de datos*/
            DialogResult = DialogResult.Cancel;
        }
    }
}
