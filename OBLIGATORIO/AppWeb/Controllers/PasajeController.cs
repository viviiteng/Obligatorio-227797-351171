using Dominio;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppWeb.Controllers
{
    public class PasajeController : Controller
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
        public IActionResult VerCompraPasaje(string numVuelo)
        {
            if (hayUsuarioLogueado())
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

        [HttpPost]
        public IActionResult ComprarPasaje(string numVuelo, DateTime fechaDeVuelo, TipoEquipaje equipaje)
        {
            if (hayUsuarioLogueado() && usuarioLogueadoEsCliente())
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

        public IActionResult VerListadoPasajes()
        {
            if (hayUsuarioLogueado() && !usuarioLogueadoEsCliente())
            {
                try
                {
                    List<Pasaje> pasajes = sistema.ObtenerListadoPasajesAdmin();
                    return View(pasajes);
                }
                catch (Exception error)
                {
                    return View(error);
                }
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
    }
}
