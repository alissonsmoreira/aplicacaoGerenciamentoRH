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
using lurin.meurhonline.domain.model.enumerator;

namespace lurin.meurhonline.service.api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("ColaboradorEstrangeiro")]
    [Authorize]
    public class ColaboradorEstrangeiroController : ApiController
    {
        /// <summary>
        /// Busca Estrangeiro Colaborador
        /// </summary>        
        /// <remarks>Retorna o Estrangeiro Colaborador</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: ColaboradorEstrangeiro/BuscarEstrangeiroColaborador
        [Route("BuscarEstrangeiroColaborador", Name = "BuscarEstrangeiroColaborador")]
        [HttpPost]
        public IHttpActionResult BuscarEstrangeiroColaborador(ColaboradorEstrangeiroModel colaboradorEstrangeiro)
        {
            ColaboradorEstrangeiroFacade colaboradorEstrangeiroFacade = new ColaboradorEstrangeiroFacade();

            var result = colaboradorEstrangeiroFacade.BuscarEstrangeiroColaborador(colaboradorEstrangeiro);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Estrangeiro Colaborador Pré-Admissão
        /// </summary>        
        /// <remarks>Retorna o Estrangeiro Colaborador</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: ColaboradorEstrangeiro/BuscarEstrangeiroColaboradorPreAdmissao
        [Route("BuscarEstrangeiroColaboradorPreAdmissao", Name = "BuscarEstrangeiroColaboradorPreAdmissao")]
        [HttpPost]
        public IHttpActionResult BuscarEstrangeiroColaboradorPreAdmissao(ColaboradorEstrangeiroModel colaboradorEstrangeiro)
        {
            ColaboradorEstrangeiroFacade colaboradorEstrangeiroFacade = new ColaboradorEstrangeiroFacade();

            var result = colaboradorEstrangeiroFacade.BuscarEstrangeiroColaboradorPreAdmissao(colaboradorEstrangeiro);

            if (result == null)
                return NotFound();

            return Ok(result);
        }        

        /// <summary>
        /// Busca Tudo Estrangeiro Colaborador Tipo Visto
        /// </summary>        
        /// <remarks>Retorna Tudo Estrangeiro Colaborador Tipo Visto</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: ColaboradorEstrangeiro/BuscarTudoEstrangeiroColaboradorTipoVisto
        [Route("BuscarTudoEstrangeiroColaboradorTipoVisto", Name = "BuscarTudoEstrangeiroColaboradorTipoVisto")]
        [HttpGet]
        public IHttpActionResult BuscarTudoEstrangeiroColaboradorTipoVisto()
        {
            ColaboradorEstrangeiroFacade colaboradorEstrangeiroFacade = new ColaboradorEstrangeiroFacade();

            var result = colaboradorEstrangeiroFacade.BuscarTudoEstrangeiroColaboradorTipoVisto();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona Estrangeiro Colaborador 
        /// </summary>        
        /// <remarks>Adiciona o Estrangeiro Colaborador </remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: ColaboradorEstrangeiro/AdicionarEstrangeiroColaborador      
        [Route("AdicionarEstrangeiroColaborador", Name = "AdicionarEstrangeiroColaborador")]
        [HttpPost]
        public IHttpActionResult AdicionarEstrangeiroColaborador(ColaboradorEstrangeiroModel colaboradorEstrangeiro)
        {
            ColaboradorEstrangeiroFacade colaboradorEstrangeiroFacade = new ColaboradorEstrangeiroFacade();

            var result = colaboradorEstrangeiroFacade.AdicionarEstrangeiroColaborador(colaboradorEstrangeiro);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar Estrangeiro Colaborador 
        /// </summary>        
        /// <remarks>Edita o Estrangeiro Colaborador</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: ColaboradorEstrangeiro/EditarEstrangeiroColaborador      
        [Route("EditarEstrangeiroColaborador", Name = "EditarEstrangeiroColaborador")]
        [HttpPost]
        public IHttpActionResult EditarEstrangeiroColaborador(ColaboradorEstrangeiroModel colaboradorEstrangeiro)
        {
            ColaboradorEstrangeiroFacade colaboradorEstrangeiroFacade = new ColaboradorEstrangeiroFacade();

            var result = colaboradorEstrangeiroFacade.EditarEstrangeiroColaborador(colaboradorEstrangeiro);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Estrangeiro Colaborador Pré-Admissão Por Id
        /// </summary>        
        /// <remarks>Retorna o Estrangeiro Colaborador</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: ColaboradorEstrangeiro/BuscarEstrangeiroColaboradorPreAdmissaoPorId
        [Route("BuscarEstrangeiroColaboradorPreAdmissaoPorId", Name = "BuscarEstrangeiroColaboradorPreAdmissaoPorId")]
        [HttpGet]
        public IHttpActionResult BuscarEstrangeiroColaboradorPreAdmissaoPorId(int id)
        {
            ColaboradorEstrangeiroFacade colaboradorEstrangeiroFacade = new ColaboradorEstrangeiroFacade();

            var result = colaboradorEstrangeiroFacade.BuscarEstrangeiroColaboradorPreAdmissaoPorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
