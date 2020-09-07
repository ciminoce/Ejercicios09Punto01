using System;
using System.Windows.Forms;
using Ejercicios09Punto01.BL;

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

        private Cuadrado cuadrado;
        private void OkButton_Click(object sender, EventArgs e)
        {
            //Primero valido los datos
            if (ValidarDatos())
            {
                /*Pregunto no existe algún cuadrado
                 de no existir lo creo, esto pasa cuando agrego un nuevo cuadrado
                en el caso de la edición el cuadrado ya me lo pasan por lo tanto existe
                y no debo crear uno nuevo*/
                if (cuadrado==null)
                {
                    cuadrado = new Cuadrado();

                } 
                cuadrado.Lado = int.Parse(LadoTextBox.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();//borra algun mensaje de error preexistente
            if (!int.TryParse(LadoTextBox.Text, out int ladoResult))
            {
                valido = false;
                errorProvider1.SetError(LadoTextBox,"Lado mal ingresado");
            }else if (ladoResult<=0 ||ladoResult>100)
            {
                valido = false;
                errorProvider1.SetError(LadoTextBox,"Lado no válido debe estar comprendido entre 1 y 100");
            }

            return valido;
        }

        public Cuadrado GetCuadrado()
        {
            return cuadrado;
        }

        public void SetCuadrado(Cuadrado cuadrado1)
        {
            cuadrado = cuadrado1;
        }

        //Sobreescribo el método OnLoad
        //esto es cuando se cargar el form
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            /*Pregunto si existe algún cuadrado */
            if (cuadrado!=null)
            {
                /*de existir muesto sus datos en el textbox*/
                LadoTextBox.Text = cuadrado.Lado.ToString();//Paso a string el valor del lado y lo muestro
            }
        }
    }
}
