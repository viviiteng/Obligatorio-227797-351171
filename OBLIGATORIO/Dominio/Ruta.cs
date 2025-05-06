using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.interfaces;

namespace Dominio
{
    public class Ruta : IValidable
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
        public void Validar()
        {
            if (this.AeropuertoLlegada == null || this.AeropuertoSalida == null || this.Distancia < 0 )
            {
                throw new Exception("Error al validar los datos de la ruta.");
            }
        }
        public override bool Equals(object? obj)
        {
            Ruta otro = (Ruta)obj;
            return this.IdRuta == otro.IdRuta;
        }
        #endregion
    }
}
