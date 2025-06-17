using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.Controllers
{
    public class RegistroController : Controller
    {
        private Sistema sistema = Sistema.ObtenerInstancia();

        public IActionResult VerRegistro()
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

        [HttpPost]
        public IActionResult RegistrarCliente(ClienteOcasional unClienteOcasional)
        {
            try
            {
                sistema.AgregarNuevoUsuario(unClienteOcasional);
                return RedirectToAction("Index", "Home");
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
