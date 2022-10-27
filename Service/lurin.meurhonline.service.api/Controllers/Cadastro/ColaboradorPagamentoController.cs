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
    [RoutePrefix("ColaboradorPagamento")]
    [Authorize]
    public class ColaboradorPagamentoController : ApiController
    {
        /// <summary>
        /// Busca Pagamento Colaborador
        /// </summary>        
        /// <remarks>Retorna o Pagamento Colaborador</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: ColaboradorPagamento/BuscarPagamentoColaborador
        [Route("BuscarPagamentoColaborador", Name = "BuscarPagamentoColaborador")]
        [HttpPost]
        public IHttpActionResult BuscarPagamentoColaborador(ColaboradorPagamentoModel colaboradorPagamento)
        {
            ColaboradorPagamentoFacade colaboradorPagamentoFacade = new ColaboradorPagamentoFacade();

            var result = colaboradorPagamentoFacade.BuscarPagamentoColaborador(colaboradorPagamento);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Pagamento Colaborador
        /// </summary>        
        /// <remarks>Retorna o Pagamento Colaborador</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: ColaboradorPagamento/BuscarPagamentoColaboradorPreAdmissao
        [Route("BuscarPagamentoColaboradorPreAdmissao", Name = "BuscarPagamentoColaboradorPreAdmissao")]
        [HttpPost]
        public IHttpActionResult BuscarPagamentoColaboradorPreAdmissao(ColaboradorPagamentoModel colaboradorPagamento)
        {
            ColaboradorPagamentoFacade colaboradorPagamentoFacade = new ColaboradorPagamentoFacade();

            var result = colaboradorPagamentoFacade.BuscarPagamentoColaboradorPreAdmissao(colaboradorPagamento);

            if (result == null)
                return NotFound();

            return Ok(result);
        }        

        /// <summary>
        /// Adiciona Pagamento Colaborador 
        /// </summary>        
        /// <remarks>Adiciona o Pagamento Colaborador </remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: ColaboradorPagamento/AdicionarPagamentoColaborador      
        [Route("AdicionarPagamentoColaborador", Name = "AdicionarPagamentoColaborador")]
        [HttpPost]
        public IHttpActionResult AdicionarPagamentoColaborador(ColaboradorPagamentoModel colaboradorPagamento)
        {
            ColaboradorPagamentoFacade colaboradorPagamentoFacade = new ColaboradorPagamentoFacade();

            var result = colaboradorPagamentoFacade.AdicionarPagamentoColaborador(colaboradorPagamento);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar Pagamento Colaborador 
        /// </summary>        
        /// <remarks>Edita o Pagamento Colaborador</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: ColaboradorPagamento/EditarPagamentoColaborador      
        [Route("EditarPagamentoColaborador", Name = "EditarPagamentoColaborador")]
        [HttpPost]
        public IHttpActionResult EditarPagamentoColaborador(ColaboradorPagamentoModel colaboradorPagamento)
        {
            ColaboradorPagamentoFacade colaboradorPagamentoFacade = new ColaboradorPagamentoFacade();

            var result = colaboradorPagamentoFacade.EditarPagamentoColaborador(colaboradorPagamento);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Pagamento Colaborador Por Id
        /// </summary>        
        /// <remarks>Retorna o Pagamento Colaborador</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: ColaboradorPagamento/BuscarPagamentoColaboradorPreAdmissaoPorId
        [Route("BuscarPagamentoColaboradorPreAdmissaoPorId", Name = "BuscarPagamentoColaboradorPreAdmissaoPorId")]
        [HttpGet]
        public IHttpActionResult BuscarPagamentoColaboradorPreAdmissaoPorId(int id)
        {
            ColaboradorPagamentoFacade colaboradorPagamentoFacade = new ColaboradorPagamentoFacade();

            var result = colaboradorPagamentoFacade.BuscarPagamentoColaboradorPreAdmissaoPorColaboradorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
