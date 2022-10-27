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
    [RoutePrefix("BandeiraCartaoVT")]
    [Authorize]
    public class OperadoraVTBandeiraCartaoController : ApiController
    {
        /// <summary>
        /// Busca Bandeira Cartão VT
        /// </summary>        
        /// <remarks>Retorna a Bandeira Cartão VT</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: BandeiraCartaoVT/BuscarBandeiraCartaoVT
        [Route("BuscarBandeiraCartaoVT", Name = "BuscarBandeiraCartaoVT")]
        [HttpPost]
        public IHttpActionResult BuscarOperadoraVTBandeiraCartao(OperadoraVTBandeiraCartaoModel operadoraVTBandeiraCartao)
        {
            OperadoraVTBandeiraCartaoFacade OperadoraVTBandeiraCartaoFacade = new OperadoraVTBandeiraCartaoFacade();

            var result = OperadoraVTBandeiraCartaoFacade.BuscarOperadoraVTBandeiraCartao(operadoraVTBandeiraCartao);

            if (result == null)
                return NotFound();

            return Ok(result);
        }



        /// <summary>
        /// Busca Tudo Bandeira Cartão VT 
        /// </summary>        
        /// <remarks>Retorna Tudo Bandeira Cartão VT</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: BandeiraCartaoVT/BuscarTudoBandeiraCartaoVT
        [Route("BuscarTudoBandeiraCartaoVT", Name = "BuscarTudoBandeiraCartaoVT")]
        [HttpGet]
        public IHttpActionResult BuscarTudoBandeiraCartaoVT()
        {
            OperadoraVTBandeiraCartaoFacade OperadoraVTBandeiraCartaoFacade = new OperadoraVTBandeiraCartaoFacade();

            var result = OperadoraVTBandeiraCartaoFacade.BuscarTudoOperadoraVTBandeiraCartao();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona Bandeira Cartão VT 
        /// </summary>        
        /// <remarks>Adiciona a Bandeira Cartão VT</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>                

        //POST: BandeiraCartaoVT/AdicionarBandeiraCartaoVT
        [Route("AdicionarBandeiraCartaoVT", Name = "AdicionarBandeiraCartaoVT")]
        [HttpPost]
        public IHttpActionResult AdicionarBandeiraCartaoVT(OperadoraVTBandeiraCartaoModel operadoraVTBandeiraCartao)
        {
            OperadoraVTBandeiraCartaoFacade OperadoraVTBandeiraCartaoFacade = new OperadoraVTBandeiraCartaoFacade();

            var result = OperadoraVTBandeiraCartaoFacade.AdicionarOperadoraVTBandeiraCartao(operadoraVTBandeiraCartao);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar Bandeira Cartão VT 
        /// </summary>        
        /// <remarks>Edita a Bandeira Cartão VT</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: BandeiraCartaoVT/EditarBandeiraCartaoVT      
        [Route("EditarBandeiraCartaoVT", Name = "EditarBandeiraCartaoVT")]
        [HttpPost]
        public IHttpActionResult EditarBandeiraCartaoVT(OperadoraVTBandeiraCartaoModel operadoraVTBandeiraCartao)
        {
            OperadoraVTBandeiraCartaoFacade OperadoraVTBandeiraCartaoFacade = new OperadoraVTBandeiraCartaoFacade();

            var result = OperadoraVTBandeiraCartaoFacade.EditarOperadoraVTBandeiraCartao(operadoraVTBandeiraCartao);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Excluir Bandeira Cartão VT 
        /// </summary>        
        /// <remarks>Excluir a Bandeira Cartão VT</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: BandeiraCartaoVT/ExcluirBandeiraCartaoVT
        [Route("ExcluirBandeiraCartaoVT", Name = "ExcluirBandeiraCartaoVT")]
        [HttpPost]
        public IHttpActionResult ExcluirBandeiraCartaoVT(int id)
        {
            OperadoraVTBandeiraCartaoFacade OperadoraVTBandeiraCartaoFacade = new OperadoraVTBandeiraCartaoFacade();

            var result = OperadoraVTBandeiraCartaoFacade.ExcluirOperadoraVTBandeiraCartao(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
