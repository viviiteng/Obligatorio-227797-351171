using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Vuelo
    {
        #region Atributo
        public string NumVuelo { get; set; }
        public Ruta Ruta { get; set; }
        public Avion Avion { get; set; }
        public Frecuencia[] Frecuencia { get; set; }
        #endregion

        #region Constructor
        public Vuelo() { }

        public Vuelo(string numVuelo, Ruta ruta, Avion avion, Frecuencia[] frecuencia) { 
            this.NumVuelo = numVuelo;
            this.Ruta = ruta;
            this.Avion = avion;
            this.Frecuencia = frecuencia;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return $"Numero de Vuelo: {this.NumVuelo}, Ruta: {this.Ruta}, Avion: {this.Avion} y Frecuencia: {this.Frecuencia}";
        }
        #endregion
    }
}
