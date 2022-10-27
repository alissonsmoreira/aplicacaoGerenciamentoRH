using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.domain.model.enumerator;

namespace lurin.meurhonline.domain.repository
{
    public class AlteracaoCadastralRepository : IAlteracaoCadastralRepository<AlteracaoCadastralModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public AlteracaoCadastralRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public AlteracaoCadastralModel GetAlteracaoCadastralbyId(int id)
        {
            var result = _db.AlteracaoCadastral
                            .Include(x => x.Colaborador)
                            .Include(x => x.Colaborador.Empresa)
                            .Include(x => x.Banco)
                            .Include(x => x.ContaBancariaTipo)
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<AlteracaoCadastralModel> GetAlteracaoCadastral(AlteracaoCadastralModel alteracaoCadastral)
        {
            var result = _db.AlteracaoCadastral
                            .Include(x => x.Colaborador)
                            .Include(x => x.Colaborador.Empresa)
                            .Include(x => x.Banco)
                            .Include(x => x.ContaBancariaTipo)
                            .Where(x => alteracaoCadastral.ColaboradorId != 0 ? x.ColaboradorId == alteracaoCadastral.ColaboradorId : x.ColaboradorId == x.ColaboradorId)
                            .Where(x => alteracaoCadastral.SolicitacaoStatusId != 0 ? x.SolicitacaoStatusId == alteracaoCadastral.SolicitacaoStatusId : x.SolicitacaoStatusId == x.SolicitacaoStatusId)
                            .ToList();

            return result;
        }

        public IEnumerable<AlteracaoCadastralModel> GetAlteracaoCadastralbyColaboradorId(int id)
        {
            var result = _db.AlteracaoCadastral
                            .Include(x => x.Colaborador)
                            .Include(x => x.Banco)
                            .Include(x => x.ContaBancariaTipo)
                            .Where(x => x.ColaboradorId == id)
                            .ToList();

            return result;
        }

        public AlteracaoCadastralModel GetAlteracaoCadastralValidation(AlteracaoCadastralModel alteracaoCadastral)
        {
            var result = _db.AlteracaoCadastral
                            .Where(x => alteracaoCadastral.Id != 0 ? x.Id != alteracaoCadastral.Id : x.Id != 0)
                            .Where(x => x.ColaboradorId == alteracaoCadastral.ColaboradorId)
                            .Where(x => x.SolicitacaoStatusId == (int)SolicitacaoStatusEnum.EM_ANALISE)
                            .FirstOrDefault();

            return result;
        }
    }
}