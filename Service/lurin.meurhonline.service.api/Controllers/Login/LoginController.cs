using System;
using System.Configuration;
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

namespace lurin.meurhonline.service.api.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Login")]
    public class LoginController : ApiController
    {
        /// <summary>
        /// Busca login 
        /// </summary>        
        /// <remarks>Retorna o login </remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Login/BuscarLogin
        [Route("BuscarLogin", Name = "BuscarLogin")]
        [HttpGet]

        public IHttpActionResult BuscarLogin(string cpf, string senha)
        {            
            LoginFacade loginFacade = new LoginFacade();

            var result = loginFacade.BuscarLogin(cpf, senha);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Recuperar senha
        /// </summary>        
        /// <remarks>Retorna o login </remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Login/RecuperarSenha
        [Route("RecuperarSenha", Name = "RecuperarSenha")]
        [HttpGet]
        public IHttpActionResult RecuperarSenha(string cpf)
        {
            LoginFacade loginFacade = new LoginFacade();

            var result = loginFacade.RecuperarSenha(cpf);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Alterar senha
        /// </summary>        
        /// <remarks>Retorna o login </remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Login/AlterarSenha
        [Route("AlterarSenha", Name = "AlterarSenha")]
        [HttpGet]
        public IHttpActionResult AlterarSenha(string cpf, string senha, string novaSenha)
        {
            LoginFacade loginFacade = new LoginFacade();

            var result = loginFacade.AlterarSenha(cpf, senha, novaSenha);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
