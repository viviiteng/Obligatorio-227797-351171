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
        public List <Frecuencia> frecuencias { get; set; }
        #endregion

        #region Constructor
        public Vuelo() { }

        public Vuelo(string numVuelo, Ruta ruta, Avion avion, List<Frecuencia> frecuencias) { 
            this.NumVuelo = numVuelo;
            this.Ruta = ruta;
            this.Avion = avion;
            this.frecuencias = frecuencias;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            string frencuencia = "";
            foreach (Frecuencia dia in this.frecuencias)
            {
                frencuencia  += $"{dia} ";
            }
            return $"Numero de Vuelo: {this.NumVuelo}, Avion: {this.Avion.Modelo}, Ruta: {this.Ruta.AeropuertoSalida.CodigoIATA}-{this.Ruta.AeropuertoLlegada.CodigoIATA}, Frecuencia: {frencuencia}";
        }

        public void ValidarAlcanceDelAvion()
        {
            if(this.Ruta.Distancia > this.Avion.Alcance)
            {
                throw new Exception("El alance del avion no es suficiente para cubrir la distancia de ruta.");
            }
        }
        #endregion
    }
}
