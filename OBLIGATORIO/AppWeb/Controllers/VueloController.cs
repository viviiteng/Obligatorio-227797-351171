using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.Controllers
{
    public class VueloController : Controller
    {
        private Sistema sistema = Sistema.ObtenerInstancia();
        private bool HayUsuarioLogueado()
        {
            return (HttpContext.Session.GetString("Correo") != null);
        }
        public IActionResult ListarVuelos(string iataOrigen, string iataDestino)
        {
            if (HayUsuarioLogueado())
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

