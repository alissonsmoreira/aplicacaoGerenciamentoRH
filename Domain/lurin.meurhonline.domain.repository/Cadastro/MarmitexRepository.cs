using System.Linq;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class MarmitexRepository : IMarmitexRepository<MarmitexModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public MarmitexRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public MarmitexModel GetMarmitexbyId(int id)
        {
            var result = _db.Marmitex
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<MarmitexModel> GetMarmitex(MarmitexModel marmitex)
        {
            var result = _db.Marmitex
                            .Where(x => !string.IsNullOrEmpty(marmitex.Tipo) ? x.Tipo.Contains(marmitex.Tipo) : x.Tipo != string.Empty)
                            .ToList();

            return result;
        }

        public MarmitexModel GetMarmitexValidation(MarmitexModel marmitex)
        {
            var result = _db.Marmitex
                            .Where(x => marmitex.Id != 0 ? x.Id != marmitex.Id : x.Id != 0)
                            .Where(x => x.Tipo == marmitex.Tipo)
                            .FirstOrDefault();

            return result;
        }
    }
}