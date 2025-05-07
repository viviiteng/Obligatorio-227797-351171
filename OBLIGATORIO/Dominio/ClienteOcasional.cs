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
        public bool EsElegibleRegalo { get; set; }


        public ClienteOcasional(string cedula, string nombre, string correo, string pass, string nacionalidad) : base (cedula, nombre, correo, pass, nacionalidad)
        {
            this.EsElegibleRegalo = generarBoolRandom();       
        }

        public override void Validar()
        {
            if (this.Cedula == "" || this.Nombre == "" || this.Correo == "" || this.Pass == "" || this.Nacionalidad == "")
            {
                throw new Exception("Los valores para cada atributo del cliente ocasional no pueden estar vacios");
            }
        }
        public override string ObtenerDatosUsuario()
        {
            return $"CLIENTE OCASIONAL: Cedula: {this.Cedula}, Nombre: {this.Nombre}, Correo: {this.Correo}, Contrasena: {this.Pass}, Nacionalidad: {this.Nacionalidad}, Regalo: {this.EsElegibleRegalo}";

        }

        private bool generarBoolRandom()
        {
            Random random = new Random();
            int numero = random.Next(0, 2);
            bool resultado = false;
            if (numero == 1)
            {
                resultado = true;
            }

            return resultado;
        }

    }

    
}
