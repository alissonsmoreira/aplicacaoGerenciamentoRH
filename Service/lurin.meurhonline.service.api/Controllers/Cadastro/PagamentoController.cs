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
    [RoutePrefix("Pagamento")]
    [Authorize]
    public class PagamentoController : ApiController
    {
        /// <summary>
        /// Busca Tudo Banco
        /// </summary>        
        /// <remarks>Retorna todos os Bancos</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Pagamento/BuscarTudoBanco
        [Route("BuscarTudoBanco", Name = "BuscarTudoBanco")]
        [HttpGet]
        public IHttpActionResult BuscarTudoBanco()
        {
            PagamentoFacade PagamentoFacade = new PagamentoFacade();

            var result = PagamentoFacade.BuscarTudoBanco();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Buscar Tudo Tipo de Conta
        /// </summary>        
        /// <remarks>Retorna Todos os Tipos de Conta</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Pagamento/BuscarTudoTipoConta
        [Route("BuscarTudoTipoConta", Name = "BuscarTudoTipoConta")]
        [HttpGet]
        public IHttpActionResult BuscarTudoTipoConta()
        {
            PagamentoFacade PagamentoFacade = new PagamentoFacade();

            var result = PagamentoFacade.BuscarTudoTipoConta();

            if (result == null)
                return NotFound();

            return Ok(result);
        }


    }
}