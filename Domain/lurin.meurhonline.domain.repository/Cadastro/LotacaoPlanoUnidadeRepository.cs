using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class LotacaoPlanoUnidadeRepository : ILotacaoPlanoUnidadeRepository<LotacaoPlanoUnidadeModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public LotacaoPlanoUnidadeRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public LotacaoPlanoUnidadeModel GetLotacaoPlanoUnidadeById(int lotacaoPlanoId, int lotacaoUnidadeId)
        {
            var result = _db.LotacaoPlanoUnidade
                            .Where(x => x.LotacaoPlanoId == lotacaoPlanoId)
                            .Where(x => x.LotacaoUnidadeId == lotacaoUnidadeId)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<LotacaoPlanoUnidadeModel> GetLotacaoPlanoUnidade(LotacaoPlanoUnidadeModel lotacaoPlanoUnidade)
        {
            var result = _db.LotacaoPlanoUnidade
                            .Where(x => lotacaoPlanoUnidade.LotacaoPlanoId != 0 ? x.LotacaoPlanoId == lotacaoPlanoUnidade.LotacaoPlanoId : x.LotacaoPlanoId != 0 || x.LotacaoPlanoId == 0)
                            .Where(x => lotacaoPlanoUnidade.LotacaoUnidadeId != 0 ? x.LotacaoUnidadeId == lotacaoPlanoUnidade.LotacaoUnidadeId : x.LotacaoUnidadeId != 0)
                            .ToList();

            return result;
        }

        public IEnumerable<LotacaoPlanoUnidadeModel> GetLotacaoPlanoUnidadeByLotacaoPlanoId(int lotacaoPlanoId)
        {
            var result = _db.LotacaoPlanoUnidade
                            .Where(x => x.LotacaoPlanoId == lotacaoPlanoId)
                            .ToList();

            return result;
        }

        public IEnumerable<LotacaoPlanoUnidadeModel> GetLotacaoUnidadeByEmpresaId(int empresaId)
        {
            var result = _db.LotacaoPlanoUnidade
                            .Include(x => x.LotacaoUnidade)
                            .Where(x => x.LotacaoPlano.EmpresaId == empresaId)
                            .ToList();

            return result;
        }
        public LotacaoPlanoUnidadeModel GetLotacaoPlanoUnidadeValidation(LotacaoPlanoUnidadeModel lotacaoPlanoUnidade)
        {
            var result = _db.LotacaoPlanoUnidade
                            .Where(x => x.LotacaoPlanoId == lotacaoPlanoUnidade.LotacaoPlanoId)
                            .Where(x => x.LotacaoUnidadeId == lotacaoPlanoUnidade.LotacaoUnidadeId)
                            .FirstOrDefault();

            return result;
        }
    }
}