using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public abstract class Cliente : Usuario
    {
        #region Atributo
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }
        #endregion

        #region Constructor
        public Cliente() { }
        public Cliente (string cedula, string nombre, string correo, string pass, string nacionalidad) : base(correo, pass)
        {
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Nacionalidad = nacionalidad;
        }

        #endregion

        #region Metodos

        public abstract string ObtenerDatosCliente();

        #endregion
    }
}
