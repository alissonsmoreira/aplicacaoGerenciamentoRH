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
    [RoutePrefix("UnidadeNegocio")]
    public class UnidadeNegocioController : ApiController
    {
        /// <summary>
        /// Busca UnidadeNegocio 
        /// </summary>        
        /// <remarks>Retorna o UnidadeNegocio</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: UnidadeNegocio/BuscarUnidadeNegocio
        [Route("BuscarUnidadeNegocio", Name = "BuscarUnidadeNegocio")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult BuscarUnidadeNegocio(UnidadeNegocioModel UnidadeNegocio)
        {
            UnidadeNegocioFacade UnidadeNegocioFacade = new UnidadeNegocioFacade();

            var result = UnidadeNegocioFacade.BuscarUnidadeNegocio(UnidadeNegocio);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Tudo Unidade de Negocio 
        /// </summary>        
        /// <remarks>Retorna tudo Unidade de Negocio</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: UnidadeNegocio/BuscarTudoUnidadeNegocio
        [Route("BuscarTudoUnidadeNegocio", Name = "BuscarTudoUnidadeNegocio")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarTudoUnidadeNegocio()
        {
            UnidadeNegocioFacade UnidadeNegocioFacade = new UnidadeNegocioFacade();

            var result = UnidadeNegocioFacade.BuscarTudoUnidadeNegocio();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona UnidadeNegocio 
        /// </summary>        
        /// <remarks>Adiciona o UnidadeNegocio</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: UnidadeNegocio/AdicionarUnidadeNegocio      
        [Route("AdicionarUnidadeNegocio", Name = "AdicionarUnidadeNegocio")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult AdicionarUnidadeNegocio(UnidadeNegocioModel UnidadeNegocio)
        {
            UnidadeNegocioFacade UnidadeNegocioFacade = new UnidadeNegocioFacade();

            var result = UnidadeNegocioFacade.AdicionarUnidadeNegocio(UnidadeNegocio);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar UnidadeNegocio 
        /// </summary>        
        /// <remarks>Edita o UnidadeNegocio</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: UnidadeNegocio/EditarUnidadeNegocio      
        [Route("EditarUnidadeNegocio", Name = "EditarUnidadeNegocio")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult EditarUnidadeNegocio(UnidadeNegocioModel UnidadeNegocio)
        {
            UnidadeNegocioFacade UnidadeNegocioFacade = new UnidadeNegocioFacade();

            var result = UnidadeNegocioFacade.EditarUnidadeNegocio(UnidadeNegocio);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Excluir UnidadeNegocio 
        /// </summary>        
        /// <remarks>Excluir o UnidadeNegocio</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: UnidadeNegocio/ExcluirUnidadeNegocio      
        [Route("ExcluirUnidadeNegocio", Name = "ExcluirUnidadeNegocio")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult ExcluirUnidadeNegocio(int id)
        {
            UnidadeNegocioFacade UnidadeNegocioFacade = new UnidadeNegocioFacade();

            var result = UnidadeNegocioFacade.ExcluirUnidadeNegocio(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
