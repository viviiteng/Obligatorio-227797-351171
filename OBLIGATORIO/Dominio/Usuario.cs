using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Usuario
    {
        public string Correo { get; set; }
        public string Pass { get; set; }

        public Usuario()
        {
        }
        public Usuario(string correo, string pass)
        {
            this.Correo = correo;
            this.Pass = pass;
        }
        public abstract void ValidarContenidos();

        public override bool Equals(object? obj)
        {
            Usuario otro = (Usuario)obj;
            return this.Correo == otro.Correo && this.Pass == otro.Pass;
        }
    }
}
