using System;

namespace Ejercicios09Punto01.BL
{
    public class Cuadrado
    {
        private int lado;

        public int Lado
        {
            get { return lado; }
            set{lado = value;}
        }
        #region Constructores
        public Cuadrado()
        {
            
        }

        public Cuadrado(int valorLado)
        {
            Lado = valorLado;
        }
        #endregion

        #region Metodos

        public int GetPerimetro()
        {
            return Lado * 4;
        }

        public double GetSuperficie()
        {
            return Math.Pow(Lado, 2);
        }
        #endregion
    }
}
