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
    [RoutePrefix("Dependente")]
    public class DependenteController : ApiController
    {
        /// <summary>
        /// Busca Dependente
        /// </summary>        
        /// <remarks>Retorna o Dependente</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Dependente/BuscarDependente
        [Route("BuscarDependente", Name = "BuscarDependente")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult BuscarDependente(DependenteModel dependente)
        {
            DependenteFacade dependenteFacade = new DependenteFacade();

            var result = dependenteFacade.BuscarDependente(dependente);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Dependente
        /// </summary>        
        /// <remarks>Retorna o Dependente por Ids</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Dependente/BuscarDependentePorIds
        [Route("BuscarDependentePorIds", Name = "BuscarDependentePorIds")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult BuscarDependentePorIds([FromUri] IEnumerable<int> ids)
        {
            DependenteFacade dependenteFacade = new DependenteFacade();

            var result = dependenteFacade.BuscarDependentePorIds(ids);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Dependente Por Colaborador Id
        /// </summary>        
        /// <remarks>Retorna os Dependentes por Colaborador Id</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Dependente/BuscarDependentePorColaboradorId
        [Route("BuscarDependentePorColaboradorId", Name = "BuscarDependentePorColaboradorId")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarDependentePorColaboradorId(int id)
        {
            DependenteFacade dependenteFacade = new DependenteFacade();

            var result = dependenteFacade.BuscarDependentePorColaboradorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Arquivo
        /// </summary>        
        /// <remarks>Retorna o Arquivo Documento</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Dependente/BuscarArquivo
        [Route("BuscarArquivo", Name = "BuscarArquivo")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarArquivo(int id)
        {
            DependenteFacade dependenteFacade = new DependenteFacade();

            var result = dependenteFacade.BuscarArquivo(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona Dependente
        /// </summary>        
        /// <remarks>Adiciona o Dependente</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: Dependente/AdicionarDependente      
        [Route("AdicionarDependente", Name = "AdicionarDependente")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult AdicionarDependente(DependenteModel dependente)
        {
            DependenteFacade dependenteFacade = new DependenteFacade();

            var result = dependenteFacade.AdicionarDependente(dependente);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar Dependente
        /// </summary>        
        /// <remarks>Edita o Dependente/remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: Dependente/EditarDependente      
        [Route("EditarDependente", Name = "EditarDependente")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult EditarDependente(DependenteModel dependente)
        {
            DependenteFacade dependenteFacade = new DependenteFacade();

            var result = dependenteFacade.EditarDependente(dependente);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Excluir Dependente
        /// </summary>        
        /// <remarks>Excluir o Dependente</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Dependente/ExcluirDependente      
        [Route("ExcluirDependente", Name = "ExcluirDependente")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult ExcluirDependente(int id)
        {
            DependenteFacade dependenteFacade = new DependenteFacade();

            var result = dependenteFacade.ExcluirDependente(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
