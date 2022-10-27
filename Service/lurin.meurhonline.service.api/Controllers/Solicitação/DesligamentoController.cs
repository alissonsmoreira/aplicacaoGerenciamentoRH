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
    [RoutePrefix("Desligamento")]
    [Authorize]
    public class DesligamentoController : ApiController
    {

        /// <summary>
        /// Busca Solicitação Solicitação Desligament Por Colaborador Id
        /// </summary>        
        /// <remarks>Retorna solicitações de delisgamento por Colaborador Id</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Desligamento/BuscarSolicitacaoDesligamentoPorColaboradorId
        [Route("BuscarSolicitacaoDesligamentoPorColaboradorId", Name = "BuscarSolicitacaoDesligamentoPorColaboradorId")]
        [HttpGet]
        public IHttpActionResult BuscarSolicitacaoDesligamentoPorColaboradorId(int id)
        {
            DesligamentoFacade desligamentoFacade = new DesligamentoFacade();

            var result = desligamentoFacade.BuscarSolicitacaoDesligamentoPorColaboradorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Solicitação Desligamento
        /// </summary>        
        /// <remarks>Retorna solicitação de desligamento</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Desligamento/BuscarSolicitacaoDesligamento
        [Route("BuscarSolicitacaoDesligamento", Name = "BuscarSolicitacaoDesligamento")]
        [HttpPost]
        public IHttpActionResult BuscarSolicitacaoDesligamento(DesligamentoModel desligamento)
        {
            DesligamentoFacade desligamentoFacade = new DesligamentoFacade();

            var result = desligamentoFacade.BuscarSolicitacaoDesligamento(desligamento);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Tudo Desligamento Tipo 
        /// </summary>        
        /// <remarks>Retorna o desligamento tipo</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Desligamento/BuscarTudoDesligamentoTipo
        [Route("BuscarTudoDesligamentoTipo", Name = "BuscarTudoDesligamentoTipo")]
        [HttpGet]
        public IHttpActionResult BuscarTudoDesligamentoTipo()
        {
            DesligamentoFacade desligamentoFacade = new DesligamentoFacade();

            var result = desligamentoFacade.BuscarTudoDesligamentoTipo();

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        /// <summary>
        /// Adiciona Solicitação de Desligamento
        /// </summary>        
        /// <remarks>Adiciona solicitação de desligamento</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Desligamento/SolicitarDesligamento
        [Route("SolicitarDesligamento", Name = "SolicitarDesligamento")]
        [HttpPost]
        public IHttpActionResult SolicitarDesligamento(DesligamentoModel desligamento)
        {
            DesligamentoFacade DesligamentoFacade = new DesligamentoFacade();

            var result = DesligamentoFacade.SolicitarDesligamento(desligamento);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Aprova Solicitação de Desligamento
        /// </summary>        
        /// <remarks>Aprova solicitação de desligamento</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Desligamento/AprovarSolicitacaoDesligamento
        [Route("AprovarSolicitacaoDesligamento", Name = "AprovarSolicitacaoDesligamento")]
        [HttpPost]
        public IHttpActionResult AprovarSolicitacaoDesligamento(DesligamentoModel desligamento)
        {
            DesligamentoFacade desligamentoFacade = new DesligamentoFacade();

            var result = desligamentoFacade.AprovarSolicitacaoDesligamento(desligamento);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Reprova Solicitação de Desligamento
        /// </summary>        
        /// <remarks>Reprova solicitação de desligamento</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Desligamento/ReprovarSolicitacaoDesligamento
        [Route("ReprovarSolicitacaoDesligamento", Name = "ReprovarSolicitacaoDesligamento")]
        [HttpPost]
        public IHttpActionResult ReprovarSolicitacaoDesligamento(int id)
        {
            DesligamentoFacade desligamentoFacade = new DesligamentoFacade();

            var result = desligamentoFacade.ReprovarSolicitacaoDesligamento(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
