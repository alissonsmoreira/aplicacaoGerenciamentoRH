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
    [RoutePrefix("Turno")]
    public class TurnoController : ApiController
    {
        /// <summary>
        /// Busca Turno 
        /// </summary>        
        /// <remarks>Retorna o Turno</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Turno/BuscarTurno
        [Route("BuscarTurno", Name = "BuscarTurno")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult BuscarTurno(TurnoModel Turno)
        {
            TurnoFacade TurnoFacade = new TurnoFacade();

            var result = TurnoFacade.BuscarTurno(Turno);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Tudo Turno 
        /// </summary>        
        /// <remarks>Retorna Todos os Turnos</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Turno/BuscarTudoTurno
        [Route("BuscarTudoTurno", Name = "BuscarTudoTurno")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarTudoTurno()
        {
            TurnoFacade TurnoFacade = new TurnoFacade();

            var result = TurnoFacade.BuscarTudoTurno();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Turno Detalhe
        /// </summary>        
        /// <remarks>Retorna o Turno com os Detalhes através do Id do Turno</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Turno/BuscarTurnoDetalhe
        [Route("BuscarTurnoDetalhePorTurnoId", Name = "BuscarTurnoDetalhePorTurnoId")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarTurnoDetalhePorTurnoId(int idTurno)
        {
            TurnoFacade TurnoFacade = new TurnoFacade();

            var result = TurnoFacade.BuscarTurnoDetalhePorTurnoId(idTurno);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca TurnoDetalhe
        /// </summary>        
        /// <remarks>Retorna Detalhe do Turno</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Turno/BuscarTurnoDetalhe
        [Route("BuscarTurnoDetalhe", Name = "BuscarTurnoDetalhe")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult BuscarTurnoDetalhe(TurnoDetalheModel TurnoDetalhe)
        {
            TurnoFacade TurnoFacade = new TurnoFacade();

            var result = TurnoFacade.BuscarTurnoDetalhe(TurnoDetalhe);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona Turno 
        /// </summary>        
        /// <remarks>Adiciona o Turno</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: Turno/AdicionarTurno      
        [Route("AdicionarTurno", Name = "AdicionarTurno")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult AdicionarTurno(TurnoModel Turno)
        {
            TurnoFacade TurnoFacade = new TurnoFacade();

            var result = TurnoFacade.AdicionarTurno(Turno);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona Turno Detalhe
        /// </summary>        
        /// <remarks>Adiciona o Detalhe do Turno</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: Turno/AdicionarTurnoDetalhe   
        [Route("AdicionarTurnoDetalhe", Name = "AdicionarTurnoDetalhe")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult AdicionarTurnoDetalhe(TurnoDetalheModel TurnoDetalhe)
        {
            TurnoFacade TurnoFacade = new TurnoFacade();

            var result = TurnoFacade.AdicionarTurnoDetalhe(TurnoDetalhe);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar Turno 
        /// </summary>        
        /// <remarks>Edita o Turno</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: Turno/EditarTurno      
        [Route("EditarTurno", Name = "EditarTurno")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult EditarTurno(TurnoModel Turno)
        {
            TurnoFacade TurnoFacade = new TurnoFacade();

            var result = TurnoFacade.EditarTurno(Turno);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar Turno Detalhe
        /// </summary>        
        /// <remarks>Edita o Detalhe Turno</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: Turno/EditarTurnoDetalhe      
        [Route("EditarTurnoDetalhe", Name = "EditarTurnoDetalhe")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult EditarTurnoDetalhe(TurnoDetalheModel TurnoDetalhe)
        {
            TurnoFacade TurnoFacade = new TurnoFacade();

            var result = TurnoFacade.EditarTurnoDetalhe(TurnoDetalhe);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Excluir Turno 
        /// </summary>        
        /// <remarks>Excluir o Turno</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Turno/ExcluirTurno      
        [Route("ExcluirTurno", Name = "ExcluirTurno")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult ExcluirTurno(int id)
        {
            TurnoFacade TurnoFacade = new TurnoFacade();

            var result = TurnoFacade.ExcluirTurno(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Excluir Turno Detalhe
        /// </summary>        
        /// <remarks>Excluir o Detalhe do Turno</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Turno/ExcluirTurnoDetalhe      
        [Route("ExcluirTurnoDetalhe", Name = "ExcluirTurnoDetalhe")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult ExcluirTurnoDetalhe(int id)
        {
            TurnoFacade TurnoFacade = new TurnoFacade();

            var result = TurnoFacade.ExcluirTurnoDetalhe(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
