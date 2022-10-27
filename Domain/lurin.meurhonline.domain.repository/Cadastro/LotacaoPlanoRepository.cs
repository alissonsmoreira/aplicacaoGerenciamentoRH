using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class LotacaoPlanoRepository : ILotacaoPlanoRepository<LotacaoPlanoModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public LotacaoPlanoRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public LotacaoPlanoModel GetLotacaoPlanobyId(int id)
        {
            var result = _db.LotacaoPlano
                            .Where(x => x.Id == id)
                            .Include(x => x.Empresa)
                            .Include(x => x.LotacaoPlanosUnidades.Select(u => u.LotacaoUnidade))
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<LotacaoPlanoModel> GetLotacaoPlano(LotacaoPlanoModel lotacaoPlano)
        {
            var result = _db.LotacaoPlano
                            .Where(x => lotacaoPlano.Codigo != 0 ? x.Codigo == lotacaoPlano.Codigo : x.Codigo != 0 || x.Codigo == 0)
                            .Where(x => !string.IsNullOrEmpty(lotacaoPlano.Nome) ? x.Nome.Contains(lotacaoPlano.Nome) : x.Nome != string.Empty)
                            .Where(x => lotacaoPlano.EmpresaId != 0 ? x.EmpresaId == lotacaoPlano.EmpresaId : x.EmpresaId != 0 || x.EmpresaId == 0)
                            .Include(x => x.Empresa)
                            .Include(x => x.LotacaoPlanosUnidades.Select(u => u.LotacaoUnidade))
                            .ToList();

            return result;
        }

        public LotacaoPlanoModel GetLotacaoPlanoValidation(LotacaoPlanoModel lotacaoPlano)
        {
            var result = _db.LotacaoPlano
                            .Where(x => lotacaoPlano.Id != 0 ? x.Id != lotacaoPlano.Id : x.Id != 0)
                            .Where(x => x.EmpresaId == lotacaoPlano.EmpresaId)
                            //.Where(x => x.Codigo == lotacaoPlano.Codigo)
                            //.Where(x => x.Nome == lotacaoPlano.Nome)
                            .FirstOrDefault();

            return result;
        }
    }
}