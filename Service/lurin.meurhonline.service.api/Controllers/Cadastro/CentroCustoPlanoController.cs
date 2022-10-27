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
    [RoutePrefix("CentroCustoPlano")]
    public class CentroCustoPlanoController : ApiController
    {
        /// <summary>
        /// Busca Centro Custo plano
        /// </summary>        
        /// <remarks>Retorna o Centro Custo plano</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: CentroCusto/BuscarCentroCustoPlano
        [Route("BuscarCentroCustoPlano", Name = "BuscarCentroCustoPlano")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult BuscarCentroCustoPlano(CentroCustoPlanoModel centroCustoPlano)
        {
            CentroCustoPlanoFacade CentroCustoPlanoFacade = new CentroCustoPlanoFacade();

            var result = CentroCustoPlanoFacade.BuscarCentroCustoPlano(centroCustoPlano);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        /// <summary>
        /// Adiciona Centro Custo plano
        /// </summary>        
        /// <remarks>Adiciona o Centro Custo plano</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: CentroCusto/AdicionarCentroCustoPlano      
        [Route("AdicionarCentroCustoPlano", Name = "AdicionarCentroCustoPlano")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult AdicionarCentroCustoPlano(CentroCustoPlanoModel centroCustoPlano)
        {
            CentroCustoPlanoFacade CentroCustoPlanoFacade = new CentroCustoPlanoFacade();

            var result = CentroCustoPlanoFacade.AdicionarCentroCustoPlano(centroCustoPlano);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona Centro Custo plano unidade
        /// </summary>        
        /// <remarks>Adiciona o Centro Custo plano unidade</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: CentroCusto/AdicionarCentroCustoPlanoUnidade      
        [Route("AdicionarCentroCustoPlanoUnidade", Name = "AdicionarCentroCustoPlanoUnidade")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult AdicionarCentroCustoPlanoUnidade(IEnumerable<CentroCustoPlanoUnidadeModel> centroCustoPlanoUnidade)
        {
            CentroCustoPlanoFacade CentroCustoPlanoFacade = new CentroCustoPlanoFacade();

            var result = CentroCustoPlanoFacade.AdicionarCentroCustoPlanoUnidade(centroCustoPlanoUnidade);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar Centro Custo plano
        /// </summary>        
        /// <remarks>Edita o Centro Custo plano</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: CentroCusto/EditarCentroCustoPlano      
        [Route("EditarCentroCustoPlano", Name = "EditarCentroCustoPlano")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult EditarCentroCustoPlano(CentroCustoPlanoModel centroCustoPlano)
        {
            CentroCustoPlanoFacade CentroCustoPlanoFacade = new CentroCustoPlanoFacade();

            var result = CentroCustoPlanoFacade.EditarCentroCustoPlano(centroCustoPlano);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Excluir Centro Custo plano
        /// </summary>        
        /// <remarks>Excluir o Centro Custo plano</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: CentroCusto/ExcluirCentroCustoPlano      
        [Route("ExcluirCentroCustoPlano", Name = "ExcluirCentroCustoPlano")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult ExcluirCentroCustoPlano(int id)
        {
            CentroCustoPlanoFacade CentroCustoPlanoFacade = new CentroCustoPlanoFacade();

            var result = CentroCustoPlanoFacade.ExcluirCentroCustoPlano(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
