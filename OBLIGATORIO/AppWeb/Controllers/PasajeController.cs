using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.Controllers
{
    public class PasajeController : Controller
    {
        private Sistema sistema = Sistema.ObtenerInstancia();

        public IActionResult MostrarDetalleVueloSegunNumVuelo(string numVuelo)
        {
            try
            {
                Vuelo unVuelo = sistema.ObtenerVueloSegunNumVuelo(numVuelo);

                return View(unVuelo);
            }
            catch (Exception error)
            {
                return View();
            }

        }

        public IActionResult VerCompraPasaje(string numVuelo)
        {
            try
            {
                Vuelo unVuelo = sistema.ObtenerVueloSegunNumVuelo(numVuelo);

                return View(unVuelo);
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        public IActionResult ComprarPasaje(string numVuelo, DateTime fechaDeVuelo, TipoEquipaje equipaje)
        {
            string correoLogueado = HttpContext.Session.GetString("Correo");

            if (correoLogueado != null) 
            {
                try 
                {
                    sistema.AgregarNuevoPasaje(new Pasaje(sistema.ObtenerVueloSegunNumVuelo(numVuelo), fechaDeVuelo, sistema.ObtenerUsuarioSegunCorreo(correoLogueado), equipaje));
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return View("MostrarDetalleVueloSegunNumVuelo", sistema.ObtenerVueloSegunNumVuelo(numVuelo));
                }
            }
            return RedirectToAction("VerInicioSesion","Usuario");
        }
    }
}
