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
    [RoutePrefix("ColaboradorEmpregador")]
    [Authorize]
    public class ColaboradorEmpregadorController : ApiController
    {
        /// <summary>
        /// Busca Empregador Colaborador
        /// </summary>        
        /// <remarks>Retorna o Empregador Colaborador</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: ColaboradorEmpregador/BuscarEmpregadorColaborador
        [Route("BuscarEmpregadorColaborador", Name = "BuscarEmpregadorColaborador")]
        [HttpPost]
        public IHttpActionResult BuscarEmpregadorColaborador(ColaboradorEmpregadorModel colaboradorEmpregador)
        {
            ColaboradorEmpregadorFacade colaboradorEmpregadorFacade = new ColaboradorEmpregadorFacade();

            var result = colaboradorEmpregadorFacade.BuscarEmpregadorColaborador(colaboradorEmpregador);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Empregador Colaborador
        /// </summary>        
        /// <remarks>Retorna o Empregador Colaborador</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: ColaboradorEmpregador/BuscarEmpregadorColaboradorPreAdmissao
        [Route("BuscarEmpregadorColaboradorPreAdmissao", Name = "BuscarEmpregadorColaboradorPreAdmissao")]
        [HttpPost]
        public IHttpActionResult BuscarEmpregadorColaboradorPreAdmissao(ColaboradorEmpregadorModel colaboradorEmpregador)
        {
            ColaboradorEmpregadorFacade colaboradorEmpregadorFacade = new ColaboradorEmpregadorFacade();

            var result = colaboradorEmpregadorFacade.BuscarEmpregadorColaboradorPreAdmissao(colaboradorEmpregador);

            if (result == null)
                return NotFound();

            return Ok(result);
        }        

        /// <summary>
        /// Adiciona Empregador Colaborador 
        /// </summary>        
        /// <remarks>Adiciona o Empregador Colaborador </remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        /// <summary>
        /// Busca colaborador empregador por nome 
        /// </summary>        
        /// <remarks>Retorna o colaborador empregador por nome</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: ColaboradorEmpregador/BuscarEmpregadorColaboradorPorNome
        [Route("BuscarEmpregadorColaboradorPorNome", Name = "BuscarEmpregadorColaboradorPorNome")]
        [HttpGet]
        public IHttpActionResult BuscarEmpregadorColaboradorPorNome(string nome)
        {
            ColaboradorEmpregadorFacade colaboradorEmpregadorFacade = new ColaboradorEmpregadorFacade();

            var result = colaboradorEmpregadorFacade.BuscarColaboradorEmpregadorPorNome(nome);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        //POST: ColaboradorEmpregador/AdicionarEmpregadorColaborador      
        [Route("AdicionarEmpregadorColaborador", Name = "AdicionarEmpregadorColaborador")]
        [HttpPost]
        public IHttpActionResult AdicionarEmpregadorColaborador(ColaboradorEmpregadorModel colaboradorEmpregador)
        {
            ColaboradorEmpregadorFacade colaboradorEmpregadorFacade = new ColaboradorEmpregadorFacade();

            var result = colaboradorEmpregadorFacade.AdicionarEmpregadorColaborador(colaboradorEmpregador);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar Empregador Colaborador 
        /// </summary>        
        /// <remarks>Edita o Empregador Colaborador</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: ColaboradorEmpregador/EditarEmpregadorColaborador      
        [Route("EditarEmpregadorColaborador", Name = "EditarEmpregadorColaborador")]
        [HttpPost]
        public IHttpActionResult EditarEmpregadorColaborador(ColaboradorEmpregadorModel colaboradorEmpregador)
        {
            ColaboradorEmpregadorFacade colaboradorEmpregadorFacade = new ColaboradorEmpregadorFacade();

            var result = colaboradorEmpregadorFacade.EditarEmpregadorColaborador(colaboradorEmpregador);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Empregador Colaborador Por Id
        /// </summary>        
        /// <remarks>Retorna o Empregador Colaborador</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: ColaboradorEmpregador/BuscarEmpregadorColaboradorPreAdmissaoPorId
        [Route("BuscarEmpregadorColaboradorPreAdmissaoPorId", Name = "BuscarEmpregadorColaboradorPreAdmissaoPorId")]
        [HttpGet]
        public IHttpActionResult BuscarEmpregadorColaboradorPreAdmissaoPorId(int id)
        {
            ColaboradorEmpregadorFacade colaboradorEmpregadorFacade = new ColaboradorEmpregadorFacade();

            var result = colaboradorEmpregadorFacade.BuscarColaboradorEmpregadorPreAdmissaoPorColaboradorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
