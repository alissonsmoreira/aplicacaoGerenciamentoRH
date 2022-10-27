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
    [RoutePrefix("AlteracaoCadastral")]
    [Authorize]
    public class AlteracaoCadastralController : ApiController
    {
        /// <summary>
        /// Busca Dados Por Colaborador Id
        /// </summary>        
        /// <remarks>Retorna os dados por Colaborador Id</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: AlteracaoCadastral/BuscarDadosPorColaboradorId
        [Route("BuscarDadosPorColaboradorId", Name = "BuscarDadosPorColaboradorId")]
        [HttpGet]
        public IHttpActionResult BuscarDadosPorColaboradorId(int id)
        {
            AlteracaoCadastralFacade alteracaoCadastralFacade = new AlteracaoCadastralFacade();

            var result = alteracaoCadastralFacade.BuscarDadosPorColaboradorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Solicitação Alteração Cadastral Por Colaborador Id
        /// </summary>        
        /// <remarks>Retorna solicitação de alteração cadastral por Colaborador Id</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: AlteracaoCadastral/BuscarSolicitacaoAlteracaoPorColaboradorId
        [Route("BuscarSolicitacaoAlteracaoPorColaboradorId", Name = "BuscarSolicitacaoAlteracaoPorColaboradorId")]
        [HttpGet]
        public IHttpActionResult BuscarSolicitacaoAlteracaoPorColaboradorId(int id)
        {
            AlteracaoCadastralFacade alteracaoCadastralFacade = new AlteracaoCadastralFacade();

            var result = alteracaoCadastralFacade.BuscarSolicitacaoAlteracaoPorColaboradorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Solicitação Alteração Cadastral 
        /// </summary>        
        /// <remarks>Retorna solicitação de alteração cadastral</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: AlteracaoCadastral/BuscarSolicitacaoAlteracao
        [Route("BuscarSolicitacaoAlteracao", Name = "BuscarSolicitacaoAlteracao")]
        [HttpPost]
        public IHttpActionResult BuscarSolicitacaoAlteracao(AlteracaoCadastralModel alteracaoCadastral)
        {
            AlteracaoCadastralFacade alteracaoCadastralFacade = new AlteracaoCadastralFacade();

            var result = alteracaoCadastralFacade.BuscarSolicitacaoAlteracao(alteracaoCadastral);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona Solicitação de Alteração Cadastral
        /// </summary>        
        /// <remarks>Adiciona Solicitação de Alteração Cadastral</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: AlteracaoCadastral/SolicitarAlteracao
        [Route("SolicitarAlteracao", Name = "SolicitarAlteracao")]
        [HttpPost]
        public IHttpActionResult SolicitarAlteracao(AlteracaoCadastralModel alteracaoCadastral)
        {
            AlteracaoCadastralFacade alteracaoCadastralFacade = new AlteracaoCadastralFacade();

            var result = alteracaoCadastralFacade.SolicitarAlteracao(alteracaoCadastral);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Aprova Solicitação de Alteração Cadastral
        /// </summary>        
        /// <remarks>Aprova Solicitação de Alteração Cadastral</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: AlteracaoCadastral/AprovarSolicitacaoAlteracao
        [Route("AprovarSolicitacaoAlteracao", Name = "AprovarSolicitacaoAlteracao")]
        [HttpPost]
        public IHttpActionResult AprovarSolicitacaoAlteracao(int id)
        {
            AlteracaoCadastralFacade alteracaoCadastralFacade = new AlteracaoCadastralFacade();

            var result = alteracaoCadastralFacade.AprovarSolicitacaoAlteracao(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Reprova Solicitação de Alteração Cadastral
        /// </summary>        
        /// <remarks>Reprova Solicitação de Alteração Cadastral</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: AlteracaoCadastral/ReprovarSolicitacaoAlteracao
        [Route("ReprovarSolicitacaoAlteracao", Name = "ReprovarSolicitacaoAlteracao")]
        [HttpPost]
        public IHttpActionResult ReprovarSolicitacaoAlteracao(int id)
        {
            AlteracaoCadastralFacade alteracaoCadastralFacade = new AlteracaoCadastralFacade();

            var result = alteracaoCadastralFacade.ReprovarSolicitacaoAlteracao(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Foto Solicitação Alteração Cadastral
        /// </summary>        
        /// <remarks>Retorna o arquivo com a foto da solicitação alteração cadastral </remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: AlteracaoCadastral/BuscarFotoSolicitacaoAlteracao
        [Route("BuscarFotoSolicitacaoAlteracao", Name = "BuscarFotoSolicitacaoAlteracao")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarFotoSolicitacaoAlteracao(int id)
        {
            AlteracaoCadastralFacade alteracaoCadastralFacade = new AlteracaoCadastralFacade();

            var result = alteracaoCadastralFacade.BuscarFoto(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Carteira de Habilitação Solicitação Alteração Cadastral
        /// </summary>        
        /// <remarks>Retorna o arquivo com a imagem da Carteira de Habilitacao da solicitação alteração cadastral </remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: AlteracaoCadastral/BuscarCarteiraHabilitacaoSolicitacaoAlteracao
        [Route("BuscarCarteiraHabilitacaoSolicitacaoAlteracao", Name = "BuscarCarteiraHabilitacaoSolicitacaoAlteracao")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarCarteiraHabilitacaoSolicitacaoAlteracao(int id)
        {
            AlteracaoCadastralFacade alteracaoCadastralFacade = new AlteracaoCadastralFacade();

            var result = alteracaoCadastralFacade.BuscarCarteiraHabilitacao(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Comprovante de Residência Solicitação Alteração Cadastral
        /// </summary>        
        /// <remarks>Retorna o arquivo com a imagem do Comprovante de Residência da solicitação alteração cadastral </remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: AlteracaoCadastral/BuscarComprovanteResidenciaSolicitacaoAlteracao
        [Route("BuscarComprovanteResidenciaSolicitacaoAlteracao", Name = "BuscarComprovanteResidenciaSolicitacaoAlteracao")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarComprovanteResidenciaSolicitacaoAlteracao(int id)
        {
            AlteracaoCadastralFacade alteracaoCadastralFacade = new AlteracaoCadastralFacade();

            var result = alteracaoCadastralFacade.BuscarComprovanteResidencia(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
