using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace lurin.meurhonline.service.api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]    
    [RoutePrefix("OAuth")]
    [Authorize]
    public class OAuthController : ApiController
    {
        [HttpGet]
        public string GetAutenticacaoTest()
        {
            return "Testing...";
        }
    }
}