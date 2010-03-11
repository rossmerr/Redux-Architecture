using System;
using System.Web;
using System.Web.Mvc;

namespace ReduxArch.Web
{
    public class RequiresSSL : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var req = filterContext.HttpContext.Request;
            var res = filterContext.HttpContext.Response;

            //Check if we're secure or not and if we're on the local box
            if (!req.IsSecureConnection && !req.IsLocal)
            {
                var builder = new UriBuilder(req.Url)
                                  {
                                      Scheme = Uri.UriSchemeHttps,
                                      Port = 443
                                  };
                res.Redirect(builder.Uri.ToString());
            }
            base.OnActionExecuting(filterContext);
        }
    }
}