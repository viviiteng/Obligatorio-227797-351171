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
        #endregion

        #region Metodos

        #endregion
    }
}
