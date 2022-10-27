using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace lurin.meurhonline.service.api.Controllers
{
    public class BaseController : ApiController
    {
        protected int? ObterIdColaborador()
        {
            if (this.User != null && this.User.Identity != null && this.User.Identity.IsAuthenticated) {
                var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();

                var resultadoParse = int.TryParse(claims?.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid)?.Value, out int resultado);

                return resultadoParse ? resultado : (int?)null;
            }

            return null;
        }
    }
}