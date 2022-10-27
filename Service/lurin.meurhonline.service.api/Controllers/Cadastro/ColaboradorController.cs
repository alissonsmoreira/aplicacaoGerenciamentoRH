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
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.IO;
using ClosedXML.Excel;
using System.Net.Http.Headers;

namespace lurin.meurhonline.service.api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Colaborador")]
    [Authorize]
    public class ColaboradorController : BaseController
    {
        /// <summary>
        /// Busca Colaborador Dado Principal
        /// </summary>        
        /// <remarks>Retorna o Colaborador Dado Principal</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Colaborador/BuscarDadoPrincipalColaborador
        [Route("BuscarDadoPrincipalColaborador", Name = "BuscarDadoPrincipalColaborador")]
        [HttpPost]
        public IHttpActionResult BuscarDadoPrincipalColaborador(ColaboradorModel colaborador)
        {
            ColaboradorFacade colaboradorFacade = new ColaboradorFacade();

            var result = colaboradorFacade.BuscarColaboradorDadoPrincipal(colaborador);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Colaborador Dado Principal Pre-Admissão
        /// </summary>        
        /// <remarks>Retorna o Colaborador Dado Principal</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //POST: Colaborador/BuscarDadoPrincipalColaboradorPreAdmissao
        [Route("BuscarDadoPrincipalColaboradorPreAdmissao", Name = "BuscarDadoPrincipalColaboradorPreAdmissao")]
        [HttpPost]
        public IHttpActionResult BuscarDadoPrincipalColaboradorPreAdmissao(ColaboradorModel colaborador)
        {
            ColaboradorFacade colaboradorFacade = new ColaboradorFacade();

            var result = colaboradorFacade.BuscarDadoPrincipalColaboradorPreAdmissao(colaborador);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Colaborador Dado Principal por Id
        /// </summary>        
        /// <remarks>Retorna o Colaborador Dado Principal por Id</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Colaborador/BuscarColaboradorPorId
        [Route("BuscarColaboradorPorId", Name = "BuscarColaboradorPorId")]
        [HttpGet]
        public IHttpActionResult BuscarColaboradorPorId(int id)
        {
            ColaboradorFacade colaboradorFacade = new ColaboradorFacade();

            var result = colaboradorFacade.BuscarColaboradorDadoPrincipalPorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        //GET: Colaborador/BuscarColaboradorPorId
        [Route("BuscarColaboradorPorIdOuTipoDeRegistro", Name = "BuscarColaboradorPorIdOuTipoDeRegistro")]
        [HttpGet]
        public IHttpActionResult BuscarColaboradorPorIdOuTipoDeRegistro(int? id, int? tipoRegistro)
        {
            var idColaborador = ObterIdColaborador();
            ColaboradorFacade colaboradorFacade = new ColaboradorFacade();
            var result = colaboradorFacade.BuscarColaboradorPorIdOuTipoDeRegistro(id, tipoRegistro, idColaborador.Value);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Colaborador Dado Principal por Id
        /// </summary>        
        /// <remarks>Retorna o Colaborador Dado Principal por Id</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Colaborador/BuscarDadoPrincipalColaboradorPreAdmissaoPorId
        [Route("BuscarDadoPrincipalColaboradorPreAdmissaoPorId", Name = "BuscarDadoPrincipalColaboradorPreAdmissaoPorId")]
        [HttpGet]
        public IHttpActionResult BuscarDadoPrincipalColaboradorPreAdmissaoPorId(int id)
        {
            ColaboradorFacade colaboradorFacade = new ColaboradorFacade();

            var result = colaboradorFacade.BuscarColaboradorDadoPrincipalPreAdmissaoPorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona Colaborador Dado Principal
        /// </summary>        
        /// <remarks>Adiciona o Colaborador Dado Principal</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: Colaborador/AdicionarDadoPrincipalColaborador      
        [Route("AdicionarDadoPrincipalColaborador", Name = "AdicionarDadoPrincipalColaborador")]
        [HttpPost]
        public IHttpActionResult AdicionarDadoPrincipalColaborador(ColaboradorModel colaborador)
        {
            ColaboradorFacade colaboradorFacade = new ColaboradorFacade();

            colaborador.ColaboradorStatusId = (int)ColaboradorStatusEnum.ATIVO;
            var result = colaboradorFacade.AdicionarColaboradorDadoPrincipal(colaborador);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Adiciona Colaborador Dado Principal Pré-admissão
        /// </summary>        
        /// <remarks>Adiciona o Colaborador Dado Principal Pré-admissão</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: Colaborador/AdicionarDadoPrincipalColaboradorPreAdmissao      
        [Route("AdicionarDadoPrincipalColaboradorPreAdmissao", Name = "AdicionarDadoPrincipalColaboradorPreAdmissao")]
        [HttpPost]
        public IHttpActionResult AdicionarDadoPrincipalColaboradorPreAdmissao(ColaboradorModel colaborador)
        {
            ColaboradorFacade colaboradorFacade = new ColaboradorFacade();

            colaborador.ColaboradorStatusId = (int)ColaboradorStatusEnum.PRE_ADMISSAO;
            var result = colaboradorFacade.AdicionarColaboradorDadoPrincipal(colaborador);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Editar Colaborador Dado Principal
        /// </summary>        
        /// <remarks>Edita o Colaborador Dado Principal</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: Colaborador/EditarDadoPrincipalColaborador      
        [Route("EditarDadoPrincipalColaborador", Name = "EditarDadoPrincipalColaborador")]
        [HttpPost]
        public IHttpActionResult EditarDadoPrincipalColaborador(ColaboradorModel colaborador)
        {
            ColaboradorFacade ColaboradorFacade = new ColaboradorFacade();

            var result = ColaboradorFacade.EditarColaboradorDadoPrincipal(colaborador);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Aprovar Colaborador Pré Admissão
        /// </summary>        
        /// <remarks>Muda o status do colaborador para ATIVO</remarks>        
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="600">Internal Funcional Error</response>
        /// <returns></returns>        

        //POST: Colaborador/AprovarColaboradorPreAdmissao      
        [Route("AprovarColaboradorPreAdmissao", Name = "AprovarColaboradorPreAdmissao")]
        [HttpPost]
        public IHttpActionResult AprovarColaboradorPreAdmissao(int colaboradorId)
        {
            ColaboradorFacade ColaboradorFacade = new ColaboradorFacade();

            var result = ColaboradorFacade.AprovarColaboradorPreAdmissao(colaboradorId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca colaborador por nome 
        /// </summary>        
        /// <remarks>Retorna o colaborador por nome</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Empresa/BuscarColaboradorPorNome
        [Route("BuscarColaboradorPorNome", Name = "BuscarColaboradorPorNome")]
        [HttpGet]
        public IHttpActionResult BuscarColaboradorPorNome(string nome)
        {
            ColaboradorFacade colaboradorFacade = new ColaboradorFacade();

            var result = colaboradorFacade.BuscarColaboradorPorNome(nome);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca colaborador Pré-Admissão por nome 
        /// </summary>        
        /// <remarks>Retorna o colaborador por nome</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Empresa/BuscarColaboradorPreAdmissaoPorNome
        [Route("BuscarColaboradorPreAdmissaoPorNome", Name = "BuscarColaboradorPreAdmissaoPorNome")]
        [HttpGet]
        public IHttpActionResult BuscarColaboradorPreAdmissaoPorNome(string nome)
        {
            ColaboradorFacade colaboradorFacade = new ColaboradorFacade();

            var result = colaboradorFacade.BuscarColaboradorPreAdmissaoPorNome(nome);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca gestor por nome 
        /// </summary>        
        /// <remarks>Retorna o gestor por nome</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Empresa/BuscarGestorPorNome
        [Route("BuscarGestorPorNome", Name = "BuscarGestorPorNome")]
        [HttpGet]
        public IHttpActionResult BuscarGestorPorNome(string nome)
        {
            ColaboradorFacade colaboradorFacade = new ColaboradorFacade();

            var result = colaboradorFacade.BuscarGestorPorNome(nome);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Tudo Colaborador Tipo
        /// </summary>        
        /// <remarks>Retorna Tudo Colaborador Tipo</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Empresa/BuscarTudoColaboradorTipo
        [Route("BuscarTudoColaboradorTipo", Name = "BuscarTudoColaboradorTipo")]
        [HttpGet]
        public IHttpActionResult BuscarTudoColaboradorTipo()
        {
            ColaboradorFacade colaboradorFacade = new ColaboradorFacade();

            var result = colaboradorFacade.BuscarTudoColaboradorTipo();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Tudo Colaborador Status
        /// </summary>        
        /// <remarks>Retorna Tudo Colaborador Status</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Empresa/BuscarTudoColaboradorStatus
        [Route("BuscarTudoColaboradorStatus", Name = "BuscarTudoColaboradorStatus")]
        [HttpGet]
        public IHttpActionResult BuscarTudoColaboradorStatus()
        {
            ColaboradorFacade colaboradorFacade = new ColaboradorFacade();

            var result = colaboradorFacade.BuscarTudoColaboradorStatus();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Foto Colaborador
        /// </summary>        
        /// <remarks>Retorna o arquivo com a foto do colaborador</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Colaborador/BuscarFotoColaborador
        [Route("BuscarFotoColaborador", Name = "BuscarFotoColaborador")]
        [HttpGet]
        public IHttpActionResult BuscarArquivo(int id)
        {
            ColaboradorFacade colabradorFacade = new ColaboradorFacade();

            var result = colabradorFacade.BuscarFoto(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Busca Colaborador por Gestor Id
        /// </summary>        
        /// <remarks>Retorna o Colaborador por Gestor Id</remarks>    
        /// <response code="200">Ok</response>                
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>        

        //GET: Colaborador/BuscarColaboradorPorGestorId
        [Route("BuscarColaboradorPorGestorId", Name = "BuscarColaboradorPorGestorId")]
        [HttpGet]
        public IHttpActionResult BuscarColaboradorPorGestorId(int id)
        {
            ColaboradorFacade colaboradorFacade = new ColaboradorFacade();

            var result = colaboradorFacade.BuscarColaboradorPorGestorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        //GET: Colaborador/BuscarColaboradorPorId
        [Route("ExportarColaboradorPorIdOuTipoDeRegistro", Name = "ExportarColaboradorPorIdOuTipoDeRegistro")]
        [HttpGet]
        public HttpResponseMessage ExportarColaboradorPorIdOuTipoDeRegistro(int? id, int? tipoRegistro)
        {

            ColaboradorFacade colaboradorFacade = new ColaboradorFacade();
            var idColaborador = ObterIdColaborador();

            var result = colaboradorFacade.BuscarColaboradorPorIdOuTipoDeRegistro(id, tipoRegistro, idColaborador);

            var bytes = TransformarColaboradoresEmExcel(result);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(bytes)
            };
            response.Content.Headers.ContentDisposition =
                new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = $"Colaboradores_{DateTime.Now:dd-MM-yyyy_HH-mm-ss}.xlsx"
                };
            response.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

            return response;
        }

        private byte[] TransformarColaboradoresEmExcel(IEnumerable<ColaboradorFuncionarioModel> colaboradores)
        {
            System.Data.DataTable dt = new System.Data.DataTable("Colaboradores");
            dt.Columns.AddRange(new DataColumn[10] {
                new DataColumn("Nome"),
                new DataColumn("Empresa"),
                new DataColumn("Cargo"),
                new DataColumn("Centro De Custo"),
                new DataColumn("Unidade de Lotação"),
                new DataColumn("Unidade de Negócio"),
                new DataColumn("Salário"),
                new DataColumn("Turno"),
                new DataColumn("Data de Admissão"),
                new DataColumn("Tipo de Registro")
            });

            foreach (var item in colaboradores)
            {
                dt.Rows.Add(item.NomeColaborador, item.NomeEmpresa, item.Cargo, item.CentroDeCusto, item.UnidadeDeLotacao, item.UnidadeDeLotacao, item.Salario, item.Turno, item.DataAdmissao, item.TipoRegistro);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt).Columns().AdjustToContents();

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    stream.Position = 0;
                    return stream.ToArray();
                }
            }
        }
        
        //Post: Colaborador/ExcluirDadoPrincipalColaborador
        [Route("ExcluirDadoPrincipalColaborador", Name = "ExcluirDadoPrincipalColaborador")]
        [HttpPost]
        public IHttpActionResult ExcluirDadoPrincipalColaborador(ColaboradorModel colaborador)
        {
            ColaboradorFacade colaboradorFacade = new ColaboradorFacade();

            var result = colaboradorFacade.ExcluirDadoPrincipalColaboradorPreAdmissao(colaborador.Id);

            if (!result)
                return NotFound();

            return Ok(result);
        }

        //Post: Colaborador/ReenviarEmailColaborador
        [Route("ReenviarEmailColaborador", Name = "ReenviarEmailColaborador")]
        [HttpPost]
        public IHttpActionResult ReenviarEmailColaborador(ColaboradorEmail colaborador)
        {
            ColaboradorFacade colaboradorFacade = new ColaboradorFacade();
            var result = colaboradorFacade.EnviarEmailColaborador(colaborador.Email, colaborador.Nome, colaborador.Mensagem, colaborador.Cpf);

            if (!result)
                return NotFound();

            return Ok();
        }
    }
}
