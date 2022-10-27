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
    [RoutePrefix("MovimentacaoContratual")]
    [Authorize]
    public class MovimentacaoContratualController : ApiController
    {
        /// <summary>
        /// Busca Dados Por Colaborador Id
        /// </summary>        
        /// <remarks>Retorna os dados por Colaborador Id</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: MovimentacaoContratual/BuscarDadosMovimentacaoContratualPorColaboradorId
        [Route("BuscarDadosMovimentacaoContratualPorColaboradorId", Name = "BuscarDadosMovimentacaoContratualPorColaboradorId")]
        [HttpGet]
        public IHttpActionResult BuscarDadosPorColaboradorId(int id)
        {
            MovimentacaoContratualFacade MovimentacaoContratualFacade = new MovimentacaoContratualFacade();

            var result = MovimentacaoContratualFacade.BuscarDadosPorColaboradorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Solicitação Movimentação Contratual Por Colaborador Id
        /// </summary>        
        /// <remarks>Retorna solicitação de movimentação contratual por Colaborador Id</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: MovimentacaoContratual/BuscarSolicitacaoMovimentacaoContratualPorColaboradorId
        [Route("BuscarSolicitacaoMovimentacaoContratualPorColaboradorId", Name = "BuscarSolicitacaoMovimentacaoContratualPorColaboradorId")]
        [HttpGet]
        public IHttpActionResult BuscarSolicitacaoMovimentacaoContratualPorColaboradorId(int id)
        {
            MovimentacaoContratualFacade MovimentacaoContratualFacade = new MovimentacaoContratualFacade();

            var result = MovimentacaoContratualFacade.BuscarSolicitacaoMovimentacaoContratualPorColaboradorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Solicitação Movimentação Contratual
        /// </summary>        
        /// <remarks>Retorna solicitação de movimentação contratual</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: MovimentacaoContratual/BuscarSolicitacaoMovimentacaoContratual
        [Route("BuscarSolicitacaoMovimentacaoContratual", Name = "BuscarSolicitacaoMovimentacaoContratual")]
        [HttpPost]
        public IHttpActionResult BuscarSolicitacaoMovimentacaoContratual(MovimentacaoContratualModel movimentacaoContratual)
        {
            MovimentacaoContratualFacade MovimentacaoContratualFacade = new MovimentacaoContratualFacade();

            var result = MovimentacaoContratualFacade.BuscarSolicitacaoMovimentacaoContratual(movimentacaoContratual);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona Solicitação de Movimentação Contratual
        /// </summary>        
        /// <remarks>Adiciona Solicitação de Movimentação Contratual</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: MovimentacaoContratual/SolicitarMovimentacaoContratual
        [Route("SolicitarMovimentacaoContratual", Name = "SolicitarMovimentacaoContratual")]
        [HttpPost]
        public IHttpActionResult SolicitarMovimentacaoContratual(MovimentacaoContratualModel movimentacaoContratual)
        {
            MovimentacaoContratualFacade MovimentacaoContratualFacade = new MovimentacaoContratualFacade();

            var result = MovimentacaoContratualFacade.SolicitarMovimentacaoContratual(movimentacaoContratual);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Aprova Solicitação de Movimentação Contratual
        /// </summary>        
        /// <remarks>Aprova Solicitação de Movimentação Contratual</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: MovimentacaoContratual/AprovarSolicitacaoMovimentacaoContratual
        [Route("AprovarSolicitacaoMovimentacaoContratual", Name = "AprovarSolicitacaoMovimentacaoContratual")]
        [HttpPost]
        public IHttpActionResult AprovarSolicitacaoMovimentacaoContratual(int id)
        {
            MovimentacaoContratualFacade MovimentacaoContratualFacade = new MovimentacaoContratualFacade();

            var result = MovimentacaoContratualFacade.AprovarSolicitacaoMovimentacaoContratual(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Reprova Solicitação de Movimentação Contratual
        /// </summary>        
        /// <remarks>Reprova Solicitação deMovimentação Contratual</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: MovimentacaoContratual/ReprovarSolicitacaoMovimentacaoContratual
        [Route("ReprovarSolicitacaoMovimentacaoContratual", Name = "ReprovarSolicitacaoMovimentacaoContratual")]
        [HttpPost]
        public IHttpActionResult ReprovarSolicitacaoMovimentacaoContratual(int id)
        {
            MovimentacaoContratualFacade MovimentacaoContratualFacade = new MovimentacaoContratualFacade();

            var result = MovimentacaoContratualFacade.ReprovarSolicitacaoMovimentacaoContratual(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
