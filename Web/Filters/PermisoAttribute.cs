using LogicaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Filters
{
    public class PermisoAttribute : ActionFilterAttribute
    {
       
        

        public EnumRolesPermiso Permiso { get; set; }
             LogicaRol LogicaRol = new LogicaRol();
       private  string rol;
       
      

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            try
            {
                rol = filterContext.HttpContext.Session.GetString("User");

                if (rol == null || !LogicaRol.TienePermiso(rol, this.Permiso))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "Home",
                        action = "Index"
                    }));
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
