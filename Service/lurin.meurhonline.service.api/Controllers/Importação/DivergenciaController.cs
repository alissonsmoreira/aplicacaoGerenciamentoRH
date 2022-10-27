using System.Web.Http;
using System.Web.Http.Cors;
using lurin.meurhonline.application;
using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.service.api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Divergencia")]
    [Authorize]
    public class DivergenciaController : ApiController
    {
        /// <summary>
        /// Importar Recibo Ferias 
        /// </summary>        
        /// <remarks>Importar Recibo de Ferias</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Divergencia/ImportarDivergencia
        [Route("ImportarDivergencia", Name = "ImportarDivergencia")]
        [HttpPost]
        public IHttpActionResult ImportarDivergencia(DivergenciaModel divergencia)
        {
            DivergenciaFacade divergenciaFacade = new DivergenciaFacade();

            var result = divergenciaFacade.ImportarDivergencia(divergencia);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Buscar Divergencia por Colaborador Id e Datas inicio e fim
        /// </summary>        
        /// <remarks>Buscar Divergencia por Colaborador Id</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Divergencia/BuscarDivergenciaPorColaboradorIdData
        [Route("BuscarDivergenciaPorColaboradorIdData", Name = "BuscarDivergenciaPorColaboradorIdData")]
        [HttpGet]
        public IHttpActionResult BuscarDivergenciaPorColaboradorIdData(int? colaboradorId, string dataInicio, string dataFim)
        {
            DivergenciaFacade divergenciaFacade = new DivergenciaFacade();
           
            var result = divergenciaFacade.BuscarDivergenciaPorColaboradorIdData(colaboradorId, dataInicio, dataFim);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Buscar Divergencia por ID
        /// </summary>        
        /// <remarks>Buscar Divergencia por ID</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Divergencia/BuscarDivergenciaPorId
        [Route("BuscarDivergenciaPorId", Name = "BuscarDivergenciaPorId")]
        [HttpGet]
        public IHttpActionResult BuscarDivergenciaPorId(int id)
        {
            DivergenciaFacade divergenciaFacade = new DivergenciaFacade();

            var result = divergenciaFacade.BuscarDivergenciaPorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Buscar Divergencia Não Justificada por ID
        /// </summary>        
        /// <remarks>Buscar Divergencia Não Justificada por ID</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Divergencia/BuscarDivergenciaPorId
        [Route("BuscarDivergenciaNaoJustificadaPorId", Name = "BuscarDivergenciaNaoJustificadaPorId")]
        [HttpGet]
        public IHttpActionResult BuscarDivergenciaNaoJustificadaPorId(int id)
        {
            DivergenciaFacade divergenciaFacade = new DivergenciaFacade();

            var result = divergenciaFacade.BuscarDivergenciaNaoJustificadaPorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Buscar Divergencia por Colaborador Id
        /// </summary>        
        /// <remarks>Buscar Divergencia por Colaborador Id</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Divergencia/BuscarDivergenciaPorColaboradorId
        [Route("BuscarDivergenciaPorColaboradorId", Name = "BuscarDivergenciaPorColaboradorId")]
        [HttpGet]
        public IHttpActionResult BuscarDivergenciaPorColaboradorId(int? id)
        {
            DivergenciaFacade divergenciaFacade = new DivergenciaFacade();

            var result = divergenciaFacade.BuscarDivergenciaPorColaboradorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Aprovar Divergência
        /// </summary>        
        /// <remarks>Aprova Divergência</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Divergencia/AprovarDivergencia
        [Route("AprovarDivergencia", Name = "AprovarDivergencia")]
        [HttpPost]
        public IHttpActionResult AprovarDivergencia(DivergenciaDetalheModel divergenciaDetalhe)
        {
            DivergenciaFacade divergenciaFacade = new DivergenciaFacade();

            var result = divergenciaFacade.AprovarDivergencia(divergenciaDetalhe);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        //POST: Divergencia/AprovarDivergencia
        [Route("SalvarJustificativaDivergencia", Name = "SalvarJustificativaDivergencia")]
        [HttpPost]
        public IHttpActionResult SalvarJustificativaDivergencia(DivergenciaDetalheModel diverencia)
        {
            DivergenciaFacade divergenciaFacade = new DivergenciaFacade();

            var result = divergenciaFacade.SalvarJustificativaDivergencia(diverencia.Id);

            if (!result)
                return NotFound();

            return Ok();
        }
    }
}
