using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Dominio
{
    public class Pasaje
    {
        #region Atributo
        public int IdPasaje { get; set; }
        public static int UltimoIdPasaje { get; set; }
        public Vuelo Vuelo { get; set; }
        public DateTime FechaDeVuelo { get; set; }
        public Cliente Pasajero { get; set; }
        public TipoEquipaje Equipaje { get; set; }
        public double PrecioPasaje { get; set; }
        #endregion

        #region Constructor
        public Pasaje()
        {

        }
        public Pasaje(Vuelo vuelo, DateTime fechaDeVuelo, Cliente pasajero, TipoEquipaje equipaje, double precioPasaje)
        {
            this.IdPasaje = UltimoIdPasaje++;
            this.Vuelo = vuelo;
            this.FechaDeVuelo = fechaDeVuelo;
            this.Pasajero = pasajero;
            this.Equipaje = equipaje;
            this.PrecioPasaje = precioPasaje;
        }
        #endregion

        #region Metodos

        public void ValidarFecha()
        {

        }
        public override string ToString()
        {
            return $"Id del Pasaje: {this.IdPasaje}, Pasajero: {this.Pasajero.Nombre}, Precio del pasaje: {this.PrecioPasaje}, Fecha del vuelo: {this.FechaDeVuelo.ToString("dd/MM/yyyy")}, Vuelo: {this.Vuelo.NumVuelo}. ";
        }
        #endregion
    }
}
