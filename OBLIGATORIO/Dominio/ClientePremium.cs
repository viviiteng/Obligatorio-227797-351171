using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ClientePremium : Cliente
    {
        public int PuntosAcumulados { get; set; }

        public ClientePremium(string cedula, string nombre, string correo, string pass, string nacionalidad, int puntos) : base(cedula, nombre, correo, pass, nacionalidad)
        {
            this.PuntosAcumulados = puntos;
        }

        public override void Validar()
        {
            if (this.Cedula == "" || this.Nombre == "" || this.Correo == "" || this.Pass == "" || this.Nacionalidad == "" || this.PuntosAcumulados < 0)
            {
                throw new Exception("Los valores para cada atributo del cliente premium no pueden estar vacios");
            }
        }
        public override string ObtenerDatosUsuario()
        {
            return $"CLIENTE PREMIUM: Cedula: {this.Cedula}, Nombre: {this.Nombre}, Correo: {this.Correo}, Contrasena: {this.Pass}, Nacionalidad: {this.Nacionalidad}, Puntos: {this.PuntosAcumulados}";

        }
        

    }
}
