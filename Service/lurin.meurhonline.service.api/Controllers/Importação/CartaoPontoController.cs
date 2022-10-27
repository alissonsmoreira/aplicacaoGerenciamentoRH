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
    [RoutePrefix("CartaoPonto")]
    [Authorize]
    public class CartaoPontoController : ApiController
    {
        /// <summary>
        /// Adiciona Cartao de Ponto 
        /// </summary>        
        /// <remarks>Adiciona o Cartao de Ponto</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>                

        //POST: CartaoPonto/ImportarCartaoPonto    
        [Route("ImportarCartaoPonto", Name = "ImportarCartaoPonto")]
        [HttpPost]
        public IHttpActionResult ImportarCartaoPonto(CartaoPontoModel cartaoPonto)
        {
            CartaoPontoFacade cartaoPontoFacade = new CartaoPontoFacade();

            var result = cartaoPontoFacade.AdicionarCartaoPonto(cartaoPonto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Cartão de Ponto por Id
        /// </summary>        
        /// <remarks>Retorna o Cartao de Ponto Id</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: CartaoPonto/BuscarCartaoPontoPorId
        [Route("BuscarCartaoPontoPorId", Name = "BuscarCartaoPontoPorId")]
        [HttpGet]
        public IHttpActionResult BuscarCartaoPontoPorId(int id)
        {
            CartaoPontoFacade cartaoPontoFacade = new CartaoPontoFacade();

            var result = cartaoPontoFacade.BuscarCartaoPontoPorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Cartão de Ponto por Colaborador Id
        /// </summary>        
        /// <remarks>Retorna o Cartao de Ponto Por Colaborador Id</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: CartaoPonto/BuscarCartaoPontoPorColaboradorId
        [Route("BuscarCartaoPontoPorColaboradorId", Name = "BuscarCartaoPontoPorColaboradorId")]
        [HttpGet]
        public IHttpActionResult BuscarCartaoPontoPorColaboradorId(int id)
        {
            CartaoPontoFacade cartaoPontoFacade = new CartaoPontoFacade();

            var result = cartaoPontoFacade.BuscarCartaoPontoPorColaboradorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Cartão de Ponto por Colaborador ID, Mês e Ano.
        /// </summary>        
        /// <remarks>Retorna o Cartão de Pornto por Colaborador ID, Mês e Ano</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: CartaoPonto/BuscarCartaoPontoPorColaboradorIdMesAno
        [Route("BuscarCartaoPontoPorColaboradorIdMesAno", Name = "BuscarCartaoPontoPorColaboradorIdMesAno")]
        [HttpGet]
        public IHttpActionResult BuscarCartaoPontoPorColaboradorIdMesAno(int colaboradorId, string mes, string ano)
        {
            CartaoPontoFacade cartaoPontoFacade = new CartaoPontoFacade();

            var result = cartaoPontoFacade.BuscarCartaoPontoPorColaboradorIdMesAno(colaboradorId, mes, ano);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Excluir Cartão de Ponto por ID
        /// </summary>        
        /// <remarks>Exclui o Cartão de Ponto</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: CartaoPonto/ExcluirCartaoPontoPorId
        [Route("ExcluirCartaoPontoPorId", Name = "ExcluirCartaoPontoPorId")]
        [HttpPost]
        public IHttpActionResult ExcluirCartaoPontoPorId(int Id)
        {
            CartaoPontoFacade cartaoPontoFacade = new CartaoPontoFacade();

            var result = cartaoPontoFacade.ExcluirCartaoPontoPorId(Id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Aprovar Cartão de Ponto 
        /// </summary>        
        /// <remarks>Aprova o Cartão de Ponto</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: CartaoPonto/AprovarCartaoPonto
        [Route("AprovarCartaoPonto", Name = "AprovarCartaoPonto")]
        [HttpPost]
        public IHttpActionResult AprovarCartaoPonto(int id)
        {
            CartaoPontoFacade cartaoPontoFacade = new CartaoPontoFacade();

            var result = cartaoPontoFacade.AprovarCartaoPonto(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Reprovar Cartão de Ponto 
        /// </summary>        
        /// <remarks>Reprova o Cartão de Ponto</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: CartaoPonto/ReprovarCartaoPonto
        [Route("ReprovarCartaoPonto", Name = "ReprovarCartaoPonto")]
        [HttpPost]
        public IHttpActionResult ReprovarCartaoPonto(CartaoPontoModel cartaoPonto)
        {
            CartaoPontoFacade cartaoPontoFacade = new CartaoPontoFacade();

            var result = cartaoPontoFacade.ReprovarCartaoPonto(cartaoPonto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
