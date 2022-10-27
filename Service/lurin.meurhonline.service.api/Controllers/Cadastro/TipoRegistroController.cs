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
    [RoutePrefix("TipoRegistro")]
    public class TipoRegistroController : ApiController
    {
        /// <summary>
        /// Busca TipoRegistro 
        /// </summary>        
        /// <remarks>Retorna o TipoRegistro</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: TipoRegistro/BuscarTipoRegistro
        [Route("BuscarTipoRegistro", Name = "BuscarTipoRegistro")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult BuscarTipoRegistro(TipoRegistroModel tipoRegistro)
        {
            TipoRegistroFacade tipoRegistroFacade = new TipoRegistroFacade();

            var result = tipoRegistroFacade.BuscarTipoRegistro(tipoRegistro);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Tudo Tipo de Registro 
        /// </summary>        
        /// <remarks>Retorna Tudo Tipo de Registro</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: TipoRegistro/BuscarTudoTipoRegistro
        [Route("BuscarTudoTipoRegistro", Name = "BuscarTudoTipoRegistro")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarTudoTipoRegistro()
        {
            TipoRegistroFacade tipoRegistroFacade = new TipoRegistroFacade();

            var result = tipoRegistroFacade.BuscarTudoTipoRegistro();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona TipoRegistro 
        /// </summary>        
        /// <remarks>Adiciona o TipoRegistro</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: TipoRegistro/AdicionarTipoRegistro      
        [Route("AdicionarTipoRegistro", Name = "AdicionarTipoRegistro")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult AdicionarTipoRegistro(TipoRegistroModel tipoRegistro)
        {
            TipoRegistroFacade tipoRegistroFacade = new TipoRegistroFacade();

            var result = tipoRegistroFacade.AdicionarTipoRegistro(tipoRegistro);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar TipoRegistro 
        /// </summary>        
        /// <remarks>Edita o TipoRegistro</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: TipoRegistro/EditarTipoRegistro      
        [Route("EditarTipoRegistro", Name = "EditarTipoRegistro")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult EditarTipoRegistro(TipoRegistroModel tipoRegistro)
        {
            TipoRegistroFacade tipoRegistroFacade = new TipoRegistroFacade();

            var result = tipoRegistroFacade.EditarTipoRegistro(tipoRegistro);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Excluir TipoRegistro 
        /// </summary>        
        /// <remarks>Excluir o TipoRegistro</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: TipoRegistro/ExcluirTipoRegistro      
        [Route("ExcluirTipoRegistro", Name = "ExcluirTipoRegistro")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult ExcluirTipoRegistro(int id)
        {
            TipoRegistroFacade tipoRegistroFacade = new TipoRegistroFacade();

            var result = tipoRegistroFacade.ExcluirTipoRegistro(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
