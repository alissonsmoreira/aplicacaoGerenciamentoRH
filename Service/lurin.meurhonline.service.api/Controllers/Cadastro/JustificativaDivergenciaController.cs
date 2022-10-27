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
    [RoutePrefix("JustificativaDivergencia")]
    public class JustificativaDivergenciaController : ApiController
    {
        /// <summary>
        /// Busca JustificativaDivergencia 
        /// </summary>        
        /// <remarks>Retorna o JustificativaDivergencia</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: JustificativaDivergencia/BuscarJustificativaDivergencia
        [Route("BuscarJustificativaDivergencia", Name = "BuscarJustificativaDivergencia")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult BuscarJustificativaDivergencia(JustificativaDivergenciaModel justificativaDivergencia)
        {
            JustificativaDivergenciaFacade justificativaDivergenciaFacade = new JustificativaDivergenciaFacade();

            var result = justificativaDivergenciaFacade.BuscarJustificativaDivergencia(justificativaDivergencia);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Route("BuscarTodasJustificativasDivergencia", Name = "BuscarTodasJustificativasDivergencia")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarTodasJustificativasDivergencia()
        {
            JustificativaDivergenciaFacade justificativaDivergenciaFacade = new JustificativaDivergenciaFacade();

            var result = justificativaDivergenciaFacade.BuscarTodasJustificativasDivergencia();

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        /// <summary>
        /// Adiciona JustificativaDivergencia 
        /// </summary>        
        /// <remarks>Adiciona o JustificativaDivergencia</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: JustificativaDivergencia/AdicionarJustificativaDivergencia      
        [Route("AdicionarJustificativaDivergencia", Name = "AdicionarJustificativaDivergencia")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult AdicionarJustificativaDivergencia(JustificativaDivergenciaModel justificativaDivergencia)
        {
            JustificativaDivergenciaFacade justificativaDivergenciaFacade = new JustificativaDivergenciaFacade();

            var result = justificativaDivergenciaFacade.AdicionarJustificativaDivergencia(justificativaDivergencia);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar JustificativaDivergencia 
        /// </summary>        
        /// <remarks>Edita o JustificativaDivergencia</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: JustificativaDivergencia/EditarJustificativaDivergencia      
        [Route("EditarJustificativaDivergencia", Name = "EditarJustificativaDivergencia")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult EditarJustificativaDivergencia(JustificativaDivergenciaModel justificativaDivergencia)
        {
            JustificativaDivergenciaFacade justificativaDivergenciaFacade = new JustificativaDivergenciaFacade();

            var result = justificativaDivergenciaFacade.EditarJustificativaDivergencia(justificativaDivergencia);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Excluir JustificativaDivergencia 
        /// </summary>        
        /// <remarks>Excluir o JustificativaDivergencia</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: JustificativaDivergencia/ExcluirJustificativaDivergencia      
        [Route("ExcluirJustificativaDivergencia", Name = "ExcluirJustificativaDivergencia")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult ExcluirJustificativaDivergencia(int id)
        {
            JustificativaDivergenciaFacade justificativaDivergenciaFacade = new JustificativaDivergenciaFacade();

            var result = justificativaDivergenciaFacade.ExcluirJustificativaDivergencia(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
