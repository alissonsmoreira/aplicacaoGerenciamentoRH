using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class CidadeRepository : ICidadeRepository<CidadeModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public CidadeRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        
        public IEnumerable<CidadeModel> GetCidadebyUF(string uf)
        {
            var result = _db.Cidade
                            .Where(x => !string.IsNullOrEmpty(uf) ? x.UF == uf: x.UF != string.Empty)
                            .ToList();

            return result;
        }

    }
}