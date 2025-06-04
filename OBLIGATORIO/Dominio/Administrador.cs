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
            base.Validar();
            if (this.Apodo=="") 
            {
                throw new Exception("Error: Debe rellenar todos los campos requeridos");
            }
        }

        public override string ObtenerDatosUsuario()
        {
            return $"Apodo: {this.Apodo}, Correo: {this.Correo}.";
        }

        public void ModificarDatosCliente(Cliente unCliente)
        {
            if (unCliente is ClienteOcasional ocasional)
            {
                if (ocasional.EsElegibleRegalo == true)
                {
                    ocasional.EsElegibleRegalo = false;
                }
                else
                {
                    ocasional.EsElegibleRegalo = true;
                }
            }
        }

        #endregion

    }
}
