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
    [RoutePrefix("CargoPlano")]
    [Authorize]
    public class CargoPlanoController : ApiController
    {
        /// <summary>
        /// Busca cargo plano
        /// </summary>        
        /// <remarks>Retorna o cargo plano</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: CargoPlano/BuscarCargoPlano
        [Route("BuscarCargoPlano", Name = "BuscarCargoPlano")]
        [HttpPost]        
        public IHttpActionResult BuscarCargoPlano(CargoPlanoModel cargoPlano)
        {
            CargoPlanoFacade CargoPlanoFacade = new CargoPlanoFacade();

            var result = CargoPlanoFacade.BuscarCargoPlano(cargoPlano);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        /// <summary>
        /// Adiciona cargo plano
        /// </summary>        
        /// <remarks>Adiciona o cargo plano</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: CargoPlano/AdicionarCargoPlano      
        [Route("AdicionarCargoPlano", Name = "AdicionarCargoPlano")]
        [HttpPost]        
        public IHttpActionResult AdicionarCargoPlano(CargoPlanoModel cargoPlano)
        {
            CargoPlanoFacade CargoPlanoFacade = new CargoPlanoFacade();

            var result = CargoPlanoFacade.AdicionarCargoPlano(cargoPlano);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona cargo plano unidade
        /// </summary>        
        /// <remarks>Adiciona o cargo plano unidade</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: CargoPlano/AdicionarCargoPlanoUnidade      
        [Route("AdicionarCargoPlanoUnidade", Name = "AdicionarCargoPlanoUnidade")]
        [HttpPost]        
        public IHttpActionResult AdicionarCargoPlanoUnidade(IEnumerable<CargoPlanoUnidadeModel> cargoPlanoUnidade)
        {
            CargoPlanoFacade CargoPlanoFacade = new CargoPlanoFacade();

            var result = CargoPlanoFacade.AdicionarCargoPlanoUnidade(cargoPlanoUnidade);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar cargo plano
        /// </summary>        
        /// <remarks>Edita o cargo plano</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: CargoPlano/EditarCargoPlano      
        [Route("EditarCargoPlano", Name = "EditarCargoPlano")]
        [HttpPost]        
        public IHttpActionResult EditarCargoPlano(CargoPlanoModel cargoPlano)
        {
            CargoPlanoFacade CargoPlanoFacade = new CargoPlanoFacade();

            var result = CargoPlanoFacade.EditarCargoPlano(cargoPlano);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Excluir cargo plano
        /// </summary>        
        /// <remarks>Excluir o cargo plano</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: CargoPlano/ExcluirCargoPlano      
        [Route("ExcluirCargoPlano", Name = "ExcluirCargoPlano")]
        [HttpPost]        
        public IHttpActionResult ExcluirCargoPlano(int id)
        {
            CargoPlanoFacade CargoPlanoFacade = new CargoPlanoFacade();

            var result = CargoPlanoFacade.ExcluirCargoPlano(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
