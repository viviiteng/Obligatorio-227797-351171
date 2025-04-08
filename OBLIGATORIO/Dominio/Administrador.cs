using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administrador
    {
        #region Atributo
        public string Apodo { get; set; }
        public string Correo { get; set; }
        public string Pass { get; set; }
        #endregion

        #region Constructor

        public Administrador() { }
        public Administrador(string apodo, string correo, string pass) {
            this.Apodo = apodo;
            this.Correo = correo;   
            this.Pass = pass;
        }
        #endregion

        #region Metodos

        public override string ToString()
        {
            return $"Apodo: {this.Apodo}, Correo: {this.Correo}, Contrasena: {this.Pass}";
            
        }

        #endregion

    }
}
