using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ejercicios09Punto01.BL;
using Ejercicios09Punto01.DL;

namespace Ejercicios09Punto01.Windows
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }


        private RepositorioDeCuadrados repositorio;
        private List<Cuadrado> lista;
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            repositorio=new RepositorioDeCuadrados();
            if (repositorio.GetCantidad()==0)
            {
                MessageBox.Show("No se agregaron cuadrados todavía", "Mensaje",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                lista = repositorio.GetLista();
                MostrarDatosEnGrilla();
            }
            
        }

        private void MostrarDatosEnGrilla()
        {
            DatosDataGridView.Rows.Clear();//limpia los filas de la grilla
            foreach (var cuadrado in lista)
            {
                //Crear una fila con el formato de la grilla
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, cuadrado);//Voy a poner los datos del cuadrado en la fila
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Cuadrado cuadrado)
        {
            /*Lleno las celdas de la fila con los datos
             pertinentes del objeto en cuestión y con los
            resultados que arrojen los métodos imbocados*/
            r.Cells[cmnLado.Index].Value = cuadrado.Lado;
            r.Cells[cmnPerimetro.Index].Value = cuadrado.GetPerimetro();
            r.Cells[cmnSuperficie.Index].Value = cuadrado.GetSuperficie();


        }

        private DataGridViewRow ConstruirFila()
        {
            //Método que devuelve la fila con sus divisiones
            DataGridViewRow r=new DataGridViewRow();//Creo la fila
            r.CreateCells(DatosDataGridView);//Crea las divisiones de la fila según el formato de la grilla
            return r;
        }

        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            FrmCuadradosAE frm=new FrmCuadradosAE();//Creo un form nuevo para ingresar datos del cuadrado
            frm.Text = "Agregar nuevo Cuadrado";//Muestra el texto en la barra de título del form
            DialogResult dr=frm.ShowDialog(this);
            
        }

        private void SalirToolStripButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
