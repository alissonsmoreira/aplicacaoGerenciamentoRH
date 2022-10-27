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
    [RoutePrefix("Ferias")]
    [Authorize]
    public class FeriasController : ApiController
    {
        /// <summary>
        /// Importar Ferias 
        /// </summary>        
        /// <remarks>Importar Ferias</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Ferias/ImportarFerias
        [Route("ImportarFerias", Name = "ImportarFerias")]
        [HttpPost]
        public IHttpActionResult ImportarFerias(FeriasModel Ferias)
        {
            FeriasFacade FeriasFacade = new FeriasFacade();
            
            var result = FeriasFacade.ImportarFerias(Ferias);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Buscar Recibo de ferias por Empresa
        /// </summary>        
        /// <remarks>Buscar Recibo de ferias por Empresa</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Ferias/BuscarFeriasPorEmpresaId
        [Route("BuscarFeriasPorEmpresaId", Name = "BuscarFeriasPorEmpresaId")]
        [HttpGet]
        public IHttpActionResult BuscarFeriasPorEmpresaId(int empresaId)
        {
            FeriasFacade FeriasFacade = new FeriasFacade();

            var result = FeriasFacade.BuscarFeriasPorEmpresaId(empresaId);

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

        //GET: Ferias/BuscarFeriasPorColaboradorId
        [Route("BuscarFeriasPorColaboradorId", Name = "BuscarFeriasPorColaboradorId")]
        [HttpGet]
        public IHttpActionResult BuscarFeriasPorColaboradorId(int colaboradorId)
        {
            FeriasFacade FeriasFacade = new FeriasFacade();

            var result = FeriasFacade.BuscarFeriasPorColaboradorId(colaboradorId);

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

        //GET: Ferias/BuscarFeriasPorId
        [Route("BuscarFeriasPorId", Name = "BuscarFeriasPorId")]
        [HttpGet]
        public IHttpActionResult BuscarFeriasPorId(int id)
        {
            FeriasFacade FeriasFacade = new FeriasFacade();

            var result = FeriasFacade.BuscarFeriasPorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
