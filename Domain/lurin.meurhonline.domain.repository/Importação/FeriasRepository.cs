using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class FeriasRepository : IFeriasRepository<FeriasModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public FeriasRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public FeriasModel GetFeriasById(int id)
        {
            var result = _db.Ferias
                            .Where(x => x.Id == id)
                            .Include(x => x.Periodo.Select(p => p.Concessao))
                            .Include(x => x.Colaborador)
                            .Include(x => x.Empresa)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<FeriasModel> GetFeriasByEmpresaId(int empresaId)
        {
            var result = _db.Ferias
                            .Where(x => x.EmpresaId == empresaId)
                            .Include(x => x.Periodo.Select(p => p.Concessao))
                            .Include(x => x.Colaborador)
                            .Include(x => x.Empresa)
                            .OrderByDescending(x => x.DataCadastro)
                            .ToList();

            return result;
        }

        public IEnumerable<FeriasModel> GetFeriasByColaboradorId(int colaboradorId)
        {
            List<FeriasModel> result = _db.Ferias
                            .Where(x => x.ColaboradorId == colaboradorId)
                            .Include(x => x.Periodo.Select(p => p.Concessao))
                            .Include(x => x.Colaborador)
                            .Include(x => x.Empresa)
                            .OrderByDescending(x => x.DataCadastro)
                            .ToList();

            return result;
        }
    }
}