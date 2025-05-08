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
        public abstract void Validar();

        public abstract string ObtenerDatosUsuario();

        public override bool Equals(object? obj)
        {
            Usuario otro = (Usuario)obj;
            return this.Correo == otro.Correo && this.Pass == otro.Pass;
        }
        #endregion


    }
}
