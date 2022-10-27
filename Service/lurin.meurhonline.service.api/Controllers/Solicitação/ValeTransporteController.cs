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
    [RoutePrefix("ValeTransporte")]
    [Authorize]
    public class ValeTransporteController : ApiController
    {

        /// <summary>
        /// Busca Solicitação Vale Transporte Por Colaborador Id
        /// </summary>        
        /// <remarks>Retorna solicitações de vale transporte por Colaborador Id</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: ValeTransporte/BuscarSolicitacaoValeTransportePorColaboradorId
        [Route("BuscarSolicitacaoValeTransportePorColaboradorId", Name = "BuscarSolicitacaoValeTransportePorColaboradorId")]
        [HttpGet]
        public IHttpActionResult BuscarSolicitacaoValeTransportePorColaboradorId(int id)
        {
            ValeTransporteFacade valeTransporteFacade = new ValeTransporteFacade();

            var result = valeTransporteFacade.BuscarSolicitacaoValeTransportePorColaboradorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Solicitação Vale Transporte
        /// </summary>        
        /// <remarks>Retorna solicitação de ValeTransporte</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: ValeTransporte/BuscarSolicitacaoValeTransporte
        [Route("BuscarSolicitacaoValeTransporte", Name = "BuscarSolicitacaoValeTransporte")]
        [HttpPost]
        public IHttpActionResult BuscarSolicitacaoValeTransporte(ValeTransporteModel valeTransporte)
        {
            ValeTransporteFacade valeTransporteFacade = new ValeTransporteFacade();

            var result = valeTransporteFacade.BuscarSolicitacaoValeTransporte(valeTransporte);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Tudo Vale Transporte Utilização
        /// </summary>        
        /// <remarks>Retorna o vale transporte utilização</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: ValeTransporte/BuscarTudoValeTransporteUtilizacao
        [Route("BuscarTudoValeTransporteUtilizacao", Name = "BuscarTudoValeTransporteUtilizacao")]
        [HttpGet]
        public IHttpActionResult BuscarTudoValeTransporteUtilizacao()
        {
            ValeTransporteFacade valeTransporteFacade = new ValeTransporteFacade();

            var result = valeTransporteFacade.BuscarTudoValeTransporteUtilizacao();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Tudo Vale Transporte Situação
        /// </summary>        
        /// <remarks>Retorna o vale transporte situação</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: ValeTransporte/BuscarTudoValeTransporteSituacao
        [Route("BuscarTudoValeTransporteSituacao", Name = "BuscarTudoValeTransporteSituacao")]
        [HttpGet]
        public IHttpActionResult BuscarTudoValeTransporteSituacao()
        {
            ValeTransporteFacade valeTransporteFacade = new ValeTransporteFacade();

            var result = valeTransporteFacade.BuscarTudoValeTransporteSituacao();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona Solicitação de Vale Transporte
        /// </summary>        
        /// <remarks>Adiciona solicitação de vale transporte</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: ValeTransporte/SolicitarValeTransporte
        [Route("SolicitarValeTransporte", Name = "SolicitarValeTransporte")]
        [HttpPost]
        public IHttpActionResult SolicitarValeTransporte(ValeTransporteModel valeTransporte)
        {
            ValeTransporteFacade valeTransporteFacade = new ValeTransporteFacade();

            var result = valeTransporteFacade.SolicitarValeTransporte(valeTransporte);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Aprova Solicitação de Vale Transporte
        /// </summary>        
        /// <remarks>Aprova solicitação de vale transporte</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: ValeTransporte/AprovarSolicitacaoValeTransporte
        [Route("AprovarSolicitacaoValeTransporte", Name = "AprovarSolicitacaoValeTransporte")]
        [HttpPost]
        public IHttpActionResult AprovarSolicitacaoValeTransporte(int id)
        {
            ValeTransporteFacade valeTransporteFacade = new ValeTransporteFacade();

            var result = valeTransporteFacade.AprovarSolicitacaoValeTransporte(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Reprova Solicitação de Vale Transporte
        /// </summary>        
        /// <remarks>Reprova solicitação de vale transporte</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: ValeTransporte/ReprovarSolicitacaoValeTransporte
        [Route("ReprovarSolicitacaoValeTransporte", Name = "ReprovarSolicitacaoValeTransporte")]
        [HttpPost]
        public IHttpActionResult ReprovarSolicitacaoValeTransporte(int id)
        {
            ValeTransporteFacade valeTransporteFacade = new ValeTransporteFacade();

            var result = valeTransporteFacade.ReprovarSolicitacaoValeTransporte(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
