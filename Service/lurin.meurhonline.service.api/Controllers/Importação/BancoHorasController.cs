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
    [RoutePrefix("BancoHoras")]
    [Authorize]
    public class BancoHorasController : ApiController
    {
        /// <summary>
        /// Adiciona Banco de Horas
        /// </summary>        
        /// <remarks>Adiciona o Banco de Horas</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>                

        //POST: BancoHoras/ImportarBancoHoras    
        [Route("ImportarBancoHoras", Name = "ImportarBancoHoras")]
        [HttpPost]
        public IHttpActionResult ImportarBancoHoras(BancoHorasModel bancoHoras)
        {
            BancoHorasFacade BancoHorasFacade = new BancoHorasFacade();

            var result = BancoHorasFacade.AdicionarBancoHoras(bancoHoras);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        /// <summary>
        /// Busca Banco de Horas Por Empresa Id
        /// </summary>        
        /// <remarks>Retorna Banco de Horas Por Empresa Id</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: BancoHoras/BuscarBancoHorasPorEmpresaId
        [Route("BuscarBancoHorasPorEmpresaId", Name = "BuscarBancoHorasPorEmpresaId")]
        [HttpGet]
        public IHttpActionResult BuscarBancoHorasPorEmpresaId(int id)
        {
            BancoHorasFacade BancoHorasFacade = new BancoHorasFacade();

            var result = BancoHorasFacade.BuscarBancoHorasPorEmpresaId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Banco de Horas Log Por Empresa Id
        /// </summary>        
        /// <remarks>Retorna Banco de Horas Log Por Empresa Id</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: BancoHoras/BuscarBancoHorasLogPorEmpresaId
        [Route("BuscarBancoHorasLogPorEmpresaId", Name = "BuscarBancoHorasLogPorEmpresaId")]
        [HttpGet]
        public IHttpActionResult BuscarBancoHorasLogPorEmpresaId(int id)
        {
            BancoHorasFacade BancoHorasFacade = new BancoHorasFacade();

            var result = BancoHorasFacade.BuscarBancoHorasLogPorEmpresaId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Banco de Horas Por Gestor Id
        /// </summary>        
        /// <remarks>Retorna Banco de Horas Por Gestor Id</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: BancoHoras/BuscarBancoHorasPorGestorId
        [Route("BuscarBancoHorasPorGestorId", Name = "BuscarBancoHorasPorGestorId")]
        [HttpGet]
        public IHttpActionResult BuscarBancoHorasPorGestorId(int id)
        {
            BancoHorasFacade BancoHorasFacade = new BancoHorasFacade();

            var result = BancoHorasFacade.BuscarBancoHorasPorGestorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Banco de Horas Por Colaborador Id
        /// </summary>        
        /// <remarks>Retorna Banco de Horas Por Colaborador Id</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: BancoHoras/BuscarBancoHorasPorColaboradorId
        [Route("BuscarBancoHorasPorColaboradorId", Name = "BuscarBancoHorasPorColaboradorId")]
        [HttpGet]
        public IHttpActionResult BuscarBancoHorasPorColaboradorId(int id)
        {
            BancoHorasFacade BancoHorasFacade = new BancoHorasFacade();

            var result = BancoHorasFacade.BuscarBancoHorasPorColaboradorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
