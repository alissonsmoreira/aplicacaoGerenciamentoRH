using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class EmpresaEmpresaFuncionalidadeRepository : IEmpresaEmpresaFuncionalidadeRepository<EmpresaEmpresaFuncionalidadeModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public EmpresaEmpresaFuncionalidadeRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public EmpresaEmpresaFuncionalidadeModel GetEmpresaEmpresaFuncionalidadeById(int empresaId, int EmpresaFuncionalidadeId)
        {
            var result = _db.EmpresaEmpresaFuncionalidade
                            .Where(x => x.EmpresaId == empresaId)
                            .Where(x => x.EmpresaFuncionalidadeId == EmpresaFuncionalidadeId)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<EmpresaEmpresaFuncionalidadeModel> GetEmpresaEmpresaFuncionalidade(EmpresaEmpresaFuncionalidadeModel empresaEmpresaFuncionalidade)
        {
            var result = _db.EmpresaEmpresaFuncionalidade
                            .Where(x => empresaEmpresaFuncionalidade.EmpresaId != 0 ? x.EmpresaId == empresaEmpresaFuncionalidade.EmpresaId : x.EmpresaId != 0 || x.EmpresaId == 0)
                            .Where(x => empresaEmpresaFuncionalidade.EmpresaFuncionalidadeId != 0 ? x.EmpresaFuncionalidadeId == empresaEmpresaFuncionalidade.EmpresaFuncionalidadeId : x.EmpresaFuncionalidadeId != 0)
                            .ToList();

            return result;
        }

        public IEnumerable<EmpresaEmpresaFuncionalidadeModel> GetEmpresaEmpresaFuncionalidadeByEmpresaId(int empresaId)
        {
            var result = _db.EmpresaEmpresaFuncionalidade
                            .Where(x => x.EmpresaId == empresaId)
                            .ToList();

            return result;
        }
    }
}