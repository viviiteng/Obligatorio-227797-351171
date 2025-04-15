using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ClientePremium : Cliente
    {
        public int PuntosAcumulados {get; set;}
        
        public ClientePremium(string cedula, string nombre, string correo, string pass, string nacionalidad, int puntos) : base (cedula, nombre, correo, pass, nacionalidad)
        {
            this.PuntosAcumulados = puntos;
        }

        public override string ToString()
        {

            return base.ToString() + $" Cliente premium con sus puntos: {this.PuntosAcumulados} ";
        }

    }
}
