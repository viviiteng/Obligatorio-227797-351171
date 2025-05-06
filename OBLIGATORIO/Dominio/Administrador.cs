using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administrador : Usuario
    {
        #region Atributo
        public string Apodo { get; set; }
        #endregion

        #region Constructor

        public Administrador() { }
        public Administrador(string apodo, string correo, string pass) : base (correo, pass){
            this.Apodo = apodo;
        }
        #endregion

        #region Metodos
        public override void Validar()
        {
            if (this.Correo == "" || this.Pass == "" || this.Apodo=="")
            {
                throw new Exception("Los valores para cada atributo del administrador no pueden estar vacios");
            }
        }

        public override string ObtenerDatosUsuario()
        {
            return $"Apodo: {this.Apodo}, Correo: {this.Correo}, Contrasena {this.Pass}.";
        }

        #endregion

    }
}
