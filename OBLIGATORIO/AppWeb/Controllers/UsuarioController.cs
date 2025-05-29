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
