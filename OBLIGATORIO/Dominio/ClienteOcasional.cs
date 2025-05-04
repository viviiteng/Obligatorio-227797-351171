using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class ClienteOcasional : Cliente
    {
        public bool EsClienteOcasional { get; set; }


        public ClienteOcasional(string cedula, string nombre, string correo, string pass, string nacionalidad, bool esClienteOcasional) : base (cedula, nombre, correo, pass, nacionalidad)
        {
            this.EsClienteOcasional = esClienteOcasional;       
        }

        public override void ValidarContenidos()
        {
            if (this.Cedula == "" || this.Nombre == "" || this.Correo == "" || this.Pass == "" || this.Nacionalidad == "")
            {
                throw new Exception("Los valores para cada atributo del cliente ocasional no pueden estar vacios");
            }
        }
        public override string ObtenerDatosCliente()
        {
            return $"CLIENTE OCASIONAL: Cedula: {this.Cedula}, Nombre: {this.Nombre}, Correo: {this.Correo}, Contrasena: {this.Pass}, Nacionalidad: {this.Nacionalidad}, esClienteOcasional: {this.EsClienteOcasional}";

        }
    }

    
}
