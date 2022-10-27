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
    [RoutePrefix("OperadoraVT")]
    [Authorize]
    public class OperadoraVTController : ApiController
    {
        /// <summary>
        /// Busca OperadoraVT 
        /// </summary>        
        /// <remarks>Retorna a OperadoraVT</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: OperadoraVT/BuscarOperadoraVT
        [Route("BuscarOperadoraVT", Name = "BuscarOperadoraVT")]
        [HttpPost]
        public IHttpActionResult BuscarOperadoraVT(OperadoraVTModel OperadoraVT)
        {
            OperadoraVTFacade OperadoraVTFacade = new OperadoraVTFacade();

            var result = OperadoraVTFacade.BuscarOperadoraVT(OperadoraVT);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca OperadoraVT por nome
        /// </summary>        
        /// <remarks>Retorna a OperadoraVT</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: OperadoraVT/BuscarOperadoraVTPorNome
        [Route("BuscarOperadoraVTPorNome", Name = "BuscarOperadoraVTPorNome")]
        [HttpGet]
        public IHttpActionResult BuscarOperadoraVTPorNome(string nomeOperadoraVT)
        {
            OperadoraVTFacade OperadoraVTFacade = new OperadoraVTFacade();

            var result = OperadoraVTFacade.BuscarOperadoraVTPorNome(nomeOperadoraVT);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca OperadoraVTBandeiraCartao 
        /// </summary>        
        /// <remarks>Retorna a Bandeira do Cartão da OperadoraVT</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: OperadoraVT/BuscarOperadoraVTBandeiraCartao
        [Route("BuscarOperadoraVTBandeiraCartao", Name = "BuscarOperadoraVTBandeiraCartao")]
        [HttpGet]
        public IHttpActionResult BuscarOperadoraVTBandeiraCartao()
        {
            OperadoraVTFacade OperadoraVTFacade = new OperadoraVTFacade();

            var result = OperadoraVTFacade.BuscarOperadoraVTBandeiraCartao();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca OperadoraVTTarifaTipo 
        /// </summary>        
        /// <remarks>Retorna o Tipo da Tarifa da OperadoraVT</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: OperadoraVT/BuscarOperadoraVTBandeiraCartao
        [Route("BuscarOperadoraVTTarifaTipo", Name = "BuscarOperadoraVTTarifaTipo")]
        [HttpGet]
        public IHttpActionResult BuscarOperadoraVTTarifaTipo()
        {
            OperadoraVTFacade OperadoraVTFacade = new OperadoraVTFacade();

            var result = OperadoraVTFacade.BuscarOperadoraVTTarifaTipo();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Tudo OperadoraVT 
        /// </summary>        
        /// <remarks>Retorna Tudo OperadoraVT</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: OperadoraVT/BuscarTudoOperadoraVT
        [Route("BuscarTudoOperadoraVT", Name = "BuscarTudoOperadoraVT")]
        [HttpGet]
        public IHttpActionResult BuscarTudoOperadoraVT()
        {
            OperadoraVTFacade OperadoraVTFacade = new OperadoraVTFacade();

            var result = OperadoraVTFacade.BuscarTudoOperadoraVT();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona OperadoraVT 
        /// </summary>        
        /// <remarks>Adiciona a Operadora VT</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>                

        //POST: OperadoraVT/AdicionarOperadoraVT      
        [Route("AdicionarOperadoraVT", Name = "AdicionarOperadoraVT")]
        [HttpPost]
        public IHttpActionResult AdicionarOperadoraVT(OperadoraVTModel OperadoraVT)
        {
            OperadoraVTFacade OperadoraVTFacade = new OperadoraVTFacade();

            var result = OperadoraVTFacade.AdicionarOperadoraVT(OperadoraVT);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar OperadoraVT 
        /// </summary>        
        /// <remarks>Edita a OperadoraVT</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: OperadoraVT/EditarOperadoraVT      
        [Route("EditarOperadoraVT", Name = "EditarOperadoraVT")]
        [HttpPost]
        public IHttpActionResult EditarOperadoraVT(OperadoraVTModel OperadoraVT)
        {
            OperadoraVTFacade OperadoraVTFacade = new OperadoraVTFacade();

            var result = OperadoraVTFacade.EditarOperadoraVT(OperadoraVT);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Excluir benefício 
        /// </summary>        
        /// <remarks>Excluir o benefício</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: OperadoraVT/ExcluirOperadoraVT      
        [Route("ExcluirOperadoraVT", Name = "ExcluirOperadoraVT")]
        [HttpPost]
        public IHttpActionResult ExcluirOperadoraVT(int id)
        {
            OperadoraVTFacade OperadoraVTFacade = new OperadoraVTFacade();

            var result = OperadoraVTFacade.ExcluirOperadoraVT(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
