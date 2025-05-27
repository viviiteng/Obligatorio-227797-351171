using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class Vuelo : IValidable
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
        

        public void Validar()
        {
            validarContenido();
            validarNumVuelo();
            validarAlcanceDelAvion();            
        }
        private void validarContenido()
        {
            if (this.Ruta == null || this.Avion == null || this.frecuencias.Count < 0)
            {
                throw new Exception("Error al validar los datos del Vuelo.");
            }
        }
        private void validarNumVuelo()
        {
            validarCantDigitos();

            int contadorLetra = 0;
            int contadorNumero = 0;

            for (int i = 0; i < this.NumVuelo.Length; i++)
            {
                char digito = this.NumVuelo[i];
                if (contarLetra(digito))
                {
                    contadorLetra++;
                }
                if (contarNumero(digito))
                {
                    contadorNumero++;
                }
            }

            if (contadorLetra != 2)
            {
                throw new Exception("Error: El número de vuelo es incorrecto. Tiene que tener 2 letras.");
            }
            if (contadorNumero < 1 && contadorNumero > 4)
            {
                throw new Exception("Error: El número de vuelo es incorrecto. Tiene que tener entre 1 y 4 números.");
            }
        } 
        private void validarCantDigitos()
        {
            if (this.NumVuelo.Length < 3 && this.NumVuelo.Length > 7)
            {
                throw new Exception("Error: La cantidad de digitos tiene que ser de 3 a 7 digitos");
            }
        }
        public static bool contarLetra(char letra)
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
        public static bool contarNumero(char numero)
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
                throw new Exception("Error: El alance del avion no es suficiente para cubrir la distancia de ruta.");
            }
        }
        public double CalcularCostaPorAsiento()
        {
            return (this.Avion.CostoOperacionPorKm * this.Ruta.Distancia + this.Ruta.AeropuertoSalida.CostoOperacion + this.Ruta.AeropuertoLlegada.CostoOperacion) / this.Avion.CantAsientos;
        }
        public override bool Equals(object? obj)
        {
            Vuelo otro = (Vuelo)obj;
            return this.NumVuelo == otro.NumVuelo;
        }
        public override string ToString()
        {
            string frencuencia = "";
            foreach (Frecuencia dia in this.frecuencias)
            {
                frencuencia += $"{dia} ";
            }
            return $"Numero de Vuelo: {this.NumVuelo}, Avion: {this.Avion.Modelo}, Ruta: {this.Ruta.AeropuertoSalida.CodigoIATA}-{this.Ruta.AeropuertoLlegada.CodigoIATA}, Frecuencia: {frencuencia}";
        }
        #endregion
    }
}
