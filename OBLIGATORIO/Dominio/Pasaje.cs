using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pasaje
    {
        #region Atributo
        public int IdPasaje { get; set; }
        public int UltimoIdPasaje { get; set; }
        public Vuelo Vuelo { get; set; }
        public DateTime FechaDeVuelo { get; set; }
        public Cliente Pasajero { get; set; }
        //public Equipaje Equipaje { get; set; }
        public double PrecioPasaje { get; set; }
        #endregion

        #region Constructor
        public Pasaje()
        {

        }
        public Pasaje(Vuelo vuelo, DateTime fechaDeVuelo, Cliente pasajero, double precioPasaje)
        {
            this.IdPasaje = UltimoIdPasaje++;
            this.Vuelo = vuelo;
            this.FechaDeVuelo = fechaDeVuelo;
            this.Pasajero = pasajero;
            this.PrecioPasaje = precioPasaje;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return $"Id del Pasaje: {this.IdPasaje}, Vuelo: {this.Vuelo}, Fecha del vuelo: {this.FechaDeVuelo}, Pasajero: {this.Pasajero} y Precio del pasaje: {this.PrecioPasaje} ";
        }
        #endregion
    }
}
