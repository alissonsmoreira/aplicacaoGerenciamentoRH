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
    [RoutePrefix("Beneficio")]
    [Authorize]
    public class BeneficioController : ApiController
    {
        /// <summary>
        /// Busca benefício 
        /// </summary>        
        /// <remarks>Retorna o benefício</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Beneficio/BuscarBeneficio
        [Route("BuscarBeneficio", Name = "BuscarBeneficio")]
        [HttpPost]
        public IHttpActionResult BuscarBeneficio(BeneficioModel beneficio)
        {
            BeneficioFacade beneficioFacade = new BeneficioFacade();

            var result = beneficioFacade.BuscarBeneficio(beneficio);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Tudo Benefício 
        /// </summary>        
        /// <remarks>Retorna todos os benefícios</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Beneficio/BuscarTudoBeneficio
        [Route("BuscarTudoBeneficio", Name = "BuscarTudoBeneficio")]
        [HttpGet]        
        public IHttpActionResult BuscarTudoBeneficio()
        {
            BeneficioFacade beneficioFacade = new BeneficioFacade();

            var result = beneficioFacade.BuscarTudoBeneficio();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca benefício tipo
        /// </summary>        
        /// <remarks>Retorna o benefício tipo</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Beneficio/BuscarBeneficioTipo
        [Route("BuscarBeneficioTipo", Name = "BuscarBeneficioTipo")]
        [HttpGet]        
        public IHttpActionResult BuscarBeneficioTipo()
        {
            BeneficioFacade beneficioFacade = new BeneficioFacade();

            var result = beneficioFacade.BuscarBeneficioTipo();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        
        /// <summary>
        /// Adiciona benefício 
        /// </summary>        
        /// <remarks>Adiciona o benefício</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>                

        //POST: Beneficio/AdicionarBeneficio      
        [Route("AdicionarBeneficio", Name = "AdicionarBeneficio")]
        [HttpPost]
        public IHttpActionResult AdicionarBeneficio(BeneficioModel beneficio)
        {
            BeneficioFacade beneficioFacade = new BeneficioFacade();

            var result = beneficioFacade.AdicionarBeneficio(beneficio);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar benefício 
        /// </summary>        
        /// <remarks>Edita o benefício</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: Beneficio/EditarBeneficio      
        [Route("EditarBeneficio", Name = "EditarBeneficio")]
        [HttpPost]
        public IHttpActionResult EditarBeneficio(BeneficioModel beneficio)
        {
            BeneficioFacade beneficioFacade = new BeneficioFacade();

            var result = beneficioFacade.EditarBeneficio(beneficio);

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

        //POST: Beneficio/ExcluirBeneficio      
        [Route("ExcluirBeneficio", Name = "ExcluirBeneficio")]
        [HttpPost]
        public IHttpActionResult ExcluirBeneficio(int id)
        {
            BeneficioFacade beneficioFacade = new BeneficioFacade();

            var result = beneficioFacade.ExcluirBeneficio(id);

            if (result == null)
                return NotFound();

            return Ok(result);            
        }

        /// <summary>
        /// Busca Solicitação Benefício Colaborador
        /// </summary>        
        /// <remarks>Retorna todos os benefícios</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //Post: Beneficio/BuscarSolicitacaoBeneficioColaborador
        [Route("BuscarSolicitacaoBeneficioColaborador", Name = "BuscarSolicitacaoBeneficioColaborador")]
        [HttpPost]
        public IHttpActionResult BuscarSolicitacaoBeneficioColaborador(BeneficioColaboradorModel beneficioColaborador)
        {
            BeneficioColaboradorFacade beneficioColaboradorFacade = new BeneficioColaboradorFacade();

            var result = beneficioColaboradorFacade.BuscarSolicitacaoBeneficioColaborador(beneficioColaborador);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca benefícios Por Colaborador Id
        /// </summary>        
        /// <remarks>Retorna todo benefício tipo</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Beneficio/BuscarTudoBeneficioColaboradorPorColaboradorId
        [Route("BuscarTudoBeneficioColaboradorPorColaboradorId", Name = "BuscarTudoBeneficioColaboradorPorColaboradorId")]
        [HttpGet]
        public IHttpActionResult BuscarTudoBeneficioColaboradorPorColaboradorId(int id)
        {
            BeneficioColaboradorFacade beneficioColaboradorFacade = new BeneficioColaboradorFacade();

            var result = beneficioColaboradorFacade.BuscarTudoBeneficioColaboradorPorColaboradorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Solicita benefício Colaborador
        /// </summary>        
        /// <remarks>Solicita benefício colaborador</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Beneficio/SolicitaBeneficio
        [Route("SolicitaBeneficio", Name = "SolicitaBeneficio")]
        [HttpPost]
        public IHttpActionResult SolicitaBeneficio(BeneficioColaboradorModel beneficioColaborador)
        {
            BeneficioColaboradorFacade beneficioColaboradorFacade = new BeneficioColaboradorFacade();

            var result = beneficioColaboradorFacade.SolicitarBeneficioColaborador(beneficioColaborador);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Aprova Solicitação Benefício Colaborador
        /// </summary>        
        /// <remarks>Aprova a solicitação de benefício colaborador</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Beneficio/AprovarSolicitacaoBeneficio
        [Route("AprovarSolicitacaoBeneficio", Name = "AprovarSolicitacaoBeneficio")]
        [HttpPost]
        public IHttpActionResult AprovarSolicitacaoBeneficio(int id)
        {
            BeneficioColaboradorFacade beneficioColaboradorFacade = new BeneficioColaboradorFacade();

            var result = beneficioColaboradorFacade.AprovarSolicitacaoBeneficioColaborador(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Reprova Solicitação Benefício Colaborador
        /// </summary>        
        /// <remarks>Reprova solicitação de benefício colaborador</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Beneficio/ReprovarSolicitacaoBeneficio
        [Route("ReprovarSolicitacaoBeneficio", Name = "ReprovarSolicitacaoBeneficio")]
        [HttpPost]
        public IHttpActionResult ReprovarSolicitacaoBeneficio(int id)
        {
            BeneficioColaboradorFacade beneficioColaboradorFacade = new BeneficioColaboradorFacade();

            var result = beneficioColaboradorFacade.ReprovarSolicitacaoBeneficioColaborador(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Cancela Solicitação Benefício Colaborador
        /// </summary>        
        /// <remarks>Cancela solicitação de benefício colaborador</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Beneficio/CancelarCancelarSolicitacaoBeneficioBeneficio
        [Route("CancelarSolicitacaoBeneficio", Name = "CancelarSolicitacaoBeneficio")]
        [HttpPost]
        public IHttpActionResult CancelarSolicitacaoBeneficio(int id)
        {
            BeneficioColaboradorFacade beneficioColaboradorFacade = new BeneficioColaboradorFacade();

            var result = beneficioColaboradorFacade.ExcluirBeneficioColaborador(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca benefícios Por Dependente Id
        /// </summary>        
        /// <remarks>Retorna todo benefício dependente por Dependente Id</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Beneficio/BuscarTudoBeneficioDependentePorDependenteId
        [Route("BuscarTudoBeneficioDependentePorDependenteId", Name = "BuscarTudoBeneficioDependentePorDependenteId")]
        [HttpGet]
        public IHttpActionResult BuscarTudoBeneficioDependentePorDependenteId(int id)
        {
            BeneficioDependenteFacade beneficioDependenteFacade = new BeneficioDependenteFacade();

            var result = beneficioDependenteFacade.BuscarTudoBeneficioDependentePorDependenteId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Solicita benefício Dependente
        /// </summary>        
        /// <remarks>Solicita benefício dependente</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Beneficio/SolicitaBeneficioDependente
        [Route("SolicitaBeneficioDependente", Name = "SolicitaBeneficioDependente")]
        [HttpPost]
        public IHttpActionResult SolicitaBeneficioDependente(BeneficioDependenteModel beneficioDependente)
        {
            BeneficioDependenteFacade beneficioDependenteFacade = new BeneficioDependenteFacade();

            var result = beneficioDependenteFacade.SolicitarBeneficioDependente(beneficioDependente);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Cancela benefício Dependente
        /// </summary>        
        /// <remarks>Cancela benefício dependente</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Beneficio/CancelaBeneficioDependente
        [Route("CancelaBeneficioDependente", Name = "CancelaBeneficioDependente")]
        [HttpPost]
        public IHttpActionResult CancelaBeneficioDependente(int id)
        {
            BeneficioDependenteFacade beneficioDependenteFacade = new BeneficioDependenteFacade();

            var result = beneficioDependenteFacade.SolicitarCancelamentoBeneficioDependente(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Aprova Solicitação Benefício Dependente
        /// </summary>        
        /// <remarks>Aprova a solicitação de benefício dependente</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Beneficio/AprovarSolicitacaoBeneficioDependente
        [Route("AprovarSolicitacaoBeneficioDependente", Name = "AprovarSolicitacaoBeneficioDependente")]
        [HttpPost]
        public IHttpActionResult AprovarSolicitacaoBeneficioDependente(int id)
        {
            BeneficioDependenteFacade beneficioDependenteFacade = new BeneficioDependenteFacade();

            var result = beneficioDependenteFacade.AprovarSolicitacaoBeneficioDependente(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Reprova Solicitação Benefício Dependente
        /// </summary>        
        /// <remarks>Reprova a solicitação de benefício dependente</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Beneficio/ReprovarSolicitacaoBeneficioDependente
        [Route("ReprovarSolicitacaoBeneficioDependente", Name = "ReprovarSolicitacaoBeneficioDependente")]
        [HttpPost]
        public IHttpActionResult ReprovarSolicitacaoBeneficioDependente(int id)
        {
            BeneficioDependenteFacade beneficioDependenteFacade = new BeneficioDependenteFacade();

            var result = beneficioDependenteFacade.ReprovarSolicitacaoBeneficioDependente(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Aprova Solicitação de Cancelamento Benefício Dependente
        /// </summary>        
        /// <remarks>Aprova a solicitação de benefício dependente</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Beneficio/AprovarCancelamentoBeneficioDependente
        [Route("AprovarCancelamentoBeneficioDependente", Name = "AprovarCancelamentoBeneficioDependente")]
        [HttpPost]
        public IHttpActionResult AprovarCancelamentoBeneficioDependente(int id)
        {
            BeneficioDependenteFacade beneficioDependenteFacade = new BeneficioDependenteFacade();

            var result = beneficioDependenteFacade.AprovarSolicitacaoCancelamentoBeneficioDependente(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Reprova Solicitação Cancelamento Benefício Dependente
        /// </summary>        
        /// <remarks>Reprova a solicitação de cancelamento de benefício dependente</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Beneficio/ReprovarCancelamentoBeneficioDependente
        [Route("ReprovarCancelamentoBeneficioDependente", Name = "ReprovarCancelamentoBeneficioDependente")]
        [HttpPost]
        public IHttpActionResult ReprovarCancelamentoBeneficioDependente(int id)
        {
            BeneficioDependenteFacade beneficioDependenteFacade = new BeneficioDependenteFacade();

            var result = beneficioDependenteFacade.ReprovarSolicitacaoCancelamentoBeneficioDependente(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
