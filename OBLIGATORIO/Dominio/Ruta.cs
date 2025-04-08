using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Ruta
    {
        #region Atributo
        public int IdRuta { get; set; }
        public static int UltimoIdRuta { get; set; }
        public Aeropuerto AeropuertoSalida { get; set; }
        public Aeropuerto AeropuertoLlegada { get; set; }
        public double Distancia { get; set; }
        #endregion

        #region Constructor
        public Ruta() { }

        public Ruta(Aeropuerto aeropuertoSalida, Aeropuerto aeropuertoLlegada,double distanicia)
        {
            this.IdRuta = UltimoIdRuta++;
            this.AeropuertoSalida = aeropuertoSalida;
            this.AeropuertoLlegada = aeropuertoLlegada;
            this.Distancia = distanicia;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return $"Id: {this.IdRuta}, Aeropuerto de salida: {this.AeropuertoSalida}, Aeropuerto de llegada: {this.AeropuertoLlegada}, Distancia: {this.Distancia}. ";
        }
        #endregion
    }
}
