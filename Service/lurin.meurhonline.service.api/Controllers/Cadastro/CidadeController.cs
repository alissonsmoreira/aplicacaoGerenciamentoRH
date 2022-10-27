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
    [RoutePrefix("Cidade")]
    [Authorize]
    public class CidadeController : ApiController
    {
        /// <summary>
        /// Busca Cidade Por UF
        /// </summary>        
        /// <remarks>Retorna Cidades Por UF</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Cidade/BuscarCidadePorUF
        [Route("BuscarCidadePorUF", Name = "BuscarCidadePorUF")]
        [HttpGet]
        public IHttpActionResult BuscarCidadePorUF(string uf)
        {
            CidadeFacade CidadeFacade = new CidadeFacade();

            var result = CidadeFacade.BuscarCidadePorUF(uf);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

    }
}
