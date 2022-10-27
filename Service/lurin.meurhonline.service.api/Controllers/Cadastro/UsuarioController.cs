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
    [RoutePrefix("Usuario")]
    [Authorize]
    public class UsuarioController : ApiController
    {
        /// <summary>
        /// Busca usuário
        /// </summary>        
        /// <remarks>Retorna o usuário</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Usuario/BuscarUsuario
        [Route("BuscarUsuario", Name = "BuscarUsuario")]
        [HttpPost]        
        public IHttpActionResult BuscarUsuario(UsuarioModel usuario)
        {
            UsuarioFacade UsuarioFacade = new UsuarioFacade();

            var result = UsuarioFacade.BuscarUsuario(usuario);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Usuario por Id
        /// </summary>        
        /// <remarks>Retorna o Usuario por Id</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Usuario/BuscarUsuarioPorId
        [Route("BuscarUsuarioPorId", Name = "BuscarUsuarioPorId")]
        [HttpGet]
        public IHttpActionResult BuscarUsuarioPorId(int id)
        {
            UsuarioFacade UsuarioFacade = new UsuarioFacade();

            var result = UsuarioFacade.BuscarUsuarioPorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona usuário
        /// </summary>        
        /// <remarks>Adiciona o usuário</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: Usuario/AdicionarUsuario      
        [Route("AdicionarUsuario", Name = "AdicionarUsuario")]
        [HttpPost]
        public IHttpActionResult AdicionarUsuario(UsuarioModel usuario)
        {
            UsuarioFacade UsuarioFacade = new UsuarioFacade();

            var result = UsuarioFacade.AdicionarUsuario(usuario);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar usuário
        /// </summary>        
        /// <remarks>Edita o usuário</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: Usuario/EditarUsuario      
        [Route("EditarUsuario", Name = "EditarUsuario")]
        [HttpPost]
        public IHttpActionResult EditarUsuario(UsuarioModel usuario)
        {
            UsuarioFacade UsuarioFacade = new UsuarioFacade();

            var result = UsuarioFacade.EditarUsuario(usuario);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Excluir usuário
        /// </summary>        
        /// <remarks>Excluir o usuário</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Usuario/ExcluirUsuario      
        [Route("ExcluirUsuario", Name = "ExcluirUsuario")]
        [HttpPost]
        public IHttpActionResult ExcluirUsuario(int id)
        {
            UsuarioFacade UsuarioFacade = new UsuarioFacade();

            var result = UsuarioFacade.ExcluirUsuario(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
