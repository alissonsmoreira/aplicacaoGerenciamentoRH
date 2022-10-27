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
    [RoutePrefix("Empresa")]
    public class EmpresaController : ApiController
    {
        /// <summary>
        /// Busca empresa 
        /// </summary>        
        /// <remarks>Retorna a empresa</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Empresa/BuscarEmpresa
        [Route("BuscarEmpresa", Name = "BuscarEmpresa")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult BuscarEmpresa(EmpresaModel empresa)
        {
            EmpresaFacade EmpresaFacade = new EmpresaFacade();

            var result = EmpresaFacade.BuscarEmpresa(empresa);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca empresa tipo 
        /// </summary>        
        /// <remarks>Retorna as empresas tipo</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Empresa/BuscarEmpresaTipo
        [Route("BuscarEmpresaTipo", Name = "BuscarEmpresaTipo")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarEmpresaTipo()
        {
            EmpresaFacade EmpresaFacade = new EmpresaFacade();

            var result = EmpresaFacade.BuscarEmpresaTipo();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona empresa 
        /// </summary>        
        /// <remarks>Adiciona a empresa</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>                

        //POST: Empresa/AdicionarEmpresa      
        [Route("AdicionarEmpresa", Name = "AdicionarEmpresa")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult AdicionarEmpresa(EmpresaModel empresa)
        {
            EmpresaFacade EmpresaFacade = new EmpresaFacade();

            var result = EmpresaFacade.AdicionarEmpresa(empresa);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar empresa 
        /// </summary>        
        /// <remarks>Edita a empresa</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: Empresa/EditarEmpresa      
        [Route("EditarEmpresa", Name = "EditarEmpresa")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult EditarEmpresa(EmpresaModel empresa)
        {
            EmpresaFacade EmpresaFacade = new EmpresaFacade();

            var result = EmpresaFacade.EditarEmpresa(empresa);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca empresa por nome 
        /// </summary>        
        /// <remarks>Retorna as empresas</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Empresa/BuscarEmpresaPorNome
        [Route("BuscarEmpresaPorNome", Name = "BuscarEmpresaPorNome")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarEmpresaPorNome(string nome)
        {
            EmpresaFacade EmpresaFacade = new EmpresaFacade();

            var result = EmpresaFacade.BuscarEmpresaPorNome(nome);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca empresa matriz por nome 
        /// </summary>        
        /// <remarks>Retorna as empresas matriz</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Empresa/BuscarEmpresaMatrizPorNome
        [Route("BuscarEmpresaMatrizPorNome", Name = "BuscarEmpresaMatrizPorNome")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarEmpresaMatrizPorNome(string nomeEmpresa)
        {
            EmpresaFacade EmpresaFacade = new EmpresaFacade();

            var result = EmpresaFacade.BuscarEmpresaMatrizPorNome(nomeEmpresa);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca empresa matriz filial por empresa id
        /// </summary>        
        /// <remarks>Retorna as empresas matriz e filiais</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Empresa/BuscarMatrizFilialPorEmpresaId
        [Route("BuscarMatrizFilialPorEmpresaId", Name = "BuscarMatrizFilialPorEmpresaId")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarMatrizFilialPorEmpresaId(int id)
        {
            EmpresaFacade EmpresaFacade = new EmpresaFacade();

            var result = EmpresaFacade.BuscarMatrizFilialPorEmpresaId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
