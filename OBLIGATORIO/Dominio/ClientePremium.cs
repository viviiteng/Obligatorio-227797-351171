using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ClientePremium : Cliente
    {
        #region Atributos
        public int PuntosAcumulados { get; set; }
        #endregion

        #region Constructor
        public ClientePremium() { }
        public ClientePremium(string cedula, string nombre, string correo, string pass, string nacionalidad, int puntos) : base(cedula, nombre, correo, pass, nacionalidad)
        {
            this.PuntosAcumulados = puntos;
        }
        #endregion

        #region Metodos
        public override void Validar()
        {
            base.Validar();
            if (this.PuntosAcumulados < 0)
            {
                throw new Exception("Error: Debe rellenar todos los campos requeridos");
            }
        }
        public override string ObtenerDatosUsuario()
        {
            return $"CLIENTE PREMIUM: Cedula: {this.Cedula}, Nombre: {this.Nombre}, Correo: {this.Correo}, Nacionalidad: {this.Nacionalidad}, Puntos: {this.PuntosAcumulados}";

        }
        #endregion



    }
}
