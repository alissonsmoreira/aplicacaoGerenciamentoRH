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
using lurin.meurhonline.domain;
using lurin.meurhonline.domain.Interface;

namespace lurin.meurhonline.service.api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("ReciboFerias")]
    [Authorize]
    public class ReciboFeriasController : ApiController
    {
        /// <summary>
        /// Importar Recibo Ferias 
        /// </summary>        
        /// <remarks>Importar Recibo de Ferias</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: ReciboFerias/ImportarReciboFerias
        [Route("ImportarReciboFerias", Name = "ImportarReciboFerias")]
        [HttpPost]
        public IHttpActionResult ImportarReciboFerias(ReciboFeriasModel reciboFerias)
        {
            ReciboFeriasFacade reciboFeriasFacade = new ReciboFeriasFacade();
            
            var result = reciboFeriasFacade.ImportarReciboFerias(reciboFerias);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Buscar Recibo de ferias por Colaborador Id
        /// </summary>        
        /// <remarks>Buscar Recibo de ferias por Colaborador Id</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: ReciboFerias/BuscarReciboFeriasPorColaboradorId
        [Route("BuscarReciboFeriasPorAnoColaboradorId", Name = "BuscarReciboFeriasPorAnoColaboradorId")]
        [HttpGet]
        public IHttpActionResult BuscarReciboFeriasPorAnoColaboradorId(string ano, int colaboradorId)
        {
            ReciboFeriasFacade reciboFeriasFacade = new ReciboFeriasFacade();

            var result = reciboFeriasFacade.BuscarReciboFeriasPorAnoColaboradorId(ano, colaboradorId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Buscar Recibo de ferias por ID
        /// </summary>        
        /// <remarks>Buscar Recibo de ferias por ID</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: ReciboFerias/BuscarReciboFeriasPorId
        [Route("BuscarReciboFeriasPorId", Name = "BuscarReciboFeriasPorId")]
        [HttpGet]
        public IHttpActionResult BuscarReciboFeriasPorId(int id)
        {
            ReciboFeriasFacade reciboFeriasFacade = new ReciboFeriasFacade();

            var result = reciboFeriasFacade.BuscarReciboFeriasPorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
