using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net.Http;

namespace lurin.meurhonline.service.api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            string ambiente = ConfigurationManager.AppSettings["Ambiente"];
            if (ambiente.ToUpper().Equals("PROD"))
                config.Filters.Add(new RequireHttpsAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );            
        }
    }

    public class RequireHttpsAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                {
                    ReasonPhrase = "HTTPS Required for this call"
                };
            }
            else
            {
                base.OnAuthorization(actionContext);
            }
        }
    }
}
