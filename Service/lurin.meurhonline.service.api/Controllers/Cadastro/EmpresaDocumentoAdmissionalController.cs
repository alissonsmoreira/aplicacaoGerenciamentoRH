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
    [RoutePrefix("EmpresaDocumentoAdmissional")]
    public class EmpresaDocumentoAdmissionalController : ApiController
    {
        /// <summary>
        /// Adiciona documento admissional para empresa
        /// </summary>        
        /// <remarks>Adiciona documento admissional para empresa</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>                

        //POST: EmpresaDocumentoAdmissional/AdicionarEmpresaDocumentoAdmissional      
        [Route("AdicionarEmpresaDocumentoAdmissional", Name = "AdicionarEmpresaDocumentoAdmissional")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult AdicionarEmpresaDocumentoAdmissional(IEnumerable<EmpresaDocumentoAdmissionalModel> empresaDocumentoAdmissional)
        {
            EmpresaFacade EmpresaFacade = new EmpresaFacade();

            var result = EmpresaFacade.AdicionarEmpresaDocumentoAdmissional(empresaDocumentoAdmissional);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
