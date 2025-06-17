using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace AppWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private Sistema sistema = Sistema.ObtenerInstancia();

        

        public IActionResult VerPerfil(string correo, string pass)
        {
            try
            {
                sistema.ObtenerUsuarioSegunCorreoYPass(correo, pass);
                return View();
            }
            catch
            {
                return View();
            }
            return View();
        }

    }
}
