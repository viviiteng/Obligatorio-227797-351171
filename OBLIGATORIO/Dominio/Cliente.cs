using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente
    {
        #region Atributo
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Pass { get; set; }
        public string Nacionalidad { get; set; }
        #endregion

        #region Constructor
        public Cliente() { }
        public Cliente (string cedula, string nombre, string correo, string pass, string nacionalidad) 
        {
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Correo = correo;
            this.Pass = pass;
            this.Nacionalidad = nacionalidad;
        }

        #endregion

        #region Metodos
        public override string ToString()
        {
            return $"Cedula: {this.Cedula}, Nombre: {this.Nombre}, Correo: {this.Correo}, Password: {this.Pass}, Nacionalidad: {this.Nacionalidad},";
        }
        #endregion
    }
}
