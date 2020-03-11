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
        string mensaje="";
        LogicaRol LogicaRol = new LogicaRol();
        LogicaPermiso permisos = new LogicaPermiso();

        
        public ActionResult Index()
        {
            return View();
        }

        [PermisoAttribute(Permiso = EnumRolesPermiso.Registrar_Rol)]
        public ActionResult Registrar()
        {
            return View();
        }

        [ValidateSession]
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

        [PermisoAttribute(Permiso = EnumRolesPermiso.Listar_Rol)]
        [ValidateSession]
        public ActionResult Listado()
        {
            ViewData["mensaje"] = mensaje;
            return View(LogicaRol.Listar());
        }

        [ValidateSession]
        public ActionResult Actualizar(long id)
        {
         
            return View(LogicaRol.Obtener(id));
        }

        [ValidateSession]
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

        [ValidateSession]
        public ActionResult Permiso(long id)
        {
            return View(permisos.ObtenerListaPermisos(id));
        }

        [ValidateSession]
        public ActionResult Eliminar(long id)
        {
            if (LogicaRol.Eliminar(id))
            {
                mensaje = "Rol Eliminado";
            }
            else
            {
                mensaje= "hay un usuario con este Rol";
            }

            return RedirectToAction("Listado");
        }

        [ValidateSession]

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

        [ValidateSession]
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