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
using lurin.meurhonline.domain.model.enumerator;

namespace lurin.meurhonline.service.api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("ColaboradorDocumentoAdmissional")]
    [Authorize]
    public class ColaboradorDocumentoAdmissionalController : ApiController
    {
        /// <summary>
        /// Busca Documento Anexo Colaborador
        /// </summary>        
        /// <remarks>Retorna Documento Anexo Colaborador</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //Post: ColaboradorDocumentoAdmissional/BuscarDocumentoAnexoColaborador
        [Route("BuscarDocumentoAnexoColaborador", Name = "BuscarDocumentoAnexoColaborador")]
        [HttpPost]
        public IHttpActionResult BuscarDocumentoAnexoColaborador(ColaboradorDocumentoAdmissionalModel colaboradorDocumentoAdmissional)
        {
            ColaboradorDocumentoAdmissionalFacade colaboradorDocumentoAdmissionalFacade = new ColaboradorDocumentoAdmissionalFacade();

            var result = colaboradorDocumentoAdmissionalFacade.BuscarDocumentoAdmissionalColaborador(colaboradorDocumentoAdmissional);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Documento Anexo Colaborador Pré-Admissão
        /// </summary>        
        /// <remarks>Retorna Documento Anexo Colaborador</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //Post: ColaboradorDocumentoAdmissional/BuscarDocumentoAdmissionalColaboradorPreAdmissao
        [Route("BuscarDocumentoAdmissionalColaboradorPreAdmissao", Name = "BuscarDocumentoAdmissionalColaboradorPreAdmissao")]
        [HttpPost]
        public IHttpActionResult BuscarDocumentoAdmissionalColaboradorPreAdmissao(ColaboradorDocumentoAdmissionalModel colaboradorDocumentoAdmissional)
        {
            ColaboradorDocumentoAdmissionalFacade colaboradorDocumentoAdmissionalFacade = new ColaboradorDocumentoAdmissionalFacade();

            var result = colaboradorDocumentoAdmissionalFacade.BuscarDocumentoAdmissionalColaboradorPreAdmissao(colaboradorDocumentoAdmissional);

            if (result == null)
                return NotFound();

            return Ok(result);
        }        

        /// <summary>
        /// Busca Arquivo Documento Anexo Colaborador
        /// </summary>        
        /// <remarks>Retorna o Arquivo Documento Anexo Colaborador</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //Get: ColaboradorDocumentoAdmissional/BuscarArquivoDocumentoAnexoColaborador
        [Route("BuscarArquivoDocumentoAnexoColaborador", Name = "BuscarArquivoDocumentoAnexoColaborador")]
        [HttpGet]
        public IHttpActionResult BuscarArquivoDocumentoAnexoColaborador(int id)
        {
            ColaboradorDocumentoAdmissionalFacade colaboradorDocumentoAdmissionalFacade = new ColaboradorDocumentoAdmissionalFacade();

            var result = colaboradorDocumentoAdmissionalFacade.BuscarArquivoDocumentoAnexoColaborador(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Arquivo Documento Anexo Pré Admissão Colaborador
        /// </summary>        
        /// <remarks>Retorna o Arquivo Documento Anexo da Pré Admissão do Colaborador</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //Get: ColaboradorDocumentoAdmissional/BuscarArquivoDocumentoAnexoColaborador
        [Route("BuscarArquivoDocumentoAnexoPreAdmissaoColaborador", Name = "BuscarArquivoDocumentoAnexoPreAdmissaoColaborador")]
        [HttpGet]
        public IHttpActionResult BuscarArquivoDocumentoAnexoPreAdmissaoColaborador(int id)
        {
            ColaboradorDocumentoAdmissionalFacade colaboradorDocumentoAdmissionalFacade = new ColaboradorDocumentoAdmissionalFacade();

            var result = colaboradorDocumentoAdmissionalFacade.BuscarArquivoDocumentoAnexoPreAdmissaoColaborador(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Salva Documento Anexo Colaborador 
        /// </summary>        
        /// <remarks>Salva o Documento Anexo Colaborador </remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: ColaboradorDocumentoAdmissional/SalvarDocumentoAnexoColaborador      
        [Route("SalvarDocumentoAnexoColaborador", Name = "SalvarDocumentoAnexoColaborador")]
        [HttpPost]
        public IHttpActionResult SalvarDocumentoAnexoColaborador(ColaboradorDocumentoAdmissionalModel colaboradorDocumentoAdmissional)
        {
            ColaboradorDocumentoAdmissionalFacade colaboradorDocumentoAdmissionalFacade = new ColaboradorDocumentoAdmissionalFacade();

            var result = colaboradorDocumentoAdmissionalFacade.SalvarDocumentoAdmissionalColaborador(colaboradorDocumentoAdmissional);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Remover Documento Anexo Colaborador 
        /// </summary>        
        /// <remarks>Remover o Documento Anexo Colaborador </remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: ColaboradorDocumentoAdmissional/SalvarDocumentoAnexoColaborador      
        [Route("RemoverDocumentoAnexoColaborador", Name = "RemoverDocumentoAnexoColaborador")]
        [HttpPost]
        public IHttpActionResult RemoverDocumentoAnexoColaborador(int id)
        {
            ColaboradorDocumentoAdmissionalFacade colaboradorDocumentoAdmissionalFacade = new ColaboradorDocumentoAdmissionalFacade();

            colaboradorDocumentoAdmissionalFacade.RemoverDocumentoAdmissionalColaborador(id);

            return Ok();
        }

        /// <summary>
        /// Remover Documento Anexo Colaborador 
        /// </summary>        
        /// <remarks>Remover o Documento Anexo Colaborador </remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: ColaboradorDocumentoAdmissional/SalvarDocumentoAnexoColaborador      
        [Route("RemoverDocumentoAnexoColaboradorPreAdmissional", Name = "RemoverDocumentoAnexoColaboradorPreAdmissional")]
        [HttpPost]
        public IHttpActionResult RemoverDocumentoAnexoColaboradorPreAdmissional(int id)
        {
            ColaboradorDocumentoAdmissionalFacade colaboradorDocumentoAdmissionalFacade = new ColaboradorDocumentoAdmissionalFacade();

            colaboradorDocumentoAdmissionalFacade.RemoverDocumentoPreAdmissionalColaborador(id);

            return Ok();
        }

        /// <summary>
        /// Busca Documento Anexo Colaborador Pré-Admissão Por Id
        /// </summary>        
        /// <remarks>Retorna Documento Anexo Colaborador</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: ColaboradorDocumentoAdmissional/BuscarDocumentoAnexoColaboradorPreAdmissaoPorId
        [Route("BuscarDocumentoAnexoColaboradorPreAdmissaoPorId", Name = "BuscarDocumentoAnexoColaboradorPreAdmissaoPorId")]
        [HttpGet]
        public IHttpActionResult BuscarDocumentoAnexoColaboradorPreAdmissaoPorId(int id)
        {
            ColaboradorDocumentoAdmissionalFacade colaboradorDocumentoAdmissionalFacade = new ColaboradorDocumentoAdmissionalFacade();

            var result = colaboradorDocumentoAdmissionalFacade.BuscarDocumentoAdmissionalColaboradorPreAdmissaoPorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
