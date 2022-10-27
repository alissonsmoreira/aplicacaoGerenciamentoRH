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
    [RoutePrefix("InformeRendimento")]
    [Authorize]
    public class InformeRendimentoController : ApiController
    {
        /// <summary>
        /// Importa Informe Rendimento 
        /// </summary>        
        /// <remarks>Importa Informe de Rendimento</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: InformeRendimento/ImportarInformeRendimento
        [Route("ImportarInformeRendimento", Name = "ImportarInformeRendimento")]
        [HttpPost]
        public IHttpActionResult ImportarInformeRendimento(InformeRendimentoModel informeRendimento)
        {
            InformeRendimentoFacade informeRendimentoFacade = new InformeRendimentoFacade();
            
            var result = informeRendimentoFacade.ImportarInformeRendimento(informeRendimento);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Buscar Informe Rendimento por Colaborador Id e Ano
        /// </summary>        
        /// <remarks>Buscar Informe Rendimento por Colaborador Id e ano</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: InformeRendimento/BuscarInformeRendimentoPorColaboradorIdAno
        [Route("BuscarInformeRendimentoPorColaboradorIdAno", Name = "BuscarInformeRendimentoPorColaboradorIdAno")]
        [HttpGet]
        public IHttpActionResult BuscarInformeRendimentoPorColaboradorIdAno(int colaboradorId, string ano)
        {
            InformeRendimentoFacade informeRendimentoFacade = new InformeRendimentoFacade();

            var result = informeRendimentoFacade.BuscarInformeRendimentoPorColaboradorIdAno(colaboradorId, ano);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Buscar Informe Rendimento por ID
        /// </summary>        
        /// <remarks>Buscar Informe Rendimento por ID</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: InformeRendimento/BuscarInformeRendimentoPorId
        [Route("BuscarInformeRendimentoPorId", Name = "BuscarInformeRendimentoPorId")]
        [HttpGet]
        public IHttpActionResult BuscarInformeRendimentoPorId(int id)
        {
            InformeRendimentoFacade informeRendimentoFacade = new InformeRendimentoFacade();

            var result = informeRendimentoFacade.BuscarInformeRendimentoPorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
