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
    [RoutePrefix("Atestado")]
    [Authorize]
    public class AtestadoController : ApiController
    {

        /// <summary>
        /// Busca Solicitação Atestado Por Colaborador Id
        /// </summary>        
        /// <remarks>Retorna solicitações de Atestado por Colaborador Id</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Atestado/BuscarLancamentoAtestadoPorColaboradorId
        [Route("BuscarLancamentoAtestadoPorColaboradorId", Name = "BuscarLancamentoAtestadoPorColaboradorId")]
        [HttpGet]
        public IHttpActionResult BuscarLancamentoAtestadoPorColaboradorId(int id)
        {
            AtestadoFacade atestadoFacade = new AtestadoFacade();

            var result = atestadoFacade.BuscarLancamentoAtestadoPorColaboradorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Solicitação Atestado
        /// </summary>        
        /// <remarks>Retorna solicitação de Atestado</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Atestado/BuscarLancamentoAtestado
        [Route("BuscarLancamentoAtestado", Name = "BuscarLancamentoAtestado")]
        [HttpPost]
        public IHttpActionResult BuscarLancamentoAtestado(AtestadoModel atestado)
        {
            AtestadoFacade atestadoFacade = new AtestadoFacade();

            var result = atestadoFacade.BuscarLancamentoAtestado(atestado);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

       

        //POST: Atestado/LancarAtestado
        [Route("LancarAtestado", Name = "LancarAtestado")]
        [HttpPost]
        public IHttpActionResult LancarAtestado(AtestadoModel atestado)
        {
            AtestadoFacade atestadoFacade = new AtestadoFacade();

            var result = atestadoFacade.LancarAtestado(atestado);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Aprova Lançamento de Atestado
        /// </summary>        
        /// <remarks>Aprova lançamento de Atestado</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Atestado/AprovarLancamentoAtestado
        [Route("AprovarLancamentoAtestado", Name = "AprovarLancamentoAtestado")]
        [HttpPost]
        public IHttpActionResult AprovarLancamentoAtestado(int id)
        {
            AtestadoFacade atestadoFacade = new AtestadoFacade();

            var result = atestadoFacade.AprovarLancamentoAtestado(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Reprova Lançamento de Atestado
        /// </summary>        
        /// <remarks>Reprova solicitação de Atestado</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Atestado/ReprovarLancamentoAtestado
        [Route("ReprovarLancamentoAtestado", Name = "ReprovarLancamentoAtestado")]
        [HttpPost]
        public IHttpActionResult ReprovarLancamentoAtestado(int id)
        {
            AtestadoFacade atestadoFacade = new AtestadoFacade();

            var result = atestadoFacade.ReprovarLancamentoAtestado(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Imagem Atestado
        /// </summary>        
        /// <remarks>Retorna o arquivo com a imagen do atestado</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Atestado/BuscarImagemAtestado
        [Route("BuscarImagemAtestado", Name = "BuscarImagemAtestado")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarImagemAtestado(int id)
        {
            AtestadoFacade atestadoFacade = new AtestadoFacade();

            var result = atestadoFacade.BuscarImagemAtestado(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
