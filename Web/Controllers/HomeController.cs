using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entidades;
using LogicaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Filters;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        LogicaUsuario LogicaUsuario = new LogicaUsuario();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ValidateSession]

        public IActionResult Index()
        {
            //if (HttpContext.Session.GetString("User") == null)
            //    return RedirectToAction("Login");
            //else

            ViewData["TotalUsuario"] =  Math.Ceiling(LogicaUsuario.TotalUsuarios()/10.0);
                return View();
        }

        [PermisoAttribute(Permiso = EnumRolesPermiso.listar_Usuario)]
        [ValidateSession]
        [HttpPost]
        public List<Usuario> CargarUsuarios(int pagina)
        {

            return LogicaUsuario.Listar(pagina);
        }

        public IActionResult Login()
        {
            return View();
        }



        [PermisoAttribute(Permiso = EnumRolesPermiso.registrar_usuario)]
        [ValidateSession]
        public IActionResult Registrar()
        {
            return View();
        }
        [ValidateSession]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
