using System.Collections.Generic;
using Ejercicios09Punto01.BL;

namespace Ejercicios09Punto01.DL
{
    public class RepositorioDeCuadrados
    {
        public List<Cuadrado> listaCuadrados { get; set; }=new List<Cuadrado>();

        public RepositorioDeCuadrados()
        {
            listaCuadrados.Add(new Cuadrado(10));
            listaCuadrados.Add(new Cuadrado(7));
            listaCuadrados.Add(new Cuadrado(14));
            listaCuadrados.Add(new Cuadrado(3));
            listaCuadrados.Add(new Cuadrado(15));
            listaCuadrados.Add(new Cuadrado(11));

        }

        public void Agregar(Cuadrado cuadrado)
        {
            listaCuadrados.Add(cuadrado);
        }

        public void Modificar(Cuadrado cuadrado)
        {

        }

        public void Borrar(Cuadrado cuadrado)
        {
            listaCuadrados.Remove(cuadrado);
        }
        public List<Cuadrado> GetLista()
        {
            return listaCuadrados;
        }

        public int GetCantidad()
        {
            return listaCuadrados.Count;
        }
    }
}
