using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace AppWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private Sistema sistema = Sistema.ObtenerInstancia();
        private bool hayUsuarioLogueado()
        {
            return (HttpContext.Session.GetString("Correo") != null);
        }
        private bool usuarioLogueadoEsCliente()
        {
            return (HttpContext.Session.GetString("Rol") != "ADMIN");
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
                List<Pasaje> pasajes = sistema.ObtenerListadoPasajesSegunUsuario(usuarioLogueado);
                return View(pasajes);
            }
            if (!usuarioLogueadoEsCliente())
            {
                return Redirect("/Home/Index");
            }
            return Redirect("/LogIn/VerInicioSesion");
        }
    }
}
