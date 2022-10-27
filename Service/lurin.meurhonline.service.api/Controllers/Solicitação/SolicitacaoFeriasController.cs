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
    [RoutePrefix("Ferias")]
    [Authorize]
    public class SolicitacaoFeriasController : ApiController
    {
        /// <summary>
        /// Adiciona Solicitação de Ferias
        /// </summary>        
        /// <remarks>Adiciona solicitação de ferias</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Ferias/SolicitarFerias
        [Route("SolicitarFerias", Name = "SolicitarFerias")]
        [HttpPost]
        public IHttpActionResult SolicitarFerias(FeriasPeriodoModel feriasPeriodo)
        {
            FeriasFacade feriasFacade = new FeriasFacade();

            var result = feriasFacade.SolicitarFerias(feriasPeriodo);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Aprovação de Ferias
        /// </summary>        
        /// <remarks>Aprovação de ferias</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Ferias/AprovarFerias
        [Route("AprovarFerias", Name = "AprovarFerias")]
        [HttpPost]
        public IHttpActionResult AprovarFerias(FeriasPeriodoModel feriasPeriodo)
        {
            FeriasFacade feriasFacade = new FeriasFacade();

            var result = feriasFacade.AprovarFerias(feriasPeriodo);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Reprovação de Ferias
        /// </summary>        
        /// <remarks>Reprovação de ferias</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Ferias/ReprovarFerias
        [Route("ReprovarFerias", Name = "ReprovarFerias")]
        [HttpPost]
        public IHttpActionResult ReprovarFerias(FeriasPeriodoModel feriasPeriodo)
        {
            FeriasFacade feriasFacade = new FeriasFacade();

            var result = feriasFacade.ReprovarFerias(feriasPeriodo);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
