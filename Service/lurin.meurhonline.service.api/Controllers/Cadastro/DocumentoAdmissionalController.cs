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
    [RoutePrefix("DocumentoAdmissional")]
    public class DocumentoAdmissionalController : ApiController
    {
        /// <summary>
        /// Busca Documento Admissional 
        /// </summary>        
        /// <remarks>Retorna o Documento Admissional</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: DocumentoAdmissional/BuscarDocumentoAdmissional
        [Route("BuscarDocumentoAdmissional", Name = "BuscarDocumentoAdmissional")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult BuscarDocumentoAdmissional(DocumentoAdmissionalModel DocumentoAdmissional)
        {
            DocumentoAdmissionalFacade DocumentoAdmissionalFacade = new DocumentoAdmissionalFacade();

            var result = DocumentoAdmissionalFacade.BuscarDocumentoAdmissional(DocumentoAdmissional);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Tudo Documento Admissional 
        /// </summary>        
        /// <remarks>Retorna todos os Documento Admissional</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: DocumentoAdmissional/BuscarTudoDocumentoAdmissional
        [Route("BuscarTudoDocumentoAdmissional", Name = "BuscarTudoDocumentoAdmissional")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult BuscarTudoDocumentoAdmissional()
        {
            DocumentoAdmissionalFacade DocumentoAdmissionalFacade = new DocumentoAdmissionalFacade();

            var result = DocumentoAdmissionalFacade.BuscarTudoDocumentoAdmissional();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona Documento Admissional 
        /// </summary>        
        /// <remarks>Adiciona o Documento Admissional</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: DocumentoAdmissional/AdicionarDocumentoAdmissional      
        [Route("AdicionarDocumentoAdmissional", Name = "AdicionarDocumentoAdmissional")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult AdicionarDocumentoAdmissional(DocumentoAdmissionalModel DocumentoAdmissional)
        {
            DocumentoAdmissionalFacade DocumentoAdmissionalFacade = new DocumentoAdmissionalFacade();

            var result = DocumentoAdmissionalFacade.AdicionarDocumentoAdmissional(DocumentoAdmissional);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar DocumentoA dmissional 
        /// </summary>        
        /// <remarks>Edita o Documento Admissional</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: DocumentoAdmissional/EditarDocumentoAdmissional      
        [Route("EditarDocumentoAdmissional", Name = "EditarDocumentoAdmissional")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult EditarDocumentoAdmissional(DocumentoAdmissionalModel DocumentoAdmissional)
        {
            DocumentoAdmissionalFacade DocumentoAdmissionalFacade = new DocumentoAdmissionalFacade();

            var result = DocumentoAdmissionalFacade.EditarDocumentoAdmissional(DocumentoAdmissional);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Excluir Documento Admissional 
        /// </summary>        
        /// <remarks>Excluir o Documento Admissional</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: DocumentoAdmissional/ExcluirDocumentoAdmissional      
        [Route("ExcluirDocumentoAdmissional", Name = "ExcluirDocumentoAdmissional")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult ExcluirDocumentoAdmissional(int id)
        {
            DocumentoAdmissionalFacade DocumentoAdmissionalFacade = new DocumentoAdmissionalFacade();

            var result = DocumentoAdmissionalFacade.ExcluirDocumentoAdmissional(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
