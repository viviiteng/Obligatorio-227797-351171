using AppWeb.Models;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.Controllers
{
    public class ClienteController : Controller
    {
        private Sistema sistema = Sistema.ObtenerInstancia();
        private bool hayUsuarioLogueado()
        {
            return (HttpContext.Session.GetString("Correo") != null);
        }
        private bool usuarioLogueadoEsCliente()
        {
            return (HttpContext.Session.GetString("Rol") != Rol.ADMIN.ToString());
        }

        public IActionResult VerPerfil()
        {
            if (hayUsuarioLogueado() && usuarioLogueadoEsCliente()) { 
                try
                {
                    Cliente clienteLogueado = sistema.ObtenerClienteSegunCorreo(HttpContext.Session.GetString("Correo"));
                    return View(clienteLogueado);
                }
                catch(Exception ex)
                {
                    
                    return View();
                }               
            }
            if (!usuarioLogueadoEsCliente())
            {
                return Redirect("/Home/Index");
            }
            return Redirect("/LogIn/VerInicioSesion");
        }

        public IActionResult VerPasajesComprados()
        {
            if (hayUsuarioLogueado() && usuarioLogueadoEsCliente())
            {
                Usuario usuarioLogueado = sistema.ObtenerUsuarioSegunCorreo(HttpContext.Session.GetString("Correo"));
                List<Pasaje> pasajes = sistema.ObtenerListadoPasajesOrdenadoPrecio(usuarioLogueado);
                return View(pasajes);
            }
            if (!usuarioLogueadoEsCliente())
            {
                return Redirect("/Home/Index");
            }
            return Redirect("/LogIn/VerInicioSesion");
        }

        public IActionResult VerListadoClientes()
        {
            if (hayUsuarioLogueado() && !usuarioLogueadoEsCliente())
            {
                try
                {
                    List<Cliente> clientes = sistema.ObtenerListadoDeClientes();
                    clientes.Sort();
                    return View(clientes);

                }
                catch (Exception error)
                {
                    return View(error);
                }
            }
            return Redirect("/LogIn/VerInicioSesion");
        }


        [HttpPost]
        public IActionResult ModificarCliente(ClienteViewModel vm)
        {
            if (vm.PuntosAcumulados == null)
            {
                ClienteOcasional clienteOc = new ClienteOcasional();
                clienteOc.Correo = vm.Correo;
                sistema.ModificarCliente(clienteOc);
            }
            else
            {
                ClientePremium clientePre = new ClientePremium();
                clientePre.Correo = vm.Correo;
                clientePre.PuntosAcumulados = vm.PuntosAcumulados.Value;
                sistema.ModificarCliente(clientePre);
            }

            return Redirect("/Administrador/VerListadoClientes");
        }
    }
}
