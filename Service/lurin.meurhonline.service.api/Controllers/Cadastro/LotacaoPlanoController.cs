using System.Web.Http;
using System.Collections.Generic;
using System.Web.Http.Cors;

using lurin.meurhonline.application;
using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.service.api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("LotacaoPlano")]
    public class LotacaoPlanoController : ApiController
    {
        /// <summary>
        /// Busca lotacao plano
        /// </summary>        
        /// <remarks>Retorna o lotacao plano</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Lotacao/BuscarLotacaoPlano
        [Route("BuscarLotacaoPlano", Name = "BuscarLotacaoPlano")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult BuscarLotacaoPlano(LotacaoPlanoModel lotacaoPlano)
        {
            LotacaoPlanoFacade LotacaoPlanoFacade = new LotacaoPlanoFacade();

            var result = LotacaoPlanoFacade.BuscarLotacaoPlano(lotacaoPlano);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        /// <summary>
        /// Adiciona lotacao plano
        /// </summary>        
        /// <remarks>Adiciona o lotacao plano</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: Lotacao/AdicionarLotacaoPlano      
        [Route("AdicionarLotacaoPlano", Name = "AdicionarLotacaoPlano")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult AdicionarLotacaoPlano(LotacaoPlanoModel lotacaoPlano)
        {
            LotacaoPlanoFacade LotacaoPlanoFacade = new LotacaoPlanoFacade();

            var result = LotacaoPlanoFacade.AdicionarLotacaoPlano(lotacaoPlano);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona lotacao plano unidade
        /// </summary>        
        /// <remarks>Adiciona o lotacao plano unidade</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: Lotacao/AdicionarLotacaoPlanoUnidade      
        [Route("AdicionarLotacaoPlanoUnidade", Name = "AdicionarLotacaoPlanoUnidade")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult AdicionarLotacaoPlanoUnidade(IEnumerable<LotacaoPlanoUnidadeModel> lotacaoPlanoUnidade)
        {
            LotacaoPlanoFacade LotacaoPlanoFacade = new LotacaoPlanoFacade();

            var result = LotacaoPlanoFacade.AdicionarLotacaoPlanoUnidade(lotacaoPlanoUnidade);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar lotacao plano
        /// </summary>        
        /// <remarks>Edita o Lotacao plano</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: Lotacao/EditarLotacaoPlano      
        [Route("EditarLotacaoPlano", Name = "EditarLotacaoPlano")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult EditarLotacaoPlano(LotacaoPlanoModel lotacaoPlano)
        {
            LotacaoPlanoFacade LotacaoPlanoFacade = new LotacaoPlanoFacade();

            var result = LotacaoPlanoFacade.EditarLotacaoPlano(lotacaoPlano);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Excluir Lotacao plano
        /// </summary>        
        /// <remarks>Excluir o Lotacao plano</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Lotacao/ExcluirLotacaoPlano      
        [Route("ExcluirLotacaoPlano", Name = "ExcluirLotacaoPlano")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult ExcluirLotacaoPlano(int id)
        {
            LotacaoPlanoFacade LotacaoPlanoFacade = new LotacaoPlanoFacade();

            var result = LotacaoPlanoFacade.ExcluirLotacaoPlano(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
