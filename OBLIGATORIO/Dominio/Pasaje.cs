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
        public Usuario Pasajero { get; set; }
        public TipoEquipaje Equipaje { get; set; }
        public double PrecioPasaje { get; set; }
        #endregion

        #region Constructor
        public Pasaje()
        {

        }
        public Pasaje(Vuelo vuelo, DateTime fechaDeVuelo, Usuario pasajero, TipoEquipaje equipaje, double precioPasaje)
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

        public void ValidarPasaje()
        {
            validarFecha();
            validarAtributos();
        }

        private void validarAtributos()
        {
            if (this.Vuelo==null || this.Pasajero==null || this.PrecioPasaje<0)
            {
                throw new Exception("Las secciones no pueden quedar vacias");
            }
        }
        private void validarFecha()
        {
            int diaVuelo = (int)this.FechaDeVuelo.DayOfWeek;
            bool coincide = false;
            for (int i = 0; i<this.Vuelo.frecuencias.Count; i++)
            {
                
                if (diaVuelo == (int)this.Vuelo.frecuencias[i]) 
                {
                    coincide = true;
                }
            }
            if(!coincide)
            {
                throw new Exception("El dia de la fecha del pasaje no coincide con la frecuencia del vuelo");
            }
        }
        public override bool Equals(object? obj)
        {
            Pasaje otro = (Pasaje)obj;
            return this.IdPasaje == otro.IdPasaje;
        }
        public override string ToString()
        {
            return $"Id del Pasaje: {this.IdPasaje}, Pasajero: {this.Pasajero}, Precio del pasaje: {this.PrecioPasaje}, Fecha del vuelo: {this.FechaDeVuelo.ToString("dd/MM/yyyy")}, Vuelo: {this.Vuelo.NumVuelo}. ";
        }
        #endregion
    }
}
