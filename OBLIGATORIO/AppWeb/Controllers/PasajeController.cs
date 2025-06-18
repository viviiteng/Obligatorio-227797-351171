using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.Controllers
{
    public class PasajeController : Controller
    {
        private Sistema sistema = Sistema.ObtenerInstancia();

        private bool HayUsuarioLogueado()
        {
            return (HttpContext.Session.GetString("Correo")!=null);
        }
        public IActionResult VerCompraPasaje(string numVuelo)
        {          
            if (HayUsuarioLogueado())
            {
                try
                {
                    Vuelo unVuelo = sistema.ObtenerVueloSegunNumVuelo(numVuelo);
                    return View(unVuelo);
                }
                catch (Exception error)
                {
                    return View(error);
                }
            }
            return Redirect("/LogIn/VerInicioSesion");
        }
        public IActionResult ComprarPasaje(string numVuelo, DateTime fechaDeVuelo, TipoEquipaje equipaje)
        {
            if (HayUsuarioLogueado())
            {
                try
                {
                    sistema.AgregarNuevoPasaje(new Pasaje(sistema.ObtenerVueloSegunNumVuelo(numVuelo), fechaDeVuelo, sistema.ObtenerClienteSegunCorreo(HttpContext.Session.GetString("Correo")), equipaje));
                    return Redirect("/Home/Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return View("VerCompraPasaje", sistema.ObtenerVueloSegunNumVuelo(numVuelo));
                }
            }
            return Redirect("/LogIn/VerInicioSesion");
        }

        
    }
}
