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
    [RoutePrefix("LotacaoUnidade")]
    public class LotacaoUnidadeController : ApiController
    {
        /// <summary>
        /// Busca Lotacao unidade
        /// </summary>        
        /// <remarks>Retorna o Lotacao unidade</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Lotacao/BuscarLotacaoUnidade
        [Route("BuscarLotacaoUnidade", Name = "BuscarLotacaoUnidade")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult BuscarLotacaoUnidade(LotacaoUnidadeModel lotacaoUnidade)
        {
            LotacaoUnidadeFacade LotacaoUnidadeFacade = new LotacaoUnidadeFacade();

            var result = LotacaoUnidadeFacade.BuscarLotacaoUnidade(lotacaoUnidade);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Tudo Lotacao unidade
        /// </summary>        
        /// <remarks>Retorna todos os Lotacaos unidade</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Lotacao/BuscarTudoLotacaoUnidade
        [Route("BuscarTudoLotacaoUnidade", Name = "BuscarTudoLotacaoUnidade")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarTudoLotacaoUnidade()
        {
            LotacaoUnidadeFacade LotacaoUnidadeFacade = new LotacaoUnidadeFacade();

            var result = LotacaoUnidadeFacade.BuscarTudoLotacaoUnidade();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Lotacao Unidade por Id Empresa 
        /// </summary>        
        /// <remarks>Retorna Lotacao unidade por Id Empresa</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: LotacaoUnidade/BuscarLotacaoUnidadePorIdEmpresa
        [Route("BuscarLotacaoUnidadePorIdEmpresa", Name = "BuscarLotacaoUnidadePorIdEmpresa")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarLotacaoUnidadePorIdEmpresa(int id)
        {
            LotacaoUnidadeFacade LotacaoUnidadeFacade = new LotacaoUnidadeFacade();

            var result = LotacaoUnidadeFacade.BuscarLotacaoUnidadePorIdEmpresa(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona Lotacao unidade
        /// </summary>        
        /// <remarks>Adiciona o Lotacao unidade</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: Lotacao/AdicionarLotacaoUnidade      
        [Route("AdicionarLotacaoUnidade", Name = "AdicionarLotacaoUnidade")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult AdicionarLotacaoUnidade(LotacaoUnidadeModel lotacaoUnidade)
        {
            LotacaoUnidadeFacade LotacaoUnidadeFacade = new LotacaoUnidadeFacade();

            var result = LotacaoUnidadeFacade.AdicionarLotacaoUnidade(lotacaoUnidade);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar Lotacao unidade
        /// </summary>        
        /// <remarks>Edita o Lotacao unidade</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: Lotacao/EditarLotacaoUnidade      
        [Route("EditarLotacaoUnidade", Name = "EditarLotacaoUnidade")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult EditarLotacaoUnidade(LotacaoUnidadeModel lotacaoUnidade)
        {
            LotacaoUnidadeFacade LotacaoUnidadeFacade = new LotacaoUnidadeFacade();

            var result = LotacaoUnidadeFacade.EditarLotacaoUnidade(lotacaoUnidade);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Excluir Lotacao unidade
        /// </summary>        
        /// <remarks>Excluir o Lotacao unidade</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Lotacao/ExcluirLotacaoUnidade      
        [Route("ExcluirLotacaoUnidade", Name = "ExcluirLotacaoUnidade")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult ExcluirLotacaoUnidade(int id)
        {
            LotacaoUnidadeFacade LotacaoUnidadeFacade = new LotacaoUnidadeFacade();

            var result = LotacaoUnidadeFacade.ExcluirLotacaoUnidade(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
