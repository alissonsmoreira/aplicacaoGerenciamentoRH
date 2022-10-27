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
    [RoutePrefix("LinhaVT")]
    public class LinhaVTController : ApiController
    {
        /// <summary>
        /// Busca Linha VT 
        /// </summary>        
        /// <remarks>Retorna a Linha de Vale Transporte</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: LinhaVT/BuscarLinhaVT
        [Route("BuscarLinhaVT", Name = "BuscarLinhaVT")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult BuscarLinhaVT(LinhaVTModel LinhaVT)
        {
            LinhaVTFacade LinhaVTFacade = new LinhaVTFacade();

            var result = LinhaVTFacade.BuscarLinhaVT(LinhaVT);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Linha VT por Operadora VT Id
        /// </summary>        
        /// <remarks>Retorna a Linha de Vale Transporte por Operadora de Vale Transporte Id</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: LinhaVT/BuscarLinhaVTPorOperadoraVTId
        [Route("BuscarLinhaVTPorOperadoraVTId", Name = "BuscarLinhaVTPorOperadoraVTId")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarLinhaVTPorOperadoraVTId(int id)
        {
            LinhaVTFacade LinhaVTFacade = new LinhaVTFacade();

            var result = LinhaVTFacade.BuscarLinhaVTPorOperadoraVTId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona Linha VT 
        /// </summary>        
        /// <remarks>Adiciona a Linha de Vale Transporte</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>                

        //POST: LinhaVT/AdicionarLinhaVT      
        [Route("AdicionarLinhaVT", Name = "AdicionarLinhaVT")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult AdicionarLinhaVT(LinhaVTModel LinhaVT)
        {
            LinhaVTFacade LinhaVTFacade = new LinhaVTFacade();

            var result = LinhaVTFacade.AdicionarLinhaVT(LinhaVT);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar Linha VT 
        /// </summary>        
        /// <remarks>Edita a Linha de Vale Transporte</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: LinhaVT/EditarLinhaVT      
        [Route("EditarLinhaVT", Name = "EditarLinhaVT")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult EditarLinhaVT(LinhaVTModel LinhaVT)
        {
            LinhaVTFacade LinhaVTFacade = new LinhaVTFacade();

            var result = LinhaVTFacade.EditarLinhaVT(LinhaVT);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Excluir Linha VT 
        /// </summary>        
        /// <remarks>Exclui a Linha de Vale Transporte</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: LinhaVT/ExcluirLinhaVT      
        [Route("ExcluirLinhaVT", Name = "ExcluirLinhaVT")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult ExcluirLinhaVT(int id)
        {
            LinhaVTFacade LinhaVTFacade = new LinhaVTFacade();

            var result = LinhaVTFacade.ExcluirLinhaVT(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
