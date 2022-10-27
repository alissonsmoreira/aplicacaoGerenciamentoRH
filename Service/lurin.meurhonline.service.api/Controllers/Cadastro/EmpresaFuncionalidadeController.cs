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
    [RoutePrefix("EmpresaFuncionalidade")]
    public class EmpresaFuncionalidadeController : ApiController
    {
        /// <summary>
        /// Busca funcionalidade 
        /// </summary>        
        /// <remarks>Retorna as funcionalidades</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: EmpresaFuncionalidade/BuscarEmpresaFuncionalidade
        [Route("BuscarEmpresaFuncionalidade", Name = "BuscarEmpresaFuncionalidade")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarEmpresaFuncionalidade()
        {
            EmpresaFacade EmpresaFacade = new EmpresaFacade();

            var result = EmpresaFacade.BuscarEmpresaFuncionalidade();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona funcionalidades para empresa
        /// </summary>        
        /// <remarks>Adiciona funcionalidade para empresa</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>                

        //POST: EmpresaFuncionalidade/AdicionarEmpresaFuncionalidade
        [Route("AdicionarEmpresaFuncionalidade", Name = "AdicionarEmpresaFuncionalidade")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult AdicionarEmpresaFuncionalidade(IEnumerable<EmpresaEmpresaFuncionalidadeModel> empresaEmpresaFuncionalidade)
        {
            EmpresaFacade EmpresaFacade = new EmpresaFacade();

            var result = EmpresaFacade.AdicionarEmpresaFuncionalidade(empresaEmpresaFuncionalidade);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Edita funcionalidades para empresa
        /// </summary>        
        /// <remarks>Editar funcionalidade para empresa</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>                

        //POST: EmpresaFuncionalidade/EditarFuncionalidade
        [Route("EditarEmpresaFuncionalidade", Name = "EditarEmpresaFuncionalidade")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult EditarEmpresaFuncionalidade(IEnumerable<EmpresaEmpresaFuncionalidadeModel> empresaEmpresaFuncionalidade)
        {
            EmpresaFacade EmpresaFacade = new EmpresaFacade();

            var result = EmpresaFacade.EditarEmpresaFuncionalidade(empresaEmpresaFuncionalidade);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
