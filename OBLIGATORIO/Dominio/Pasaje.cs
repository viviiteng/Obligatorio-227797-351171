using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.comparer;
using Dominio.interfaces;
using Microsoft.VisualBasic;

namespace Dominio
{
    public class Pasaje : IValidable, IComparable<Pasaje>
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
            this.IdPasaje = UltimoIdPasaje++;
            this.PrecioPasaje = calcularPrecioPasaje(); 
        }
        public Pasaje(Vuelo vuelo, DateTime fechaDeVuelo, Cliente pasajero, TipoEquipaje equipaje)
        {
            this.IdPasaje = UltimoIdPasaje++;
            this.Vuelo = vuelo;
            this.FechaDeVuelo = fechaDeVuelo;
            this.Pasajero = pasajero;
            this.Equipaje = equipaje;
            this.PrecioPasaje = calcularPrecioPasaje();
        }
        #endregion

        #region Metodos

        public void Validar()
        {
            validarFecha();
            validarContenido();
            validarEquipaje();
        }
        private void validarContenido()
        {
            if (this.Vuelo == null || this.Pasajero == null)
            {
                throw new Exception("Error al validar los datos del pasaje.");
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
                throw new Exception("Error: El dia de la fecha del pasaje no coincide con la frecuencia del vuelo");
            }
        }
        private void validarEquipaje()
        {
            if (this.Equipaje == 0)
            {
                throw new Exception("Error: Debe ingresar el tipo de equipaje deseado.");
            }
        }
        private double calcularPrecioPasaje()
        {
            double precioPasaje;
            precioPasaje = (this.Vuelo.CalcularCostoPorAsiento() * (1.0 + (25.0 + this.Pasajero.CalcularRecargoPorEquipaje(this.Equipaje)) / 100.0)) + this.Vuelo.Ruta.AeropuertoSalida.CostoTasas + this.Vuelo.Ruta.AeropuertoLlegada.CostoTasas;
            return Math.Round(precioPasaje,2);
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

        public int CompareTo(Pasaje? unPasaje)
        {
            if (this.FechaDeVuelo.CompareTo(unPasaje.FechaDeVuelo) == 0)
            {
                return this.IdPasaje.CompareTo(unPasaje.IdPasaje);
            }
            return this.FechaDeVuelo.CompareTo(unPasaje.FechaDeVuelo);
        }

        #endregion
    }
}
