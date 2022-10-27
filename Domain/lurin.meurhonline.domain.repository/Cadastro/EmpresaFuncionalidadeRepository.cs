using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.model.enumerator;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class EmpresaFuncionalidadeRepository : IEmpresaFuncionalidadeRepository<EmpresaFuncionalidadeModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public EmpresaFuncionalidadeRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public EmpresaFuncionalidadeModel GetEmpresaFuncionalidadebyId(int id)
        {
            var result = _db.EmpresaFuncionalidade
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<EmpresaFuncionalidadeModel> GetEmpresaFuncionalidade(EmpresaFuncionalidadeModel empresaFuncionalidade)
        {
            var result = _db.EmpresaFuncionalidade
                            .Where(x => empresaFuncionalidade.Id != 0 ? x.Id == empresaFuncionalidade.Id : x.Id != 0 || x.Id == 0)
                            .Where(x => !string.IsNullOrEmpty(empresaFuncionalidade.Grupo) ? x.Grupo.Contains(empresaFuncionalidade.Grupo) : x.Grupo == x.Grupo)
                            .Where(x => !string.IsNullOrEmpty(empresaFuncionalidade.TipoFuncionario) ? x.TipoFuncionario.Contains(empresaFuncionalidade.TipoFuncionario) : x.TipoFuncionario == x.TipoFuncionario)
                            .Where(x => !string.IsNullOrEmpty(empresaFuncionalidade.Nome) ? x.Nome.Contains(empresaFuncionalidade.Nome) : x.Nome == x.Nome)
                            .ToList();

            return result;
        }

        public IEnumerable<EmpresaFuncionalidadeModel> GetEmpresaFuncionalidadePadrao()
        {
            var result = _db.EmpresaFuncionalidade
                            .Where(x => x.Nome != "Marmitex na Hora Extra")
                            .ToList();

            return result;
        }
    }
}