using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inscripcion_Universidad.Permisos
{
    public class ValidarSesionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["result"] == null)
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}