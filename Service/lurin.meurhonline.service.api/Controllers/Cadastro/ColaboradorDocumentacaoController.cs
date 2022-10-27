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
    [RoutePrefix("ColaboradorDocumentacao")]
    [Authorize]
    public class ColaboradorDocumentacaoController : ApiController
    {
        /// <summary>
        /// Busca Documentação Colaborador
        /// </summary>        
        /// <remarks>Retorna a Documentação Colaborador</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: ColaboradorDocumentacao/BuscarDocumentacaoColaborador
        [Route("BuscarDocumentacaoColaborador", Name = "BuscarDocumentacaoColaborador")]
        [HttpPost]
        public IHttpActionResult BuscarDocumentacaoColaborador(ColaboradorDocumentacaoModel colaboradorDocumentacao)
        {
            ColaboradorDocumentacaoFacade colaboradorDocumentacaoFacade = new ColaboradorDocumentacaoFacade();

            var result = colaboradorDocumentacaoFacade.BuscarDocumentacaoColaborador(colaboradorDocumentacao);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Documentação Colaborador Pré Admissão
        /// </summary>        
        /// <remarks>Retorna a Documentação Colaborador</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: ColaboradorDocumentacao/BuscarDocumentacaoColaboradorPreAdmissao
        [Route("BuscarDocumentacaoColaboradorPreAdmissao", Name = "BuscarDocumentacaoColaboradorPreAdmissao")]
        [HttpPost]
        public IHttpActionResult BuscarDocumentacaoColaboradorPreAdmissao(ColaboradorDocumentacaoModel colaboradorDocumentacao)
        {
            ColaboradorDocumentacaoFacade colaboradorDocumentacaoFacade = new ColaboradorDocumentacaoFacade();

            var result = colaboradorDocumentacaoFacade.BuscarDocumentacaoColaboradorPreAdmissao(colaboradorDocumentacao);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona Documentação Colaborador 
        /// </summary>        
        /// <remarks>Adiciona a Documentação Colaborador </remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: ColaboradorDocumentacao/AdicionarDocumentacaoColaborador      
        [Route("AdicionarDocumentacaoColaborador", Name = "AdicionarDocumentacaoColaborador")]
        [HttpPost]
        public IHttpActionResult AdicionarDocumentacaoColaborador(ColaboradorDocumentacaoModel colaboradorDocumentacao)
        {
            ColaboradorDocumentacaoFacade colaboradorDocumentacaoFacade = new ColaboradorDocumentacaoFacade();

            var result = colaboradorDocumentacaoFacade.AdicionarDocumentacaoColaborador(colaboradorDocumentacao);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar Documentacao Colaborador 
        /// </summary>        
        /// <remarks>Edita a Documentação Colaborador</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: ColaboradorDocumentacao/EditarDocumentacaoColaborador      
        [Route("EditarDocumentacaoColaborador", Name = "EditarDocumentacaoColaborador")]
        [HttpPost]
        public IHttpActionResult EditarDocumentacaoColaborador(ColaboradorDocumentacaoModel colaboradorDocumentacao)
        {
            ColaboradorDocumentacaoFacade colaboradorDocumentacaoFacade = new ColaboradorDocumentacaoFacade();

            var result = colaboradorDocumentacaoFacade.EditarDocumentacaoColaborador(colaboradorDocumentacao);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Documentação Colaborador Pré Admissão Por Id
        /// </summary>        
        /// <remarks>Retorna a Documentação Colaborador</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: ColaboradorDocumentacao/BuscarDocumentacaoColaboradorPreAdmissaoPorId
        [Route("BuscarDocumentacaoColaboradorPreAdmissaoPorId", Name = "BuscarDocumentacaoColaboradorPreAdmissaoPorId")]
        [HttpGet]
        public IHttpActionResult BuscarDocumentacaoColaboradorPreAdmissaoPorId(int id)
        {
            ColaboradorDocumentacaoFacade colaboradorDocumentacaoFacade = new ColaboradorDocumentacaoFacade();

            var result = colaboradorDocumentacaoFacade.BuscarDocumentacaoColaboradorPreAdmissaoPorColaboradorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }


}
