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
    [RoutePrefix("CategoriaSalarial")]
    public class CategoriaSalarialController : ApiController
    {
        /// <summary>
        /// Busca Categoria Salarial 
        /// </summary>        
        /// <remarks>Retorna a Categoria Salarial</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: CategoriaSalarial/BuscarCategoriaSalarial
        [Route("BuscarCategoriaSalarial", Name = "BuscarCategoriaSalarial")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult BuscarCategoriaSalarial(CategoriaSalarialModel categoriaSalarial)
        {
            CategoriaSalarialFacade categoriaSalarialFacade = new CategoriaSalarialFacade();

            var result = categoriaSalarialFacade.BuscarCategoriaSalarial(categoriaSalarial);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona Categoria Salarial 
        /// </summary>        
        /// <remarks>Adiciona o Categoria Salarial</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: CategoriaSalarial/AdicionarCategoriaSalarial      
        [Route("AdicionarCategoriaSalarial", Name = "AdicionarCategoriaSalarial")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult AdicionarCategoriaSalarial(CategoriaSalarialModel categoriaSalarial)
        {
            CategoriaSalarialFacade categoriaSalarialFacade = new CategoriaSalarialFacade();

            var result = categoriaSalarialFacade.AdicionarCategoriaSalarial(categoriaSalarial);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar Categoria Salarial 
        /// </summary>        
        /// <remarks>Edita a Categoria Salarial</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: CategoriaSalarial/EditarCategoriaSalarial      
        [Route("EditarCategoriaSalarial", Name = "EditarCategoriaSalarial")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult EditarCategoriaSalarial(CategoriaSalarialModel categoriaSalarial)
        {
            CategoriaSalarialFacade categoriaSalarialFacade = new CategoriaSalarialFacade();

            var result = categoriaSalarialFacade.EditarCategoriaSalarial(categoriaSalarial);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Excluir Categoria Salarial 
        /// </summary>        
        /// <remarks>Excluir a Categoria Salarial</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: CategoriaSalarial/ExcluirCategoriaSalarial      
        [Route("ExcluirCategoriaSalarial", Name = "ExcluirCategoriaSalarial")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult ExcluirCategoriaSalarial(int id)
        {
            CategoriaSalarialFacade categoriaSalarialFacade = new CategoriaSalarialFacade();

            var result = categoriaSalarialFacade.ExcluirCategoriaSalarial(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
