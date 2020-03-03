using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Web.Filters
{
    public class VerificaSesion: ActionFilterAttribute
    {
        private Usuario ousuario;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            //ousuario=(Usuario)HttpContext.Current.Session["User"];
        }
    }
}
