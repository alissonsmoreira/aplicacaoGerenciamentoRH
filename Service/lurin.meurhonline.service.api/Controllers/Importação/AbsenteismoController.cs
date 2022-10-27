using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using lurin.meurhonline.application;
using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.service.api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Absenteismo")]
    [Authorize]
    public class AbsenteismoController : ApiController
    {
        /// <summary>
        /// Importar Absenteismo
        /// </summary>        
        /// <remarks>Importar Absenteismo</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Absenteismo/ImportarAbsenteismo
        [Route("ImportarAbsenteismo", Name = "ImportarAbsenteismo")]
        [HttpPost]
        public IHttpActionResult ImportarAbsenteismo(AbsenteismoModel absenteismo)
        {
            AbsenteismoFacade absenteismoFacade = new AbsenteismoFacade();
            var result = absenteismoFacade.ImportarAbsenteismo(absenteismo);
            
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Buscar Absenteismo por Colaborador Id
        /// </summary>        
        /// <remarks>Buscar Absenteismo por Colaborador Id</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Absenteismo/BuscarAbsenteismoPorColaboradorId
        [Route("BuscarAbsenteismoPorColaboradorId", Name = "BuscarAbsenteismoPorColaboradorId")]
        [HttpGet]
        public IHttpActionResult BuscarAbsenteismoPorColaboradorId(int colaboradorId)
        {
            AbsenteismoFacade absenteismoFacade = new AbsenteismoFacade();

            var result = absenteismoFacade.BuscarAbsenteismoPorColaboradorId(colaboradorId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Buscar Absenteismo por Ano e Mes
        /// </summary>        
        /// <remarks>Buscar Absenteismo por Ano e Mes</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Absenteismo/BuscarAbsenteismoPorAnoMes
        [Route("BuscarAbsenteismoPorAnoMes", Name = "BuscarAbsenteismoPorAnoMes")]
        [HttpGet]
        public IHttpActionResult BuscarAbsenteismoPorAnoMes(string ano, string mes)
        {
            AbsenteismoFacade absenteismoFacade = new AbsenteismoFacade();

            var result = absenteismoFacade.BuscarAbsenteismoPorAnoMes(ano, mes);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Buscar Absenteismo por Gestor Id, Ano e Mes
        /// </summary>        
        /// <remarks>Buscar Absenteismo por Gestor Id, Ano e Mes</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Absenteismo/BuscarAbsenteismoPorGestorIdAnoMes
        [Route("BuscarAbsenteismoPorGestorIdAnoMes", Name = "BuscarAbsenteismoPorGestorIdAnoMes")]
        [HttpGet]
        public IHttpActionResult BuscarAbsenteismoPorGestorIdAnoMes(int gestorId, string ano, string mes)
        {
            AbsenteismoFacade absenteismoFacade = new AbsenteismoFacade();

            var result = absenteismoFacade.BuscarAbsenteismoPorGestorIdAnoMes(gestorId, ano, mes);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
