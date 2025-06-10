using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.interfaces;

namespace Dominio
{
    public abstract class Usuario : IValidable
    {
        #region Atributos
        public string Correo { get; set; }
        public string Pass { get; set; }
        #endregion 

        #region Constructor
        public Usuario()
        {
        }
        public Usuario(string correo, string pass)
        {
            this.Correo = correo;
            this.Pass = pass;
        }
        #endregion

        #region Metodos
        public virtual void Validar()
        {
            validarEspaciosVacios();
            validarFormatoPass();
            
        }
        private void validarEspaciosVacios()
        {
            if (this.Correo == "" || this.Pass == "")
            {
                throw new Exception("Error: Debe rellenar todos los campos requeridos.\n");
            }
        }
        private void validarFormatoPass()
        {
            string mensaje = "";
            if (this.Pass.Length < 8)
            {
                mensaje += "Error: La contraseña debe tener al menos 8 caracteres.\n";
            }
            if (!Sistema.encontrarNumero(this.Pass))
            {
                mensaje += "Error: La contraseña debe contener algun numero.\n";
            }
            if (!Sistema.encontrarLetra(this.Pass))
            {
                mensaje += "Error: La contraseña debe contener alguna letra. ";
            }
            if(mensaje != "")
            {
                throw new Exception(mensaje);
            }
        }

        public abstract string ObtenerDatosUsuario();

        public abstract string ObtenerRolUsuario();

        public override bool Equals(object? obj)
        {
            Usuario otro = (Usuario)obj;
            return this.Correo == otro.Correo && this.Pass == otro.Pass;
        }
        #endregion


    }
}
