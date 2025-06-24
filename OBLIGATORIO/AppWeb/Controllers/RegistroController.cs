using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.Controllers
{
    public class RegistroController : Controller
    {
        private Sistema sistema = Sistema.ObtenerInstancia();
        private bool hayUsuarioLogueado()
        {
            return (HttpContext.Session.GetString("Correo") != null);
        }
        public IActionResult VerRegistro()
        {
            if (!hayUsuarioLogueado())
            {
                ViewBag.OcultarNavbar = true;
                return View();
            } 
            return Redirect("/home/index");  
        }

        [HttpPost]
        public IActionResult RegistrarCliente(ClienteOcasional unClienteOcasional)
        {
            try
            {
                sistema.AgregarNuevoUsuario(unClienteOcasional);
                HttpContext.Session.SetString("Correo", unClienteOcasional.Correo);
                HttpContext.Session.SetString("Rol", unClienteOcasional.ObtenerRolUsuario());
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
