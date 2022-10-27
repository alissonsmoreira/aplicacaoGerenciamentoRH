using System.Linq;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class LotacaoUnidadeRepository : ILotacaoUnidadeRepository<LotacaoUnidadeModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public LotacaoUnidadeRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public LotacaoUnidadeModel GetLotacaoUnidadebyId(int id)
        {
            var result = _db.LotacaoUnidade
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<LotacaoUnidadeModel> GetLotacaoUnidade(LotacaoUnidadeModel lotacaoUnidade)
        {
            var result = _db.LotacaoUnidade
                            .Where(x => lotacaoUnidade.Codigo != 0 ? x.Codigo == lotacaoUnidade.Codigo : x.Codigo != 0 || x.Codigo == 0)
                            .Where(x => !string.IsNullOrEmpty(lotacaoUnidade.Nome) ? x.Nome.Contains(lotacaoUnidade.Nome) : x.Nome != string.Empty)
                            .ToList();

            return result;
        }

        public LotacaoUnidadeModel GetLotacaoUnidadeValidation(LotacaoUnidadeModel lotacaoUnidade)
        {
            var result = _db.LotacaoUnidade
                            .Where(x => lotacaoUnidade.Id != 0 ? x.Id != lotacaoUnidade.Id : x.Id != 0)
                            .Where(x => x.Codigo == lotacaoUnidade.Codigo)
                            .Where(x => x.Nome == lotacaoUnidade.Nome)
                            .FirstOrDefault();

            return result;
        }
    }
}