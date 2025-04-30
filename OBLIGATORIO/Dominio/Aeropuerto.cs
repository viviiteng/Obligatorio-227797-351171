using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Aeropuerto
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
        public override string ToString()
        {
            return $"Codigo IATA: {this.CodigoIATA}, Ciudad: {this.Ciudad}, Costo de operacion: {this.CostoOperacion}, Costo de tasas: {this.CostoTasas}.";
        }

        public void ValidarAeropuerto()
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
            if (this.Ciudad=="" && this.CodigoIATA=="")
            {
                throw new Exception("Las secciones no pueden quedar vacios");
            }
        }
        #endregion
    }
}
