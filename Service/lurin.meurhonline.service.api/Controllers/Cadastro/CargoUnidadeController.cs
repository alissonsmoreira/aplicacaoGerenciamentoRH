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
    [RoutePrefix("CargoUnidade")]
    public class CargoUnidadeController : ApiController
    {
        /// <summary>
        /// Busca cargo unidade
        /// </summary>        
        /// <remarks>Retorna o cargo unidade</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: CargoUnidade/BuscarCargoUnidade
        [Route("BuscarCargoUnidade", Name = "BuscarCargoUnidade")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult BuscarCargoUnidade(CargoUnidadeModel cargoUnidade)
        {
            CargoUnidadeFacade cargoUnidadeFacade = new CargoUnidadeFacade();

            var result = cargoUnidadeFacade.BuscarCargoUnidade(cargoUnidade);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Tudo cargo unidade
        /// </summary>        
        /// <remarks>Retorna todos os cargos unidade</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: CargoUnidade/BuscarTudoCargoUnidade
        [Route("BuscarTudoCargoUnidade", Name = "BuscarTudoCargoUnidade")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarTudoCargoUnidade()
        {
            CargoUnidadeFacade cargoUnidadeFacade = new CargoUnidadeFacade();

            var result = cargoUnidadeFacade.BuscarTudoCargoUnidade();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Cargo Unidade por Id Empresa 
        /// </summary>        
        /// <remarks>Retorna cargo unidade por Id Empresa</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: CargoUnidade/BuscarCargoUnidadePorIdEmpresa
        [Route("BuscarCargoUnidadePorIdEmpresa", Name = "BuscarCargoUnidadePorIdEmpresa")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarCargoUnidadePorIdEmpresa(int id)
        {
            CargoUnidadeFacade cargoUnidadeFacade = new CargoUnidadeFacade();

            var result = cargoUnidadeFacade.BuscarCargoUnidadePorIdEmpresa(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona cargo unidade
        /// </summary>        
        /// <remarks>Adiciona o cargo unidade</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: CargoUnidade/AdicionarCargoUnidade      
        [Route("AdicionarCargoUnidade", Name = "AdicionarCargoUnidade")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult AdicionarCargoUnidade(CargoUnidadeModel cargoUnidade)
        {
            CargoUnidadeFacade cargoUnidadeFacade = new CargoUnidadeFacade();

            var result = cargoUnidadeFacade.AdicionarCargoUnidade(cargoUnidade);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar cargo unidade
        /// </summary>        
        /// <remarks>Edita o cargo unidade</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: CargoUnidade/EditarCargoUnidade      
        [Route("EditarCargoUnidade", Name = "EditarCargoUnidade")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult EditarCargoUnidade(CargoUnidadeModel cargoUnidade)
        {
            CargoUnidadeFacade cargoUnidadeFacade = new CargoUnidadeFacade();

            var result = cargoUnidadeFacade.EditarCargoUnidade(cargoUnidade);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Excluir cargo unidade
        /// </summary>        
        /// <remarks>Excluir o cargo unidade</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: CargoUnidade/ExcluirCargoUnidade      
        [Route("ExcluirCargoUnidade", Name = "ExcluirCargoUnidade")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult ExcluirCargoUnidade(int id)
        {
            CargoUnidadeFacade cargoUnidadeFacade = new CargoUnidadeFacade();

            var result = cargoUnidadeFacade.ExcluirCargoUnidade(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
