using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades;
using LogicaNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Filters;

namespace Web.Controllers
{
    public class RolController : Controller
    {
        LogicaRol LogicaRol = new LogicaRol();
        LogicaPermiso permisos = new LogicaPermiso();

        
        public ActionResult Index()
        {
            return View();
        }

        //[PermisoAttribute(Permiso = EnumRolesPermiso.Registrar_Rol)]
        public ActionResult Registrar()
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
        public ActionResult Listado()
        {
            return View(LogicaRol.Listar());
        }

        
        public ActionResult Actualizar(long id)
        {
         
            return View(LogicaRol.Obtener(id));
        }

        [HttpPost]
        public ActionResult Actualizar(Rol rol)
        {
            if (ModelState.IsValid)
            {
                  LogicaRol.Actualizar(rol);

            }
            else
            {

            }
            return View(rol);
        }
        public ActionResult Permiso(long id)
        {
            return View(permisos.ObtenerListaPermisos(id));
        }
       

        public ActionResult Denegar(long rol, long opcion)
        {
            if (permisos.Denegar(rol, opcion))
            {

            }
            else
            {

            }
            return RedirectToAction("Actualizar", new { id = rol });
        }
        public ActionResult Permitir(long id)
        {
            Console.WriteLine();
            return View();
        }


    }
}