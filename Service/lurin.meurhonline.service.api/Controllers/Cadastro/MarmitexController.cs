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
    [RoutePrefix("Marmitex")]
    public class MarmitexController : ApiController
    {
        /// <summary>
        /// Busca Marmitex 
        /// </summary>        
        /// <remarks>Retorna o Marmitex</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Marmitex/BuscarMarmitex
        [Route("BuscarMarmitex", Name = "BuscarMarmitex")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult BuscarMarmitex(MarmitexModel marmitex)
        {
            MarmitexFacade marmitexFacade = new MarmitexFacade();

            var result = marmitexFacade.BuscarMarmitex(marmitex);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        /// <summary>
        /// Adiciona Marmitex 
        /// </summary>        
        /// <remarks>Adiciona o Marmitex</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: Marmitex/AdicionarMarmitex      
        [Route("AdicionarMarmitex", Name = "AdicionarMarmitex")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult AdicionarMarmitex(MarmitexModel marmitex)
        {
            MarmitexFacade marmitexFacade = new MarmitexFacade();

            var result = marmitexFacade.AdicionarMarmitex(marmitex);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar Marmitex 
        /// </summary>        
        /// <remarks>Edita o Marmitex</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: Marmitex/EditarMarmitex      
        [Route("EditarMarmitex", Name = "EditarMarmitex")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult EditarMarmitex(MarmitexModel marmitex)
        {
            MarmitexFacade marmitexFacade = new MarmitexFacade();

            var result = marmitexFacade.EditarMarmitex(marmitex);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Excluir Marmitex 
        /// </summary>        
        /// <remarks>Excluir o Marmitex</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Marmitex/ExcluirMarmitex      
        [Route("ExcluirMarmitex", Name = "ExcluirMarmitex")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult ExcluirMarmitex(int id)
        {
            MarmitexFacade marmitexFacade = new MarmitexFacade();

            var result = marmitexFacade.ExcluirMarmitex(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
