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
    [RoutePrefix("EstadoCivil")]
    [Authorize]
    public class EstadoCivilController : ApiController
    {
        /// <summary>
        /// Busca Tudo Estado Civil
        /// </summary>        
        /// <remarks>Retorna todos os Estado Civil</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: EstadoCivil/BuscarTudoEstadoCivil
        [Route("BuscarTudoEstadoCivil", Name = "BuscarTudoEstadoCivil")]
        [HttpGet]
        public IHttpActionResult BuscarTudoEstadoCivil()
        {
            EstadoCivilFacade EstadoCivilFacade = new EstadoCivilFacade();

            var result = EstadoCivilFacade.BuscarTudoEstadoCivil();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

    }
}
