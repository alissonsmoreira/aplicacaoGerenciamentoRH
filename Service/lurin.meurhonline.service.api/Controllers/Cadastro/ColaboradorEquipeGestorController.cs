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
using lurin.meurhonline.domain.model.enumerator;

namespace lurin.meurhonline.service.api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("ColaboradorEquipeGestor")]
    [Authorize]
    public class ColaboradorEquipeGestorController : ApiController
    {
        /// <summary>
        /// Busca Equipe Gestor 
        /// </summary>        
        /// <remarks>Retorna Equipe Gestor</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: ColaboradorEquipeGestor/BuscarEquipeGestor
        [Route("BuscarEquipeGestor", Name = "BuscarEquipeGestor")]
        [HttpPost]
        public IHttpActionResult BuscarEquipeGestor(EquipeGestorModel equipeGestor)
        {
            EquipeGestorFacade equipeGestorFacade = new EquipeGestorFacade();

            var result = equipeGestorFacade.BuscarEquipeGestor(equipeGestor);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona Equipe Gestor 
        /// </summary>        
        /// <remarks>Adiciona a Equipe Gestor</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: ColaboradorEquipeGestor/AdicionarEquipeGestor
        [Route("AdicionarEquipeGestor", Name = "AdicionarEquipeGestor")]
        [HttpPost]
        public IHttpActionResult AdicionarEquipeGestor(EquipeGestorModel equipeGestor)
        {
            EquipeGestorFacade equipeGestorFacade = new EquipeGestorFacade();

            var result = equipeGestorFacade.AdicionarEquipeGestor(equipeGestor);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Excluir Equipe Gestor 
        /// </summary>        
        /// <remarks>Exclui a Equipe Gestor</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: ColaboradorEquipeGestor/ExcluirEquipeGestor
        [Route("ExcluirEquipeGestor", Name = "ExcluirEquipeGestor")]
        [HttpPost]
        public IHttpActionResult ExcluirEquipeGestor(int id)
        {
            EquipeGestorFacade equipeGestorFacade = new EquipeGestorFacade();

            var result = equipeGestorFacade.ExcluirEquipeGestor(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
