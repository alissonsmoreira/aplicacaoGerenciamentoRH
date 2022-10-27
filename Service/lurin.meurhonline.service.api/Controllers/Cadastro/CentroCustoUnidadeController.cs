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
    [RoutePrefix("CentroCustoUnidade")]
    public class CentroCustoUnidadeController : ApiController
    {
        /// <summary>
        /// Busca Centro Custo Unidade
        /// </summary>        
        /// <remarks>Retorna o Centro Custo Unidade</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: CentroCustoUnidade/BuscarCentroCustoUnidade
        [Route("BuscarCentroCustoUnidade", Name = "BuscarCentroCustoUnidade")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult BuscarCentroCustoUnidade(CentroCustoUnidadeModel centroCustoUnidade)
        {
            CentroCustoUnidadeFacade centroCustoUnidadeFacade = new CentroCustoUnidadeFacade();

            var result = centroCustoUnidadeFacade.BuscarCentroCustoUnidade(centroCustoUnidade);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Tudo Centro Custo unidade
        /// </summary>        
        /// <remarks>Retorna todos os centros custos unidade</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Cargo/BuscarTudoCentroCustoUnidade
        [Route("BuscarTudoCentroCustoUnidade", Name = "BuscarTudoCentroCustoUnidade")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarTudoCentroCustoUnidade()
        {
            CentroCustoUnidadeFacade centroCustoUnidadeFacade = new CentroCustoUnidadeFacade();

            var result = centroCustoUnidadeFacade.BuscarTudoCentroCustoUnidade();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Centro Custo Unidade por Id Empresa
        /// </summary>        
        /// <remarks>Retorna os centros custos unidade por id Empresa</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Cargo/BuscarCentroCustoUnidadePorIdEmpresa
        [Route("BuscarCentroCustoUnidadePorIdEmpresa", Name = "BuscarCentroCustoUnidadePorIdEmpresa")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarCentroCustoUnidadePorIdEmpresa(int id)
        {
            CentroCustoUnidadeFacade centroCustoUnidadeFacade = new CentroCustoUnidadeFacade();

            var result = centroCustoUnidadeFacade.BuscarCentroCustoUnidadePorIdEmpresa(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona Centro Custo Unidade
        /// </summary>        
        /// <remarks>Adiciona o Centro Custo Unidade</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: CentroCustoUnidade/AdicionarCentroCustoUnidade      
        [Route("AdicionarCentroCustoUnidade", Name = "AdicionarCentroCustoUnidade")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult AdicionarCentroCustoUnidade(CentroCustoUnidadeModel centroCustoUnidade)
        {
            CentroCustoUnidadeFacade centroCustoUnidadeFacade = new CentroCustoUnidadeFacade();

            var result = centroCustoUnidadeFacade.AdicionarCentroCustoUnidade(centroCustoUnidade);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar Centro Custo Unidade
        /// </summary>        
        /// <remarks>Edita o Centro Custo Unidade</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: CentroCustoUnidade/EditarCentroCustoUnidade      
        [Route("EditarCentroCustoUnidade", Name = "EditarCentroCustoUnidade")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult EditarCentroCustoUnidade(CentroCustoUnidadeModel centroCustoUnidade)
        {
            CentroCustoUnidadeFacade centroCustoUnidadeFacade = new CentroCustoUnidadeFacade();

            var result = centroCustoUnidadeFacade.EditarCentroCustoUnidade(centroCustoUnidade);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Excluir Centro Custo Unidade 
        /// </summary>        
        /// <remarks>Excluir o Centro Custo Unidade</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: CentroCustoUnidade/ExcluirCentroCustoUnidade      
        [Route("ExcluirCentroCustoUnidade", Name = "ExcluirCentroCustoUnidade")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult ExcluirCentroCustoUnidade(int id)
        {
            CentroCustoUnidadeFacade centroCustoUnidadeFacade = new CentroCustoUnidadeFacade();

            var result = centroCustoUnidadeFacade.ExcluirCentroCustoUnidade(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
