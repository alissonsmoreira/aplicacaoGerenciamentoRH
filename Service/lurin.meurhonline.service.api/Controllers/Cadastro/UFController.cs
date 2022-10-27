using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;

using lurin.meurhonline.application;
using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.service.api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("UF")]
    [Authorize]
    public class UFController : ApiController
    {
        /// <summary>
        /// Busca Tudo UF
        /// </summary>        
        /// <remarks>Retorna todas UF</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: UF/BuscarTudoUF
        [Route("BuscarTudoUF", Name = "BuscarTudoUF")]
        [HttpGet]
        public IHttpActionResult BuscarTudoUF()
        {
            UFFacade UFFacade = new UFFacade();

            var result = UFFacade.BuscarTudoUF();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

    }
}
