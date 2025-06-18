using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.Controllers
{
    public class RegistroController : Controller
    {
        private Sistema sistema = Sistema.ObtenerInstancia();
        private bool HayUsuarioLogueado()
        {
            return (HttpContext.Session.GetString("Correo") != null);
        }
        public IActionResult VerRegistro()
        {
            if (HayUsuarioLogueado())
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
                return Redirect("/Home/Index");
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
