using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class BancoHorasRepository : IBancoHorasRepository<BancoHorasModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public BancoHorasRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public BancoHorasModel GetBancoHorasById(int id)
        {
            var result = _db.BancoHoras
                            .Include(x => x.Colaborador)
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<BancoHorasModel> GetBancoHorasByEmpresaId(int empresaId)
        {
            var result = _db.BancoHoras
                            .Include(x => x.Colaborador)        
                            .Where(x => x.EmpresaId == empresaId)
                            .ToList();

            return result;
        }

        public IEnumerable<BancoHorasModel> GetAllBancoHoras()
        {
            var result = _db.BancoHoras
                            .Include(x => x.Colaborador)
                            .ToList();

            return result;
        }

        public IEnumerable<BancoHorasModel> GetBancoHorasByColaboradorId(int colaboradorId)
        {
            var result = _db.BancoHoras
                            .Include(x => x.Colaborador)
                            .Where(x => x.ColaboradorId == colaboradorId)
                            .ToList();

            return result;
        }

    }
}