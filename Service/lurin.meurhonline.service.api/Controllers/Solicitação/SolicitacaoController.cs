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
    [RoutePrefix("Solicitacao")]
    [Authorize]
    public class SolicitacaoController : ApiController
    {
        /// <summary>
        /// Busca Tudo Status
        /// </summary>        
        /// <remarks>Retorna todos os Status</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Solicitacao/BuscarTudoStatusSolicitacao
        [Route("BuscarTudoStatusSolicitacao", Name = "BuscarTudoStatusSolicitacao")]
        [HttpGet]
        public IHttpActionResult BuscarTudoStatusSolicitacao()
        {
            SolicitacaoFacade SolicitacaoFacade = new SolicitacaoFacade();

            var result = SolicitacaoFacade.BuscarTudoStatus();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

    }
}
