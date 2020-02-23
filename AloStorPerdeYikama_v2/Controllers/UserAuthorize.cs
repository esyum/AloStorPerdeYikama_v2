using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AloStorPerdeYikama_v2.Controllers
{
    public class UserAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["username"] != null)
            {
                return true;
            }
            else
            {
                httpContext.Response.Redirect("/Home");
                return false;
            }

        }
    }
}