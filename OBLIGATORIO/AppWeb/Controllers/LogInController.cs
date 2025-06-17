using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.Controllers
{
    public class LogInController : Controller
    {
        
        private Sistema sistema = Sistema.ObtenerInstancia();
        public IActionResult VerInicioSesion()
        {
            string correoLogueado = HttpContext.Session.GetString("Correo");

            if (correoLogueado != null) 
            {
                return Redirect("/home/index");

            }
            else
            {
                ViewBag.OcultarNavbar = true;
                return View();
            }
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
                Usuario usuarioSistema = sistema.ObtenerUsuarioSegunCorreoYPass(Correo, Pass);
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

