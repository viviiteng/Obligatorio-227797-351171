using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.interfaces;

namespace Dominio
{
    public class Aeropuerto : IValidable
    {
        #region Atributo
        public string CodigoIATA { get; set; }
        public string Ciudad { get; set; }
        public double CostoOperacion { get; set; }
        public double CostoTasas { get; set; }
        #endregion

        #region Constructor 
        public Aeropuerto() { }
        public Aeropuerto(string codigoIATA, string ciudad, double costoOperacion, double costoTasas) 
        {
            this.CodigoIATA = codigoIATA;
            this.Ciudad = ciudad;
            this.CostoOperacion = costoOperacion;
            this.CostoTasas = costoTasas;
        }
        #endregion

        #region Metodos
        

        public void Validar()
        {
            validarCodigoIATA();
            validarContenido();
        }
        private void validarCodigoIATA()
        {
            validarCantLetras();

            foreach (char digito in this.CodigoIATA)
            {
                if (!esLetra(digito))
                {
                    throw new Exception("Los tres digitos tienen que ser Letras");
                }
            }
        }
        private void validarCantLetras()
        {           
            if (this.CodigoIATA.Length != 3)
            {
                throw new Exception("Codigo IATA ingresado no cumple con el formato de 3 letras");
            }
        }

        private bool esLetra(char digito)
        {
            string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            foreach (char letra in letras)
            {
                if (letra==digito)
                {
                    return true;
                }
            }
            return false;
        }

        private void validarContenido()
        {
            if (this.Ciudad=="" || this.CodigoIATA=="" || this.CostoTasas<0 || this.CostoOperacion<0)
            {
                throw new Exception("Error al validar los datos del aeropuerto.");
            }
        }
        public override bool Equals(object? obj)
        {
            Aeropuerto otro = (Aeropuerto)obj;
            return this.CodigoIATA.ToUpper() == otro.CodigoIATA.ToUpper();
        }

        
        #endregion
    }
}
