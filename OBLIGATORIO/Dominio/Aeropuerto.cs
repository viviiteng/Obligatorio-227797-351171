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

        public bool ValidarCodigoIATA()
        {
            bool esCodigo = false;
            if (this.CodigoIATA.Length == 3)
            {
                esCodigo = true;
            }

            return esCodigo ;
            
        }
        #endregion
    }
}
