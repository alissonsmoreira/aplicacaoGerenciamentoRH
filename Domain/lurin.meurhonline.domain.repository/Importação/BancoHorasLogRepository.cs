using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class BancoHorasLogRepository : IBancoHorasLogRepository<BancoHorasLogModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public BancoHorasLogRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public BancoHorasLogModel GetBancoHorasLogById(int id)
        {
            var result = _db.BancoHorasLog
                            .Include(x => x.Empresa)
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<BancoHorasLogModel> GetBancoHorasLogByEmpresaId(int empresaId)
        {
            var result = _db.BancoHorasLog
                            .Include(x => x.Empresa)
                            .Where(x => x.EmpresaId == empresaId)
                            .ToList();

            return result;
        }

        public IEnumerable<BancoHorasLogModel> GetAllBancoHorasLog()
        {
            var result = _db.BancoHorasLog
                            .Include(x => x.Empresa)
                            .ToList();

            return result;
        }
    }
}