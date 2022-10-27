using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.domain.model.enumerator;

namespace lurin.meurhonline.domain.repository
{
    public class BeneficioColaboradorRepository : IBeneficioColaboradorRepository<BeneficioColaboradorModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public BeneficioColaboradorRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public BeneficioColaboradorModel GetBeneficioColaboradorbyId(int id)
        {
            var result = _db.BeneficioColaborador
                            .Include(x => x.Colaborador)
                            .Include(x => x.Beneficio)
                            .Include(x => x.Beneficio.BeneficioTipo)
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<BeneficioColaboradorModel> GetBeneficioColaborador(BeneficioColaboradorModel BeneficioColaborador)
        {
            var result = _db.BeneficioColaborador
                            .Include(x => x.Colaborador)
                            .Include(x => x.Beneficio)
                            .Include(x => x.Beneficio.BeneficioTipo)
                            .Where(x => BeneficioColaborador.ColaboradorId != 0 ? x.ColaboradorId == BeneficioColaborador.ColaboradorId : x.ColaboradorId == x.ColaboradorId)
                            .Where(x => BeneficioColaborador.SolicitacaoStatusId != 0 ? x.SolicitacaoStatusId == BeneficioColaborador.SolicitacaoStatusId : x.SolicitacaoStatusId == x.SolicitacaoStatusId)
                            .ToList();

            return result;
        }

        public IEnumerable<BeneficioColaboradorModel> GetBeneficioColaboradorbyColaboradorId(int id)
        {
            var result = _db.BeneficioColaborador
                            .Include(x => x.Colaborador)
                            .Include(x => x.Beneficio)
                            .Include(x => x.Beneficio.BeneficioTipo)
                            .Where(x => x.ColaboradorId == id)
                            .ToList();

            return result;
        }

        public BeneficioColaboradorModel GetBeneficioColaboradorbyBeneficioId(int colaboradorId, int beneficioId)
        {
            var result = _db.BeneficioColaborador
                            .Include(x => x.Colaborador)
                            .Include(x => x.Beneficio)
                            .Include(x => x.Beneficio.BeneficioTipo)
                            .Where(x => x.ColaboradorId == colaboradorId)
                            .Where(x => x.BeneficioId == beneficioId)
                            .FirstOrDefault();

            return result;
        }

        public BeneficioColaboradorModel GetBeneficioColaboradorValidation(BeneficioColaboradorModel beneficioColaborador)
        {
            var result = _db.BeneficioColaborador
                            .Where(x => beneficioColaborador.Id != 0 ? x.Id != beneficioColaborador.Id : x.Id != 0)
                            .Where(x => x.ColaboradorId == beneficioColaborador.ColaboradorId)
                            .Where(x => x.BeneficioId == beneficioColaborador.BeneficioId)
                            //.Where(x => x.SolicitacaoStatusId == (int)SolicitacaoStatusEnum.EM_ANALISE)
                            .FirstOrDefault();

            return result;
        }
    }
}