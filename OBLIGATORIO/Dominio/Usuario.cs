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
            if (this.Pass == null || this.Correo == null || this.Correo == "" || this.Pass == "")
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
            if (!encontrarNumero(this.Pass))
            {
                mensaje += "Error: La contraseña debe contener algun numero.\n";
            }
            if (!encontrarLetra(this.Pass))
            {
                mensaje += "Error: La contraseña debe contener alguna letra. ";
            }
            if(mensaje != "")
            {
                throw new Exception(mensaje);
            }
        }

        private static bool encontrarLetra(string texto)
        {
            string abecedario = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string textoMayus = texto.ToUpper();

            for (int i = 0; i < textoMayus.Length; i++)
            {
                for (int j = 0; j < abecedario.Length; j++)
                {
                    if (textoMayus[i] == abecedario[j])
                    {
                        return true;
                    }

                }

            }
            return false;
        }
        private static bool encontrarNumero(string texto)
        {
            string numeros = "0123456789";
            for (int i = 0; i < texto.Length; i++)
            {
                for (int j = 0; j < numeros.Length; j++)
                {
                    if (texto[i] == numeros[j])
                    {
                        return true;
                    }

                }

            }
            return false;
        }

        public abstract string ObtenerDatosUsuario();

        public abstract string ObtenerRolUsuario();

        public override bool Equals(object? obj)
        {
            Usuario otro = (Usuario)obj;
            return this.Correo == otro.Correo;
        }
        #endregion


    }
}
