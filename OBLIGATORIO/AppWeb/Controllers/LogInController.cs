using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.Controllers
{
    public class LogInController : Controller
    {

        private Sistema sistema = Sistema.ObtenerInstancia();
        private bool HayUsuarioLogueado()
        {
            return (HttpContext.Session.GetString("Correo") != null);
        }
        public IActionResult VerInicioSesion()
        {
            if (HayUsuarioLogueado())
            {
                return Redirect("/home/index");

            }
            ViewBag.OcultarNavbar = true;
            return View();      
        }
        public IActionResult VerConfirmarLogOut()
        {
            if (HayUsuarioLogueado())
            {
                ViewBag.OcultarNavbar = true;
                return View();
            }
            return Redirect("/home/index");
        }
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return Redirect("/home/index");
        }

        [HttpPost]
        public IActionResult Loguearse(string Correo, string Pass)
        {
            ViewBag.OcultarNavbar = true;
            try
            {
                Usuario usuarioSistema = sistema.ObtenerUsuarioSegunCorreo(Correo);
                sistema.ValidarPassDeUsuario(usuarioSistema, Pass);
                HttpContext.Session.SetString("Correo", usuarioSistema.Correo);
                HttpContext.Session.SetString("Rol", usuarioSistema.ObtenerRolUsuario());

                return Redirect("/home/index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("VerInicioSesion");
            }

        }
    }
}

