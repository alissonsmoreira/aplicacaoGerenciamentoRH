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
    [RoutePrefix("MotivoHoraExtra")]
    public class MotivoHoraExtraController : ApiController
    {
        /// <summary>
        /// Busca MotivoHoraExtra 
        /// </summary>        
        /// <remarks>Retorna o MotivoHoraExtra</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: MotivoHoraExtra/BuscarMotivoHoraExtra
        [Route("BuscarMotivoHoraExtra", Name = "BuscarMotivoHoraExtra")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult BuscarMotivoHoraExtra(MotivoHoraExtraModel motivoHoraExtra)
        {
            MotivoHoraExtraFacade motivoHoraExtraFacade = new MotivoHoraExtraFacade();

            var result = motivoHoraExtraFacade.BuscarMotivoHoraExtra(motivoHoraExtra);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        /// <summary>
        /// Adiciona MotivoHoraExtra 
        /// </summary>        
        /// <remarks>Adiciona o MotivoHoraExtra</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: MotivoHoraExtra/AdicionarMotivoHoraExtra      
        [Route("AdicionarMotivoHoraExtra", Name = "AdicionarMotivoHoraExtra")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult AdicionarMotivoHoraExtra(MotivoHoraExtraModel motivoHoraExtra)
        {
            MotivoHoraExtraFacade motivoHoraExtraFacade = new MotivoHoraExtraFacade();

            var result = motivoHoraExtraFacade.AdicionarMotivoHoraExtra(motivoHoraExtra);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar MotivoHoraExtra 
        /// </summary>        
        /// <remarks>Edita o MotivoHoraExtra</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: MotivoHoraExtra/EditarMotivoHoraExtra      
        [Route("EditarMotivoHoraExtra", Name = "EditarMotivoHoraExtra")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult EditarMotivoHoraExtra(MotivoHoraExtraModel motivoHoraExtra)
        {
            MotivoHoraExtraFacade motivoHoraExtraFacade = new MotivoHoraExtraFacade();

            var result = motivoHoraExtraFacade.EditarMotivoHoraExtra(motivoHoraExtra);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Excluir MotivoHoraExtra 
        /// </summary>        
        /// <remarks>Excluir o MotivoHoraExtra</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: MotivoHoraExtra/ExcluirMotivoHoraExtra      
        [Route("ExcluirMotivoHoraExtra", Name = "ExcluirMotivoHoraExtra")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult ExcluirMotivoHoraExtra(int id)
        {
            MotivoHoraExtraFacade motivoHoraExtraFacade = new MotivoHoraExtraFacade();

            var result = motivoHoraExtraFacade.ExcluirMotivoHoraExtra(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
