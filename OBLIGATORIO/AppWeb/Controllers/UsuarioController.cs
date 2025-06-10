using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace AppWeb.Controllers
{
    public class UsuarioController : Controller
    {   
        private Sistema sistema = Sistema.ObtenerInstancia();
        public IActionResult VerInicioSesion()
        {
            ViewBag.OcultarNavbar = true;
            return View();           
        }
        
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return Redirect("/home/index");

        }
        [HttpPost]
        public IActionResult Loguearse(ClienteOcasional unCliente)
        {
            ViewBag.OcultarNavbar = true;
            try
            {
                Usuario usuarioSistema = sistema.ObtenerUsuario(unCliente);
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
        public IActionResult VerRegistro()
        {
            try { 
                ViewBag.OcultarNavbar = true;
                return View();
            }catch (Exception error)
            {
                return ViewBag.Error = error.Message;
            }
        }

        [HttpPost]
        public IActionResult RegistrarCliente(ClienteOcasional unCliente)
        {
            try
            {
                sistema.AgregarNuevoUsuario(unCliente);
                return RedirectToAction("Index","Home");
            }
            catch (Exception error)
            {
                ViewBag.Error = error.Message;
                ViewBag.OcultarNavbar = true;
                return View();
            }
        }

    }
}
