using System;
using System.Threading.Tasks;
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
    [RoutePrefix("Notificacao")]
    [Authorize]
    public class NotificacaoController : ApiController
    {
        /// <summary>
        /// Busca notificação 
        /// </summary>        
        /// <remarks>Retorna a notificação </remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Notificacao/BuscarNotificacao
        [Route("BuscarNotificacao", Name = "BuscarNotificacao")]
        [HttpGet]
        public IHttpActionResult BuscarNotificacao(int idUsuarioColaborador, int idUsuarioColaboradorTipo)
        {
            NotificacaoFacade NotificacaoFacade = new NotificacaoFacade();

            var result = NotificacaoFacade.BuscarNotificacao(idUsuarioColaborador, idUsuarioColaboradorTipo);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Atualiza Status Leitura
        /// </summary>        
        /// <remarks>Atualiza o status de leitura</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>     

        //POST: Notificacao/AtualizarStatusLeituraAsync  
        [Route("AtualizarStatusLeituraAsync", Name = "AtualizarStatusLeituraAsync")]
        [HttpPost]        
        public async Task<IHttpActionResult> AtualizarStatusLeituraAsync(int idNotificacaoDetalhe)
        {
            NotificacaoFacade NotificacaoFacade = new NotificacaoFacade();

            var result = await NotificacaoFacade.AtualizarStatusLeituraAsync(idNotificacaoDetalhe);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
