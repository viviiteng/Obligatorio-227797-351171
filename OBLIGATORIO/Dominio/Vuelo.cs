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
        public Frecuencia Frecuencia { get; set; }
        public string Nacionalidad { get; set; }
        public string TipoDeCliente { get; set; }
        #endregion

        #region Constructor
        public Vuelo() { }

        public Vuelo(string numVuelo, Ruta ruta, Avion avion, Frecuencia frecuencia, string nacionalidad, string tipoDeCliente) { 
            this.NumVuelo = numVuelo;
            this.Ruta = ruta;
            this.Avion = avion;
            this.Frecuencia = frecuencia;
            this.Nacionalidad = nacionalidad;
            this.TipoDeCliente = tipoDeCliente;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return $"Numero de Vuelo: {this.NumVuelo}, Ruta: {this.Ruta}, Avion: {this.Avion}, Frecuencia: {this.Frecuencia}, Nacionalidad: {this.Nacionalidad} y Tipo de cliente: {this.TipoDeCliente} ";
        }
        #endregion
    }
}
