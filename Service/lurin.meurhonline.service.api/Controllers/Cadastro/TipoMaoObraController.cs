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
    [RoutePrefix("TipoMaoObra")]
    public class TipoMaoObraController : ApiController
    {
        /// <summary>
        /// Busca TipoMaoObra 
        /// </summary>        
        /// <remarks>Retorna o TipoMaoObra</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: TipoMaoObra/BuscarTipoMaoObra
        [Route("BuscarTipoMaoObra", Name = "BuscarTipoMaoObra")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult BuscarTipoMaoObra(TipoMaoObraModel tipoMaoObra)
        {
            TipoMaoObraFacade tipoMaoObraFacade = new TipoMaoObraFacade();

            var result = tipoMaoObraFacade.BuscarTipoMaoObra(tipoMaoObra);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Tudo Tipo de Mao de Obra 
        /// </summary>        
        /// <remarks>Retorna Tudo Tipo de Mao de Obra</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: TipoMaoObra/BuscarTudoTipoMaoObra
        [Route("BuscarTudoTipoMaoObra", Name = "BuscarTudoTipoMaoObra")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarTudoTipoMaoObra()
        {
            TipoMaoObraFacade tipoMaoObraFacade = new TipoMaoObraFacade();

            var result = tipoMaoObraFacade.BuscarTudoTipoMaoObra();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona TipoMaoObra 
        /// </summary>        
        /// <remarks>Adiciona o TipoMaoObra</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: TipoMaoObra/AdicionarTipoMaoObra      
        [Route("AdicionarTipoMaoObra", Name = "AdicionarTipoMaoObra")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult AdicionarTipoMaoObra(TipoMaoObraModel tipoMaoObra)
        {
            TipoMaoObraFacade tipoMaoObraFacade = new TipoMaoObraFacade();

            var result = tipoMaoObraFacade.AdicionarTipoMaoObra(tipoMaoObra);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar TipoMaoObra 
        /// </summary>        
        /// <remarks>Edita o TipoMaoObra</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: TipoMaoObra/EditarTipoMaoObra      
        [Route("EditarTipoMaoObra", Name = "EditarTipoMaoObra")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult EditarTipoMaoObra(TipoMaoObraModel tipoMaoObra)
        {
            TipoMaoObraFacade tipoMaoObraFacade = new TipoMaoObraFacade();

            var result = tipoMaoObraFacade.EditarTipoMaoObra(tipoMaoObra);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Excluir TipoMaoObra 
        /// </summary>        
        /// <remarks>Excluir o TipoMaoObra</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: TipoMaoObra/ExcluirTipoMaoObra      
        [Route("ExcluirTipoMaoObra", Name = "ExcluirTipoMaoObra")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult ExcluirTipoMaoObra(int id)
        {
            TipoMaoObraFacade tipoMaoObraFacade = new TipoMaoObraFacade();

            var result = tipoMaoObraFacade.ExcluirTipoMaoObra(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
