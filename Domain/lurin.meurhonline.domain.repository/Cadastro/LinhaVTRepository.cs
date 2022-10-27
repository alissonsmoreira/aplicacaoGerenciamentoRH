using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class LinhaVTRepository : ILinhaVTRepository<LinhaVTModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public LinhaVTRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public LinhaVTModel GetLinhaVTbyId(int id)
        {
            var result = _db.LinhaVT
                            .Include(x => x.OperadoraVT)
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<LinhaVTModel> GetLinhaVT(LinhaVTModel LinhaVT)
        {
            var result = _db.LinhaVT
                            .Include(x => x.OperadoraVT)
                            .Where(x => !string.IsNullOrEmpty(LinhaVT.NomeLinha) ? x.NomeLinha.Contains(LinhaVT.NomeLinha) : x.NomeLinha != string.Empty)
                            .Where(x => LinhaVT.ValorLinha != 0 ? x.ValorLinha == LinhaVT.ValorLinha : x.ValorLinha != 0 || x.ValorLinha == 0)
                            .Where(x => LinhaVT.OperadoraVTId != 0 ? x.OperadoraVTId == LinhaVT.OperadoraVTId : x.OperadoraVTId != 0)
                            .ToList();

            return result;
        }

        public IEnumerable<LinhaVTModel> GetLinhaVTbyOperadoraVTId(int id)
        {
            var result = _db.LinhaVT
                            .Include(x => x.OperadoraVT)
                            .Where(x => x.OperadoraVTId == id)
                            .ToList();

            return result;
        }

        public LinhaVTModel GetLinhaVTValidation(LinhaVTModel linhaVT)
        {
            var result = _db.LinhaVT
                            .Where(x => linhaVT.Id != 0 ? x.Id != linhaVT.Id : x.Id != 0)
                            .Where(x => x.OperadoraVTId == linhaVT.OperadoraVTId)
                            .Where(x => x.NomeLinha == linhaVT.NomeLinha)
                            .FirstOrDefault();

            return result;
        }
    }
}