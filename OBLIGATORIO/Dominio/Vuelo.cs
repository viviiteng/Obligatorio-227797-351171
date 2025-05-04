using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class Vuelo
    {
        #region Atributo
        public string NumVuelo { get; set; }
        public Ruta Ruta { get; set; }
        public Avion Avion { get; set; }
        public List <Frecuencia> frecuencias { get; set; }
        #endregion

        #region Constructor
        public Vuelo() { }

        public Vuelo(string numVuelo, Ruta ruta, Avion avion, List<Frecuencia> frecuencias) { 
            this.NumVuelo = numVuelo;
            this.Ruta = ruta;
            this.Avion = avion;
            this.frecuencias = frecuencias;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            string frencuencia = "";
            foreach (Frecuencia dia in this.frecuencias)
            {
                frencuencia  += $"{dia} ";
            }
            return $"Numero de Vuelo: {this.NumVuelo}, Avion: {this.Avion.Modelo}, Ruta: {this.Ruta.AeropuertoSalida.CodigoIATA}-{this.Ruta.AeropuertoLlegada.CodigoIATA}, Frecuencia: {frencuencia}";
        }

        public void ValidarVuelo()
        {
            validarNumVuelo();
            validarAlcanceDelAvion();            
        }

        private void validarNumVuelo()
        {
            validarCantDigitos();

            int contadorLetra = 0;
            int contadorNumero = 0;

            for (int i = 0; i < this.NumVuelo.Length; i++)
            {
                char digito = this.NumVuelo[i];
                if (encontrarLetra(digito))
                {
                    contadorLetra++;
                }
                if (encontrarNumero(digito))
                {
                    contadorNumero++;
                }
            }

            if (contadorLetra != 2)
            {
                throw new Exception("El número de vuelo es incorrecto. Tiene que tener 2 letras.");
            }
            if (contadorNumero < 1 && contadorNumero > 4)
            {
                throw new Exception("El número de vuelo es incorrecto. Tiene que tener entre 1 y 4 números.");
            }
        } 
        private void validarCantDigitos()
        {
            if (this.NumVuelo.Length < 3 && this.NumVuelo.Length > 7)
            {
                throw new Exception("La cantidad de digitos tiene que ser de 3 a 7 digitos");
            }
        }
        private bool encontrarLetra(char letra)
        {
            string abecedario = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0;i < abecedario.Length; i++)
            {
                if (letra == abecedario[i])
                {
                    return true;
                }
            }
            return false;
        }

        private bool encontrarNumero(char numero)
        {
            string numeros = "0123456789";
            for (int i = 0; i < numeros.Length; i++)
            {
                if (numero == numeros[i])
                {
                    return true;
                }
            }
            return false;
        }
        private void validarAlcanceDelAvion()
        {
            if(this.Ruta.Distancia > this.Avion.Alcance)
            {
                throw new Exception("El alance del avion no es suficiente para cubrir la distancia de ruta.");
            }
        }

        public double CalcularCostaPorAsiento()
        {
        return (this.Avion.CostoOperacionPorKm * this.Ruta.Distancia + this.Ruta.AeropuertoSalida.CostoOperacion + this.Ruta.AeropuertoLlegada.CostoOperacion) / this.Avion.CantAsientos;
        }
        #endregion
    }
}
