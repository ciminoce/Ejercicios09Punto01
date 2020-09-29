using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ejercicios09Punto01.BL;

namespace Ejercicios09Punto01.DL
{
    public class RepositorioDeCuadrados
    {
        public List<Cuadrado> ListaCuadrados { get; set; }=new List<Cuadrado>();

        public RepositorioDeCuadrados()
        {
            //Cuando se instancia ejecuto el método leer del archivo
            LeerDatosDelArchivo();
        }

        public void LeerDatosDelArchivo()
        {
            var ruta = Directory.GetCurrentDirectory();//Me devuelve la ruta del directorio donde corre la app
            var archivo = "Cuadrados.CSV";//Pongo un nombre al archivo .CSV
            StreamReader lector=new StreamReader($"{ruta}\\{archivo}");//Defino un objeto para leer los datos del archivo
            //Leo mientras no sea fin del archivo
            while (!lector.EndOfStream)
            {
                var linea = lector.ReadLine();//Leo una linea
                Cuadrado cuadrado = ConstruirCuadrado(linea);//Construyo el cuadrado
                ListaCuadrados.Add(cuadrado);//lo agrego a la lista del repo
            }
            lector.Close();

        }

        private Cuadrado ConstruirCuadrado(string linea)
        {
            /*El método Split, separa el texto de acuerdo al caracter
             puesto entre comillas y los almacena en un array*/
            var campos = linea.Split(',');
            return new Cuadrado()
            {
                Lado = int.Parse(campos[0])//asigno el contenido del único campo al lado del cuadrado
            };
        }

        public void GuardarDatosEnArchivo()
        {
            var ruta = Directory.GetCurrentDirectory();//Me devuelve la ruta del directorio donde corre la app
            var archivo = "Cuadrados.CSV";//Pongo un nombre al archivo .CSV
            /*Defino un objeto de tipo streamwriter para escribir
             en el archivo los datos de los cuadrados que tiene el repositorio*/
            StreamWriter escritor=new StreamWriter($"{ruta}\\{archivo}");
            /*recorro la lista */
            foreach (var cuadrado in ListaCuadrados)
            {
                //Por cada cuadrado voy construyendo una línea con sus datos
                var lineaCsv = ConstruirLinea(cuadrado);
                //Escribo la linea en el archivo
                escritor.WriteLine(lineaCsv);
            }
            //Cierro el escritor
            escritor.Close();
        }

        private string ConstruirLinea(Cuadrado cuadrado)
        {
            return $"{cuadrado.Lado}";
            
        }

        public bool Existe(Cuadrado cuadrado)
        {
            return ListaCuadrados.Contains(cuadrado);
        }
        public void Agregar(Cuadrado cuadrado)
        {
            ListaCuadrados.Add(cuadrado);
        }

        public void Borrar(Cuadrado cuadrado)
        {
            ListaCuadrados.Remove(cuadrado);
        }
        public List<Cuadrado> GetLista()
        {
            return ListaCuadrados;
        }

        public int GetCantidad()
        {
            return ListaCuadrados.Count;
        }

        public List<Cuadrado> GetListaOrdenadaAscendente()
        {
            /*Retorno la lista ordenada por los lados de los cuadrados */
            return ListaCuadrados.OrderBy(c => c.Lado).ToList();
        }

        public List<Cuadrado> GetListaOrdenadaDescendente()
        {
            /*Retorno la lista ordenada descendentemente por los lados de los cuadrados */

            return ListaCuadrados.OrderByDescending(c => c.Lado).ToList();
        }

        public List<Cuadrado> GetListaFiltrada()
        {
            return ListaCuadrados.Where(c => c.Lado > 10).ToList();
        }
    }
}
