using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades;
using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using Web.Filters;

namespace Web.Controllers
{
    public class RolController : Controller
    {
        LogicaRol LogicaRol = new LogicaRol();
        public IActionResult Index()
        {
            return View();
        }

        //[PermisoAttribute(Permiso = EnumRolesPermiso.Registrar_Rol)]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Rol rol)
        {
            Rol oneRol=null;
            if(ModelState.IsValid)
             oneRol = LogicaRol.Agregar(rol);

            if (oneRol != null)
            {
                TempData["Respuesta"] = "Rol Registrado";
                return RedirectToAction("Index");
            }

            return View();
        }

        //[PermisoAttribute(Permiso = EnumRolesPermiso.Registrar_Rol)]
        public IActionResult Listado()
        {
            return View();
        }

    }
}