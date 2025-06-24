using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.Controllers
{
    public class VueloController : Controller
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
        public IActionResult ListarVuelos(string iataOrigen, string iataDestino)
        {
            if (hayUsuarioLogueado() && usuarioLogueadoEsCliente())
            {
                try
                {
                    return View(sistema.ListarVueloSegunIATA(iataOrigen, iataDestino));

                }
                catch (Exception ex)
                {
                    return View();
                }
            }       
            return Redirect("/LogIn/VerInicioSesion");
                
        }
    }
}

