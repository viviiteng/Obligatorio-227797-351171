using Dominio;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppWeb.Controllers
{
    public class AdministradorController : Controller
    {
        private Sistema sistema = Sistema.ObtenerInstancia();
        public IActionResult VerListadoClientes()
        {
            try {
                if (HttpContext.Session.GetString("Correo")!=null && HttpContext.Session.GetString("Rol")==Rol.ADMIN.ToString())
                {
                    List<Cliente> clientes = sistema.ObtenerListadoDeClientes();
                    clientes.Sort();
                    return View(clientes);
                }
            }
            catch (Exception error)
            {
                return View(error);
            }
            return Redirect("/LogIn/VerInicioSesion");
        }

        //[HttpPost]
        //public IActionResult VerEditarCliente()
        //{

        //}
    }

    
}
