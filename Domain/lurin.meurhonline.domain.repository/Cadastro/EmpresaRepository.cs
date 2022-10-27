using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.model.enumerator;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class EmpresaRepository : IEmpresaRepository<EmpresaModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public EmpresaRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public EmpresaModel GetEmpresabyId(int id)
        {
            var result = _db.Empresa
                            .Where(x => x.Id == id)
                            .Include(x => x.EmpresaTipo)
                            .Include(x => x.EmpresaDocumentosAdmissional.Select(u => u.DocumentoAdmissional))
                            .Include(x => x.EmpresaEmpresaFuncionalidades.Select(u => u.EmpresaFuncionalidade))
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<EmpresaModel> GetEmpresa(EmpresaModel empresa)
        {
            var result = _db.Empresa
                            //.Where(x => x.EmpresaStatusId == (int)EmpresaStatusEnum.ATIVO)
                            .Include(x => x.EmpresaTipo)
                            .Where(x => !string.IsNullOrEmpty(empresa.Nome) ? x.Nome.Contains(empresa.Nome) : x.Nome != string.Empty)
                            .Where(x => !string.IsNullOrEmpty(empresa.CNPJ) ? x.CNPJ.Contains(empresa.CNPJ) : x.CNPJ != string.Empty)
                            .Where(x => !string.IsNullOrEmpty(empresa.InscricaoEstadual) ? x.InscricaoEstadual.Contains(empresa.InscricaoEstadual) : x.InscricaoEstadual == x.InscricaoEstadual)
                            .Where(x => !string.IsNullOrEmpty(empresa.InscricaoMunicipal) ? x.InscricaoMunicipal.Contains(empresa.InscricaoMunicipal) : x.InscricaoMunicipal == x.InscricaoMunicipal)
                            .Where(x => !string.IsNullOrEmpty(empresa.Endereco) ? x.Endereco.Contains(empresa.Endereco) : x.Endereco == x.Endereco)
                            .Where(x => !string.IsNullOrEmpty(empresa.Numero) ? x.Numero.Contains(empresa.Numero) : x.Numero == x.Numero)
                            .Where(x => !string.IsNullOrEmpty(empresa.Bairro) ? x.Bairro.Contains(empresa.Bairro) : x.Bairro == x.Bairro)
                            .Where(x => !string.IsNullOrEmpty(empresa.CEP) ? x.CEP.Contains(empresa.CEP) : x.CEP == x.CEP)
                            .Where(x => !string.IsNullOrEmpty(empresa.Cidade) ? x.Cidade.Contains(empresa.Cidade) : x.Cidade == x.Cidade)
                            .Where(x => !string.IsNullOrEmpty(empresa.UF) ? x.UF.Contains(empresa.UF) : x.UF == x.UF)
                            .Where(x => !string.IsNullOrEmpty(empresa.TelefoneContato1) ? x.TelefoneContato1.Contains(empresa.TelefoneContato1) : x.TelefoneContato1 == x.TelefoneContato1)
                            .Where(x => !string.IsNullOrEmpty(empresa.EmailContato1) ? x.EmailContato1.Contains(empresa.EmailContato1) : x.EmailContato1 == x.EmailContato1)
                            .Where(x => !string.IsNullOrEmpty(empresa.TelefoneContato2) ? x.TelefoneContato2.Contains(empresa.TelefoneContato2) : x.TelefoneContato2 == x.TelefoneContato2)
                            .Where(x => !string.IsNullOrEmpty(empresa.EmailContato2) ? x.EmailContato2.Contains(empresa.EmailContato2) : x.EmailContato2 == x.EmailContato2)
                            .Where(x => !string.IsNullOrEmpty(empresa.TelefoneContato3) ? x.TelefoneContato3.Contains(empresa.TelefoneContato3) : x.TelefoneContato3 == x.TelefoneContato3)
                            .Where(x => !string.IsNullOrEmpty(empresa.EmailContato3) ? x.EmailContato3.Contains(empresa.EmailContato3) : x.EmailContato3 == x.EmailContato3)
                            .Where(x => empresa.EmpresaTipoId != 0 ? x.EmpresaTipoId == empresa.EmpresaTipoId : x.EmpresaTipoId != 0 || x.EmpresaTipoId == 0)
                            .Where(x => empresa.EmpresaMatrizId != 0 ? x.EmpresaMatrizId == empresa.EmpresaMatrizId : x.EmpresaMatrizId != 0 || x.EmpresaMatrizId == 0)
                            .Include(x => x.EmpresaDocumentosAdmissional.Select(u => u.DocumentoAdmissional))
                            .Include(x => x.EmpresaEmpresaFuncionalidades.Select(u => u.EmpresaFuncionalidade))
                            .ToList();

            return result;
        }

        public IEnumerable<EmpresaModel> GetEmpresaByNome(string nomeEmpresa)
        {
            var result = _db.Empresa                                                    
                            .Where(x => x.EmpresaStatusId == (int)EmpresaStatusEnum.ATIVO)
                            .Where(x => x.Nome.StartsWith(nomeEmpresa))
                            .ToList();

            return result;
        }

        public IEnumerable<EmpresaModel> GetEmpresaMatrizByNome(string nomeEmpresa)
        {
            var result = _db.Empresa
                            .Include(x => x.EmpresaTipo)                            
                            .Where(x => x.EmpresaStatusId == (int)EmpresaStatusEnum.ATIVO)
                            .Where(x => x.EmpresaTipoId == 1) //Matriz
                            .Where(x => x.Nome.StartsWith(nomeEmpresa))
                            .ToList();

            return result;
        }

        public EmpresaModel GetEmpresaValidation(EmpresaModel empresa)
        {
            var result = _db.Empresa
                            .Where(x => empresa.Id != 0 ? x.Id != empresa.Id : x.Id != 0)
                            .Where(x => x.CNPJ == empresa.CNPJ)
                            .FirstOrDefault();

            return result;
        }
        
        public IEnumerable<EmpresaModel> GetEmpresaGrupoByEmpresaMatrizId(int id)
        {
            var result = _db.Empresa
                            .Where(x => x.Id == id || x.EmpresaMatrizId == id)
                            .Where(x => x.EmpresaStatusId == (int)EmpresaStatusEnum.ATIVO)
                            .ToList();

            return result;
        }

        public EmpresaModel GetEmpresaByCNPJ(string cnpj)
        {
            var result = _db.Empresa
                            .Where(x => x.CNPJ == cnpj)
                            .FirstOrDefault();

            return result;
        }
    }
}