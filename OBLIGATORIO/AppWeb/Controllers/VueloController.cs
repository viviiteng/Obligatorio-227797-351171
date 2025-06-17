using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.Controllers
{
    public class VueloController : Controller
    {
        private Sistema sistema = Sistema.ObtenerInstancia();
        public IActionResult ListarVuelos(string iataOrigen, string iataDestino)
        {
            string correoLogueado = HttpContext.Session.GetString("Correo");

            if (correoLogueado != null)
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
            else
            {
                return Redirect("/Usuario/VerInicioSesion");
            }
                
        }
    }
}

