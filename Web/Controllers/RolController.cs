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
                if (LogicaRol.Actualizar(rol) == null)
                {
                    ViewBag.Error = "Error al Actualizar";
                    return View();
                }


            return RedirectToAction("Listado");
        }
        public ActionResult Permiso(long id)
        {
            return View(permisos.ObtenerListaPermisos(id));
        }
       
        public ActionResult Eliminar(long id)
        {
            if (LogicaRol.Eliminar(id))
            {
                //redirecciono
            }
            else
            {
                //mensaje en caso de error
            }

            return RedirectToAction("Listado");
        }

        public ActionResult Denegar(long rol, long opcion)
        {
            if (permisos.Denegar(rol, opcion))
            {
               
            }
            else
            {
                //mostrar mensaje en caso de error
            }
            return RedirectToAction("Permiso", new { id = rol });
        }
        public ActionResult Permitir(long rol, long opcion)
        {
            if (permisos.Permitir(rol, opcion))
            {

            }
            else
            {

            }

            Console.WriteLine();
            return RedirectToAction("Permiso", new { id = rol });
        }


    }
}