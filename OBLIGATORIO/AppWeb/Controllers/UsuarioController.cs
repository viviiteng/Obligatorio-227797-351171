using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace AppWeb.Controllers
{
    public class UsuarioController : Controller
    {   
        private Sistema sistema = Sistema.ObtenerInstancia();
        public IActionResult VerInicioSesion()
        {
            try
            {
                ViewBag.OcultarNavbar = true;
                return View();
            }catch (Exception error)
            {
                return ViewBag.Error = error.Message;
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
        public IActionResult RegistrarUsuario(Usuario unUsuario)
        {
            try
            {
                sistema.AgregarNuevoUsuario(unUsuario);
                return Redirect("/Vuelo/Index");
            }
            catch (Exception error)
            {
                return ViewBag.Error = error.Message;
            }
        }
    }
}
