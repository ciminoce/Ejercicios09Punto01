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

            r.Tag = cuadrado;//Reservo el cuadrado en la prop. tag de la fila

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
            if (dr==DialogResult.OK)
            {
                //Obtengo el cuadrado del otro form
                Cuadrado cuadrado = frm.GetCuadrado();
                //le digo al repositorio que lo agregue
                repositorio.Agregar(cuadrado);
                //Creo una nueva fila para mostrar los datos del nuevo cuadrado
                var gridRow = ConstruirFila();
                //Seteo los datos a mostrar
                SetearFila(gridRow,cuadrado);
                //Agrego la fila al grid
                AgregarFila(gridRow);

            }
            
        }

        private void SalirToolStripButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
            /* Saco un mensaje pidiendo
             la confirmación del borrado de la fila seleccionada*/
            DialogResult dr = MessageBox.Show("¿Desea dar de baja la fila seleccionada?",
                "Confirmar Baja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            /*Si presionaron que si, borro la fila que se marcó*/
            if (dr==DialogResult.Yes)
            {
                /*De la colección SelectedRows obtengo el índice (index)
                 del único elemento que puede contener
                ya que en tiempo de diseño establecí que 
                únicamente se puede seleccionar una fila por vez */
                var iFila = DatosDataGridView.SelectedRows[0].Index;
                /*Luego tomo el índice de la fila a borrar y se lo páso
                 al método RemoveAt de la colección Rows de la grilla
                para que borre la fila seleccionada*/
                DatosDataGridView.Rows.RemoveAt(iFila);

            }            
        }

        private void EditarToolStripButton_Click(object sender, EventArgs e)
        {
            /*Controlo que se haya seleccionado una fila */
            if (DatosDataGridView.SelectedRows.Count>0)
            {

                //Obtengo la fila seleccionada
                var r = DatosDataGridView.SelectedRows[0];
                //Obtengo el objeto que contiene la prop. tag de la fila
                Cuadrado cuadrado =(Cuadrado) r.Tag;
                //Creo el form para poder editar el cuadrado
                FrmCuadradosAE frm=new FrmCuadradosAE();
                frm.Text = "Editar un cuadrado";
                //Tengo que pasar el cuadrado al formulario para editarlo
                frm.SetCuadrado(cuadrado);
                DialogResult dr = frm.ShowDialog(this);
                if (dr==DialogResult.OK)
                {
                    cuadrado = frm.GetCuadrado();
                    SetearFila(r,cuadrado);

                }
            }
        }
    }
}
