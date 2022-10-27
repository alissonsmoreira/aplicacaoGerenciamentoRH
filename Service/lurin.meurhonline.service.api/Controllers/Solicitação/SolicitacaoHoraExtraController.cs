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
    [RoutePrefix("SolicitacaoHoraExtra")]
    [Authorize]
    public class SolicitacaoHoraExtraController : ApiController
    {

        /// <summary>
        /// Busca Solicitação Hora Extra Por Colaborador Id
        /// </summary>        
        /// <remarks>Retorna solicitações de Hora Extra por Colaborador Id</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: SolicitacaoHoraExtra/BuscarSolicitacaoHoraExtraPorGestorId
        [Route("BuscarSolicitacaoHoraExtraPorGestorId", Name = "BuscarSolicitacaoHoraExtraPorGestorId")]
        [HttpGet]
        public IHttpActionResult BuscarSolicitacaoHoraExtraPorGestorId(int gestorId, DateTime? data)
        {
            SolicitacaoHoraExtraFacade solicitacaoHoraExtra = new SolicitacaoHoraExtraFacade();

            var result = solicitacaoHoraExtra.BuscarSolicitacaoHoraExtraPorGestorId(gestorId, data);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Solicitação Hora Extra Por Empresa Id e Data Solicitacao
        /// </summary>        
        /// <remarks>Retorna solicitações de Hora Extra Por Empresa Id e Data Solicitacao</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: SolicitacaoHoraExtra/BuscarSolicitacaoHoraExtraPorEmpresaIdDataSolicitacao
        [Route("BuscarSolicitacaoHoraExtraPorEmpresaIdDataSolicitacao", Name = "BuscarSolicitacaoHoraExtraPorEmpresaIdDataSolicitacao")]
        [HttpGet]
        public IHttpActionResult BuscarSolicitacaoHoraExtraPorEmpresaIdDataSolicitacao(int empresaId, DateTime? dataSolicitacao)
        {
            SolicitacaoHoraExtraFacade solicitacaoHoraExtra = new SolicitacaoHoraExtraFacade();

            var result = solicitacaoHoraExtra.BuscarSolicitacaoHoraExtraPorEmpresaIdDataSolicitacao(empresaId, dataSolicitacao);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Convocados para Solicitação Hora Extra Por Solicitacao Hora Extra Id
        /// </summary>        
        /// <remarks>Retorna convocados para Solicitação Hora Extra Por Solicitacao Hora Extra Id</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: SolicitacaoHoraExtra/BuscarConvocadosPorSolicitacaoHoraExtraId
        [Route("BuscarConvocadosPorSolicitacaoHoraExtraId", Name = "BuscarConvocadosPorSolicitacaoHoraExtraId")]
        [HttpGet]
        public IHttpActionResult BuscarConvocadosPorSolicitacaoHoraExtraId(int solicitacaoHoraExtraID)
        {
            SolicitacaoHoraExtraFacade solicitacaoHoraExtra = new SolicitacaoHoraExtraFacade();

            var result = solicitacaoHoraExtra.BuscarConvocadosPorSolicitacaoHoraExtraID(solicitacaoHoraExtraID);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Solicitação Hora Extra Por Colaborador Id
        /// </summary>        
        /// <remarks>Retorna Solicitação Hora Extra Por Colaborador Id</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: SolicitacaoHoraExtra/BuscarSolicitacaoHoraExtraPorColaboradorId
        [Route("BuscarSolicitacaoHoraExtraPorColaboradorId", Name = "BuscarSolicitacaoHoraExtraPorColaboradorId")]
        [HttpGet]
        public IHttpActionResult BuscarSolicitacaoHoraExtraPorColaboradorId(int colaboradorId)
        {
            SolicitacaoHoraExtraFacade solicitacaoHoraExtra = new SolicitacaoHoraExtraFacade();

            var result = solicitacaoHoraExtra.BuscarSolicitacaoHoraExtraPorColaboradorId(colaboradorId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona Solicitação de Hora Extra
        /// </summary>        
        /// <remarks>Adiciona solicitação de Hora Extra</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: SolicitacaoHoraExtra/SolicitarHoraExtra
        [Route("SolicitarHoraExtra", Name = "SolicitarHoraExtra")]
        [HttpPost]
        public IHttpActionResult SolicitarHoraExtra(SolicitacaoHoraExtraModel solicitarHoraExtra)
        {
            SolicitacaoHoraExtraFacade solicitacaoHoraExtra = new SolicitacaoHoraExtraFacade();

            var result = solicitacaoHoraExtra.SolicitarHorExtra(solicitarHoraExtra);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Convocar Funcionarios para Hora Extra
        /// </summary>        
        /// <remarks>Funcionario convocados para Hora Extra</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: SolicitacaoHoraExtra/SolicitarHoraExtra
        [Route("ConvocarFuncionarios", Name = "ConvocarFuncionarios")]
        [HttpPost]
        public IHttpActionResult ConvocarFuncionarios(SolicitacaoHoraExtraModel solicitarHoraExtra)
        {
            SolicitacaoHoraExtraFacade solicitacaoHoraExtra = new SolicitacaoHoraExtraFacade();

            var result = solicitacaoHoraExtra.ConvocarFuncionarios(solicitarHoraExtra);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Aprova Solicitação de Hora Extra
        /// </summary>        
        /// <remarks>Aprova solicitação de Hora Extra</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: SolicitacaoHoraExtra/AprovarSolicitacaoHoraExtra
        [Route("AprovarSolicitacaoHoraExtra", Name = "AprovarSolicitacaoHoraExtra")]
        [HttpPost]
        public IHttpActionResult AprovarSolicitacaoHoraExtra(SolicitacaoHoraExtraModel solicitacaoHoraExtra)
        {
            SolicitacaoHoraExtraFacade solicitacaoHoraExtraFacade = new SolicitacaoHoraExtraFacade();

            var result = solicitacaoHoraExtraFacade.AprovarSolicitacaoHoraExtra(solicitacaoHoraExtra);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Reprova Solicitação de Hora Extra
        /// </summary>        
        /// <remarks>Reprova solicitação de Hora Extra</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: SolicitacaoHoraExtra/ReprovarSolicitacaoHoraExtra
        [Route("ReprovarSolicitacaoHoraExtra", Name = "ReprovarSolicitacaoHoraExtra")]
        [HttpPost]
        public IHttpActionResult ReprovarSolicitacaoHoraExtra(SolicitacaoHoraExtraModel solicitacaoHoraExtra)
        {
            SolicitacaoHoraExtraFacade solicitacaoHoraExtraFacade = new SolicitacaoHoraExtraFacade();

            var result = solicitacaoHoraExtraFacade.ReprovarSolicitacaoHoraExtra(solicitacaoHoraExtra);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}