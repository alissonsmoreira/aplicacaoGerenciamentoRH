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
    [RoutePrefix("Holerite")]
   // [Authorize]
    public class HoleriteController : ApiController
    {
        /// <summary>
        /// Adiciona Holerite
        /// </summary>        
        /// <remarks>Adiciona Holerite</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>                

        //POST: Holerite/ImportarHolerite    
        [Route("ImportarHolerite", Name = "ImportarHolerite")]
        [HttpPost]
        public IHttpActionResult ImportarHolerite(HoleriteModel holerite)
        {
            HoleriteFacade holeriteFacade = new HoleriteFacade();

            var result = holeriteFacade.AdicionarHolerite(holerite);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Holerite por Id
        /// </summary>        
        /// <remarks>Retorna o Holerite por Id</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Holerite/BuscarHoleritePorId
        [Route("BuscarHoleritePorId", Name = "BuscarHoleritePorId")]
        [HttpGet]
        public IHttpActionResult BuscarHoleritePorId(int id)
        {
            HoleriteFacade holeriteFacade = new HoleriteFacade();

            var result = holeriteFacade.BuscarHoleritePorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Holerite por Colaborador ID, Mês e Ano.
        /// </summary>        
        /// <remarks>Retorna o Holerite por Colaborador ID, Mês e Ano</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Holerite/BuscarHoleritePorColaboradorIdMesAno
        [Route("BuscarHoleritePorColaboradorIdMesAno", Name = "BuscarHoleritePorColaboradorIdMesAno")]
        [HttpGet]
        public IHttpActionResult BuscarHoleritePorColaboradorIdMesAno(int colaboradorId, string mes, string ano, int? empresaId)
        {
            HoleriteFacade holeriteFacade = new HoleriteFacade();

            var result = holeriteFacade.BuscarHoleritePorColaboradorIdMesAno(colaboradorId, mes, ano, empresaId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        //POST: Holerite/ExcluirHoleritesSelecionados
        [Route("ExcluirHoleritesSelecionados", Name = "ExcluirHoleritesSelecionados")]
        [HttpPost]
        public IHttpActionResult ExcluirHoleritesSelecionados([FromBody] int[] ids)
        {
            HoleriteFacade holeriteFacade = new HoleriteFacade();
            var result = holeriteFacade.ExcluirHoleritesSelecionados(ids);

            if (!result)
                return BadRequest();

            return Ok();
        }
    }
}