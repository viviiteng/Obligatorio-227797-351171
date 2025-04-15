using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ClienteOcasional : Cliente
    {
        public bool EsClienteOcasional { get; set; }


        public ClienteOcasional(string cedula, string nombre, string correo, string pass, string nacionalidad, bool esClienteOcasional) : base (cedula, nombre, correo, pass, nacionalidad)
        {
            this.EsClienteOcasional = esClienteOcasional;


       
        }
        public override string ToString()
        {

            return base.ToString() + $" Cliente ocasional: {this.EsClienteOcasional} ";
        }
    }

    
}
