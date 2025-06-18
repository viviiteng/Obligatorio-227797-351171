using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AppWeb.Models;
using Dominio;

namespace AppWeb.Controllers;

public class HomeController : Controller
{
    private Sistema sistema = Sistema.ObtenerInstancia();

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {    
        if(HttpContext.Session.GetString("Correo") != null){
            ViewBag.UsuarioCorreo = sistema.ObtenerUsuarioSegunCorreo(HttpContext.Session.GetString("Correo")).Correo;
        }
        return View();  
        

    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
