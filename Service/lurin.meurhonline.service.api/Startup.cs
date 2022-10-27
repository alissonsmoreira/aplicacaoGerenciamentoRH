using System;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(lurin.meurhonline.service.api.Startup))]

namespace lurin.meurhonline.service.api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);

            var config = new HttpConfiguration();
            config.EnableCors();

            ConfigureAuthentication(app);
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }

        private static void ConfigureAuthentication(IAppBuilder app)
        {            
            app.UseOAuthAuthorizationServer
            (
                new OAuthAuthorizationServerOptions()
                {
                    AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                    AllowInsecureHttp = true,
                    TokenEndpointPath = new PathString("/Autenticacao/Token"),                    
                    Provider = new OAuthAuthorizationServerProvider()
                    {
                        OnValidateClientAuthentication = async ctx =>
                        {
                            await Task.Run(() => ctx.Validated());
                        },
                        OnGrantResourceOwnerCredentials = async ctx =>
                        {
                            await Task.Run(() =>
                            {
                                var userNameData = ctx.UserName.Split('_');
                                if (userNameData[0] != "MeuRHOnline" || ctx.Password != "Web@#2021")
                                {
                                    ctx.Rejected();
                                    return;
                                }

                                var identity = new ClaimsIdentity(
                                    new[] {
                                        new Claim(ClaimTypes.Name, userNameData[0]),
                                        new Claim(ClaimTypes.Role, "Admin"),
                                        new Claim(ClaimTypes.PrimarySid, userNameData[1])},
                                    ctx.Options.AuthenticationType);

                                ctx.Validated(identity);
                            });
                        }
                    }
                }
            );

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
