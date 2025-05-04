using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Avion
    {
        #region Atributo
        public string Fabricante { get; set; }
        public string Modelo { get; set; }
        public int CantAsientos { get; set; }
        public double Alcance { get; set; }
        public double CostoOperacionPorKm { get; set; }
        #endregion

        #region Constructor
        public Avion() { 
            
        }
        public Avion(string fabricante, string modelo, int cantAsientos, double alcance, double costoOperacion)
        {
            this.Fabricante = fabricante;
            this.Modelo = modelo;
            this.CantAsientos = cantAsientos;
            this.Alcance = alcance; 
            this.CostoOperacionPorKm = costoOperacion;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return $"Fabricante: {this.Fabricante}, Modelo: {this.Modelo}, Cantidad de asientos: {this.CantAsientos}, Alcance: {this.Alcance}, Costo de operacion: {this.CostoOperacionPorKm}. "; 
        }

        public void ValidarAvion()
        {

        }

        public override bool Equals(object? obj)
        {
            Avion otro = (Avion)obj;
            return this.Fabricante.ToUpper() == otro.Fabricante.ToUpper()
            && this.Modelo.ToUpper() == otro.Modelo.ToUpper()
            && this.CantAsientos == otro.CantAsientos
            && this.Alcance == otro.Alcance;
        }
        #endregion
    }
}
