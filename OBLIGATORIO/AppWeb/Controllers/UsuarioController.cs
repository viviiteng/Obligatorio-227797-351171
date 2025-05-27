using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace AppWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private Sistema sistema = Sistema.ObtenerInstancia();
        public IActionResult Registrar()
        {
            return View();
        }
    }
}
