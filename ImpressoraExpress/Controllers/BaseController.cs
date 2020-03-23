using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ImpressoraExpressMVC.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var cookie = this.Request.Cookies["CookieUsuario"];
            if (cookie == null)
            {
                context.Result = new RedirectResult(Url.Action("Login", "Usuario"));
            }
            base.OnActionExecuting(context);    
        }
    }
}