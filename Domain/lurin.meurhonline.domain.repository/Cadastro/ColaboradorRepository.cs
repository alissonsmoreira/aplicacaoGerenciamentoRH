using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.domain.model.enumerator;

namespace lurin.meurhonline.domain.repository
{
    public class ColaboradorRepository : IColaboradorRepository<ColaboradorModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public ColaboradorRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public ColaboradorModel GetColaboradorbyId(int? id)
        {
            var result = _db.Colaborador
                            .Include(x => x.Empresa)
                            .Include(x => x.ColaboradorTipo)
                            .Include(x => x.EstadoCivil)
                            .Include(x => x.GrauInstrucao)
                            .Where(x => x.Id == id)
                            .Where(x => x.ColaboradorStatusId != (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .FirstOrDefault();

            return result;
        }

        public ColaboradorModel GetColaboradorPreAdmissaobyId(int? id)
        {
            var result = _db.Colaborador
                            .Include(x => x.Empresa)
                            .Include(x => x.ColaboradorTipo)
                            .Include(x => x.EstadoCivil)
                            .Include(x => x.GrauInstrucao)
                            .Where(x => x.Id == id)
                            .Where(x => x.ColaboradorStatusId == (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .FirstOrDefault();

            return result;
        }
        public ColaboradorModel GetColaboradorPreAdmissaobyId(int id)
        {
            var result = _db.Colaborador
                            .Include(x => x.Empresa)
                            .Include(x => x.ColaboradorTipo)
                            .Include(x => x.EstadoCivil)
                            .Include(x => x.GrauInstrucao)
                            .Where(x => x.Id == id)
                            .Where(x => x.ColaboradorStatusId == (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .FirstOrDefault();

            return result;
        }
        public ColaboradorModel GetColaboradorbyCPF(string cpf)
        {
            var result = _db.Colaborador
                            .Include(x => x.Empresa)
                            .Include(x => x.ColaboradorTipo)
                            .Include(x => x.EstadoCivil)
                            .Include(x => x.GrauInstrucao)
                            .Where(x => x.CPF == cpf)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<ColaboradorModel> GetColaborador(ColaboradorModel colaborador)
        {
            var result = _db.Colaborador
                            .Include(x => x.Empresa)
                            .Include(x => x.ColaboradorTipo)
                            .Include(x => x.EstadoCivil)
                            .Include(x => x.GrauInstrucao)
                            .Where(x => x.ColaboradorStatusId != (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .Where(x => !string.IsNullOrEmpty(colaborador.Nome) ? x.Nome.Contains(colaborador.Nome) : x.Nome != string.Empty)
                            .Where(x => colaborador.EmpresaId != 0 ? (x.EmpresaId == colaborador.EmpresaId || x.Empresa.EmpresaMatrizId == colaborador.EmpresaId) : x.EmpresaId != 0)
                            .Where(x => colaborador.ColaboradorTipoId != 0 ? x.ColaboradorTipoId == colaborador.ColaboradorTipoId : x.ColaboradorTipoId != 0)
                            .Where(x => !string.IsNullOrEmpty(colaborador.CPF) ? x.CPF.Contains(colaborador.CPF) : x.CPF != string.Empty)
                            .Where(x => !string.IsNullOrEmpty(colaborador.Sexo) ? x.Sexo.Contains(colaborador.Sexo) : x.Sexo == x.Sexo)
                            .Where(x => !string.IsNullOrEmpty(colaborador.Endereco) ? x.Endereco.Contains(colaborador.Endereco) : x.Endereco == x.Endereco)
                            .Where(x => !string.IsNullOrEmpty(colaborador.Numero) ? x.Numero.Contains(colaborador.Numero) : x.Numero == x.Numero)
                            .Where(x => !string.IsNullOrEmpty(colaborador.Complemento) ? x.Complemento.Contains(colaborador.Complemento) : x.Complemento == x.Complemento)
                            .Where(x => !string.IsNullOrEmpty(colaborador.Bairro) ? x.Bairro.Contains(colaborador.Bairro) : x.Bairro == x.Bairro)
                            .Where(x => !string.IsNullOrEmpty(colaborador.CEP) ? x.CEP.Contains(colaborador.CEP) : x.CEP == x.CEP)
                            .Where(x => !string.IsNullOrEmpty(colaborador.UF) ? x.UF.Contains(colaborador.UF) : x.UF == x.UF)
                            .Where(x => !string.IsNullOrEmpty(colaborador.Cidade) ? x.Cidade.Contains(colaborador.Cidade) : x.Cidade == x.Cidade)
                            .Where(x => colaborador.DataNascimento != null ? x.DataNascimento == colaborador.DataNascimento : x.DataNascimento != null || x.DataNascimento == null)
                            .Where(x => !string.IsNullOrEmpty(colaborador.Telefone1) ? x.Telefone1.Contains(colaborador.Telefone1) : x.Telefone1 == x.Telefone1)
                            .Where(x => !string.IsNullOrEmpty(colaborador.Telefone2) ? x.Telefone2.Contains(colaborador.Telefone2) : x.Telefone2 == x.Telefone2)
                            .Where(x => !string.IsNullOrEmpty(colaborador.Telefone3) ? x.Telefone3.Contains(colaborador.Telefone3) : x.Telefone3 == x.Telefone3)
                            .Where(x => !string.IsNullOrEmpty(colaborador.Email) ? x.Email.Contains(colaborador.Email) : x.Email != string.Empty)
                            .Where(x => !string.IsNullOrEmpty(colaborador.NomePai) ? x.NomePai.Contains(colaborador.NomePai) : x.NomePai == x.NomePai)
                            .Where(x => !string.IsNullOrEmpty(colaborador.NomeMae) ? x.NomeMae.Contains(colaborador.NomeMae) : x.NomeMae == x.NomeMae)
                            .Where(x => !string.IsNullOrEmpty(colaborador.MatriculaInterna) ? x.MatriculaInterna.Contains(colaborador.MatriculaInterna) : x.MatriculaInterna == x.MatriculaInterna)
                            .Where(x => !string.IsNullOrEmpty(colaborador.MatriculaeSocial) ? x.MatriculaeSocial.Contains(colaborador.MatriculaeSocial) : x.MatriculaeSocial == x.MatriculaeSocial)
                            .Where(x => !string.IsNullOrEmpty(colaborador.PaisNascimento) ? x.PaisNascimento.Contains(colaborador.PaisNascimento) : x.PaisNascimento == x.PaisNascimento)
                            .Where(x => !string.IsNullOrEmpty(colaborador.UFNascimento) ? x.UFNascimento.Contains(colaborador.UFNascimento) : x.UFNascimento == x.UFNascimento)
                            .Where(x => !string.IsNullOrEmpty(colaborador.CidadeNascimento) ? x.CidadeNascimento.Contains(colaborador.CidadeNascimento) : x.CidadeNascimento == x.CidadeNascimento)
                            .Where(x => colaborador.GrauInstrucaoId != 0 ? x.GrauInstrucaoId == colaborador.GrauInstrucaoId : x.GrauInstrucaoId != 0)
                            .Where(x => colaborador.EstadoCivilId != 0 ? x.EstadoCivilId == colaborador.EstadoCivilId : x.EstadoCivilId != 0)
                            .Where(x => colaborador.ColaboradorStatusId != 0 ? x.ColaboradorStatusId == colaborador.ColaboradorStatusId : x.ColaboradorStatusId != 0)
                            .ToList();

            return result;
        }

        public IEnumerable<ColaboradorModel> GetColaboradorPreAdmissao(ColaboradorModel colaborador)
        {
            var result = _db.Colaborador
                            .Include(x => x.Empresa)
                            .Include(x => x.ColaboradorTipo)
                            .Include(x => x.EstadoCivil)
                            .Include(x => x.GrauInstrucao)
                            .Where(x => x.ColaboradorStatusId == (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .Where(x => !string.IsNullOrEmpty(colaborador.Nome) ? x.Nome.Contains(colaborador.Nome) : x.Nome != string.Empty)
                            .Where(x => colaborador.EmpresaId != 0 ? (x.EmpresaId == colaborador.EmpresaId || x.Empresa.EmpresaMatrizId == colaborador.EmpresaId) : x.EmpresaId != 0)
                            .Where(x => colaborador.ColaboradorTipoId != 0 ? x.ColaboradorTipoId == colaborador.ColaboradorTipoId : x.ColaboradorTipoId != 0)
                            .Where(x => !string.IsNullOrEmpty(colaborador.CPF) ? x.CPF.Contains(colaborador.CPF) : x.CPF != string.Empty)
                            .Where(x => !string.IsNullOrEmpty(colaborador.Sexo) ? x.Sexo.Contains(colaborador.Sexo) : x.Sexo == x.Sexo)
                            .Where(x => !string.IsNullOrEmpty(colaborador.Endereco) ? x.Endereco.Contains(colaborador.Endereco) : x.Endereco == x.Endereco)
                            .Where(x => !string.IsNullOrEmpty(colaborador.Numero) ? x.Numero.Contains(colaborador.Numero) : x.Numero == x.Numero)
                            .Where(x => !string.IsNullOrEmpty(colaborador.Complemento) ? x.Complemento.Contains(colaborador.Complemento) : x.Complemento == x.Complemento)
                            .Where(x => !string.IsNullOrEmpty(colaborador.Bairro) ? x.Bairro.Contains(colaborador.Bairro) : x.Bairro == x.Bairro)
                            .Where(x => !string.IsNullOrEmpty(colaborador.CEP) ? x.CEP.Contains(colaborador.CEP) : x.CEP == x.CEP)
                            .Where(x => !string.IsNullOrEmpty(colaborador.UF) ? x.UF.Contains(colaborador.UF) : x.UF == x.UF)
                            .Where(x => !string.IsNullOrEmpty(colaborador.Cidade) ? x.Cidade.Contains(colaborador.Cidade) : x.Cidade == x.Cidade)
                            .Where(x => colaborador.DataNascimento != null ? x.DataNascimento == colaborador.DataNascimento : x.DataNascimento != null || x.DataNascimento == null)
                            .Where(x => !string.IsNullOrEmpty(colaborador.Telefone1) ? x.Telefone1.Contains(colaborador.Telefone1) : x.Telefone1 == x.Telefone1)
                            .Where(x => !string.IsNullOrEmpty(colaborador.Telefone2) ? x.Telefone2.Contains(colaborador.Telefone2) : x.Telefone2 == x.Telefone2)
                            .Where(x => !string.IsNullOrEmpty(colaborador.Telefone3) ? x.Telefone3.Contains(colaborador.Telefone3) : x.Telefone3 == x.Telefone3)
                            .Where(x => !string.IsNullOrEmpty(colaborador.Email) ? x.Email.Contains(colaborador.Email) : x.Email != string.Empty)
                            .Where(x => !string.IsNullOrEmpty(colaborador.NomePai) ? x.NomePai.Contains(colaborador.NomePai) : x.NomePai == x.NomePai)
                            .Where(x => !string.IsNullOrEmpty(colaborador.NomeMae) ? x.NomeMae.Contains(colaborador.NomeMae) : x.NomeMae == x.NomeMae)
                            .Where(x => !string.IsNullOrEmpty(colaborador.MatriculaInterna) ? x.MatriculaInterna.Contains(colaborador.MatriculaInterna) : x.MatriculaInterna == x.MatriculaInterna)
                            .Where(x => !string.IsNullOrEmpty(colaborador.MatriculaeSocial) ? x.MatriculaeSocial.Contains(colaborador.MatriculaeSocial) : x.MatriculaeSocial == x.MatriculaeSocial)
                            .Where(x => !string.IsNullOrEmpty(colaborador.PaisNascimento) ? x.PaisNascimento.Contains(colaborador.PaisNascimento) : x.PaisNascimento == x.PaisNascimento)
                            .Where(x => !string.IsNullOrEmpty(colaborador.UFNascimento) ? x.UFNascimento.Contains(colaborador.UFNascimento) : x.UFNascimento == x.UFNascimento)
                            .Where(x => !string.IsNullOrEmpty(colaborador.CidadeNascimento) ? x.CidadeNascimento.Contains(colaborador.CidadeNascimento) : x.CidadeNascimento == x.CidadeNascimento)
                            .Where(x => colaborador.GrauInstrucaoId != 0 ? x.GrauInstrucaoId == colaborador.GrauInstrucaoId : x.GrauInstrucaoId != 0)
                            .Where(x => colaborador.EstadoCivilId != 0 ? x.EstadoCivilId == colaborador.EstadoCivilId : x.EstadoCivilId != 0)                            
                            .ToList();

            return result;
        }        

        public ColaboradorModel GetColaboradorValidation(ColaboradorModel colaborador)
        {
            var result = _db.Colaborador
                            .Where(x => colaborador.Id != 0 ? x.Id != colaborador.Id : x.Id != 0)
                            .Where(x => x.EmpresaId == colaborador.EmpresaId)
                            .Where(x => x.CPF == colaborador.CPF)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<ColaboradorModel> GetColaboradorByNome(string nomeColaborador)
        {
            var result = _db.Colaborador
                            .Include(x => x.Empresa)
                            .Include(x => x.Empresa.EmpresaDocumentosAdmissional.Select(u => u.DocumentoAdmissional))
                            .Include(x => x.ColaboradorTipo)
                            .Include(x => x.EstadoCivil)
                            .Include(x => x.GrauInstrucao)
                            .Where(x => x.Nome.StartsWith(nomeColaborador))                            
                            .Where(x => x.ColaboradorStatusId == (int)ColaboradorStatusEnum.ATIVO)
                            .ToList();

            return result;
        }

        public IEnumerable<ColaboradorModel> GetColaboradorPreAdmissaoByNome(string nomeColaborador)
        {
            var result = _db.Colaborador
                            .Include(x => x.Empresa)
                            .Include(x => x.Empresa.EmpresaDocumentosAdmissional.Select(u => u.DocumentoAdmissional))
                            .Include(x => x.ColaboradorTipo)
                            .Include(x => x.EstadoCivil)
                            .Include(x => x.GrauInstrucao)
                            .Where(x => x.Nome.StartsWith(nomeColaborador))
                            .Where(x => x.ColaboradorStatusId == (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .ToList();

            return result;
        }

        public IEnumerable<ColaboradorModel> GetGestorByNome(string nomeGestor)
        {
            var result = _db.Colaborador
                            .Include(x => x.Empresa)
                            .Include(x => x.ColaboradorTipo)
                            .Include(x => x.EstadoCivil)
                            .Include(x => x.GrauInstrucao)
                            .Where(x => x.Nome.StartsWith(nomeGestor))                            
                            .Where(x => x.ColaboradorStatusId == (int)ColaboradorStatusEnum.ATIVO)
                            .Where(x => x.ColaboradorTipo.Nome == "Gestor")
                            .ToList();

            return result;
        }

        public ColaboradorModel GetColaboradorbyMatricula(string matricula)
        {
            var result = _db.Colaborador
                            .Include(x => x.Empresa)
                            .Include(x => x.ColaboradorTipo)
                            .Include(x => x.EstadoCivil)
                            .Include(x => x.GrauInstrucao)
                            .Where(x => x.MatriculaInterna == matricula)
                            .FirstOrDefault();

            return result;
        }

        public ColaboradorModel GetColaboradorbyMatriculaEmpresa(string matricula, int empresaId)
        {
            var result = _db.Colaborador
                            .Include(x => x.Empresa)
                            .Include(x => x.ColaboradorTipo)
                            .Include(x => x.EstadoCivil)
                            .Include(x => x.GrauInstrucao)
                            .Where(x => x.MatriculaInterna == matricula)
                            .Where(x => x.EmpresaId == empresaId)
                            .FirstOrDefault();

            return result;
        }
    }
}