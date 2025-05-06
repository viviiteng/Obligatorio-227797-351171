using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.interfaces;

namespace Dominio
{
    public class Avion :  IValidable
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
        public void Validar()
        {
            if (this.Fabricante == "" || this.Modelo == "" || this.CantAsientos < 0 || this.Alcance < 0 || this.CostoOperacionPorKm < 0)
            {
                throw new Exception("Error al validar los datos del avion.");
            }        
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
