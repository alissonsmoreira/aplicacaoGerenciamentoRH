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
    [RoutePrefix("Sindicato")]
    public class SindicatoController : ApiController
    {
        /// <summary>
        /// Busca Sindicato 
        /// </summary>        
        /// <remarks>Retorna o Sindicato</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Sindicato/BuscarSindicato
        [Route("BuscarSindicato", Name = "BuscarSindicato")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult BuscarSindicato(SindicatoModel Sindicato)
        {
            SindicatoFacade SindicatoFacade = new SindicatoFacade();

            var result = SindicatoFacade.BuscarSindicato(Sindicato);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Tudo Sindicato 
        /// </summary>        
        /// <remarks>Retorna Tudo Sindicato</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Sindicato/BuscarTudoSindicato
        [Route("BuscarTudoSindicato", Name = "BuscarTudoSindicato")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarTudoSindicato()
        {
            SindicatoFacade SindicatoFacade = new SindicatoFacade();

            var result = SindicatoFacade.BuscarTudoSindicato();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona Sindicato 
        /// </summary>        
        /// <remarks>Adiciona o Sindicato</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: Sindicato/AdicionarSindicato      
        [Route("AdicionarSindicato", Name = "AdicionarSindicato")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult AdicionarSindicato(SindicatoModel Sindicato)
        {
            SindicatoFacade SindicatoFacade = new SindicatoFacade();

            var result = SindicatoFacade.AdicionarSindicato(Sindicato);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar Sindicato 
        /// </summary>        
        /// <remarks>Edita o Sindicato</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: Sindicato/EditarSindicato      
        [Route("EditarSindicato", Name = "EditarSindicato")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult EditarSindicato(SindicatoModel Sindicato)
        {
            SindicatoFacade SindicatoFacade = new SindicatoFacade();

            var result = SindicatoFacade.EditarSindicato(Sindicato);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Excluir Sindicato 
        /// </summary>        
        /// <remarks>Excluir o Sindicato</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Sindicato/ExcluirSindicato      
        [Route("ExcluirSindicato", Name = "ExcluirSindicato")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult ExcluirSindicato(int id)
        {
            SindicatoFacade SindicatoFacade = new SindicatoFacade();

            var result = SindicatoFacade.ExcluirSindicato(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
