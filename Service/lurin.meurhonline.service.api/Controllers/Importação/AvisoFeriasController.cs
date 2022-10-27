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
    [RoutePrefix("AvisoFerias")]
    [Authorize]
    public class AvisoFeriasController : ApiController
    {
        /// <summary>
        /// Adiciona Aviso de Ferias
        /// </summary>        
        /// <remarks>Adiciona o Cartao de Ponto</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>                

        //POST: AvisoFerias/ImportarAvisoFerias    
        [Route("ImportarAvisoFerias", Name = "ImportarAvisoFerias")]
        [HttpPost]
        public IHttpActionResult ImportarAvisoFerias(AvisoFeriasModel avisoFerias)
        {
            AvisoFeriasFacade avisoFeriasFacade = new AvisoFeriasFacade();

            var result = avisoFeriasFacade.AdicionarAvisoFerias(avisoFerias);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Aviso Ferias por Id
        /// </summary>        
        /// <remarks>Retorna o Aviso de Ferias por Id</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: AvisoFerias/BuscarAvisoFeriasPorId
        [Route("BuscarAvisoFeriasPorId", Name = "BuscarAvisoFeriasPorId")]
        [HttpGet]
        public IHttpActionResult BuscarAvisoFeriasPorId(int id)
        {
            AvisoFeriasFacade avisoFeriasFacade = new AvisoFeriasFacade();

            var result = avisoFeriasFacade.BuscarAvisoFeriasPorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Aviso de Ferias por Colaborador ID e Ano.
        /// </summary>        
        /// <remarks>Retorna a Lista de Aviso de Ferias por Colaborador ID e Ano</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: AvisoFerias/BuscarAvisoFeriasPorColaboradorIdAno
        [Route("BuscarAvisoFeriasPorColaboradorIdAno", Name = "BuscarAvisoFeriasPorColaboradorIdAno")]
        [HttpGet]
        public IHttpActionResult BuscarAvisoFeriasPorColaboradorIdAno(int colaboradorId, string ano)
        {
            AvisoFeriasFacade avisoFeriasFacade = new AvisoFeriasFacade();

            var result = avisoFeriasFacade.BuscarAvisoFeriasPorColaboradorIdAno(colaboradorId, ano);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
