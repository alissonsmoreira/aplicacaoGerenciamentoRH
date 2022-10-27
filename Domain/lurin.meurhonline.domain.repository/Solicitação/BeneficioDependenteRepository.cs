using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.domain.model.enumerator;

namespace lurin.meurhonline.domain.repository
{
    public class BeneficioDependenteRepository : IBeneficioDependenteRepository<BeneficioDependenteModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public BeneficioDependenteRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public BeneficioDependenteModel GetBeneficioDependentebyId(int id)
        {
            var result = _db.BeneficioDependente
                            .Include(x => x.Dependente)
                            .Include(x => x.Beneficio)
                            .Include(x => x.Beneficio.BeneficioTipo)
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<BeneficioDependenteModel> GetBeneficioDependente(BeneficioDependenteModel beneficioDependente)
        {
            var result = _db.BeneficioDependente
                            .Include(x => x.Dependente)
                            .Include(x => x.Beneficio)
                            .Include(x => x.Beneficio.BeneficioTipo)
                            .Where(x => beneficioDependente.DependenteId != 0 ? x.DependenteId == beneficioDependente.DependenteId : x.DependenteId == x.DependenteId)
                            .Where(x => beneficioDependente.SolicitacaoStatusId != 0 ? x.SolicitacaoStatusId == beneficioDependente.SolicitacaoStatusId : x.SolicitacaoStatusId == x.SolicitacaoStatusId)
                            .ToList();

            return result;
        }

        public IEnumerable<BeneficioDependenteModel> GetBeneficioDependentebyDependenteId(int id)
        {
            var result = _db.BeneficioDependente
                            .Include(x => x.Dependente)
                            .Include(x => x.Beneficio)
                            .Include(x => x.Beneficio.BeneficioTipo)
                            .Where(x => x.DependenteId == id)
                            .ToList();

            return result;
        }

        public BeneficioDependenteModel GetBeneficioDependentebyBeneficioId(int dependenteId, int beneficioId)
        {
            var result = _db.BeneficioDependente
                            .Include(x => x.Dependente)
                            .Include(x => x.Beneficio)
                            .Include(x => x.Beneficio.BeneficioTipo)
                            .Where(x => x.DependenteId == dependenteId)
                            .Where(x => x.BeneficioId == beneficioId)
                            .FirstOrDefault();

            return result;
        }

        public BeneficioDependenteModel GetBeneficioDependenteValidation(BeneficioDependenteModel beneficioDependente)
        {
            var result = _db.BeneficioDependente
                            .Where(x => beneficioDependente.Id != 0 ? x.Id != beneficioDependente.Id : x.Id != 0)
                            .Where(x => x.DependenteId == beneficioDependente.DependenteId)
                            .Where(x => x.BeneficioId == beneficioDependente.BeneficioId)
                            //.Where(x => x.SolicitacaoStatusId == (int)SolicitacaoStatusEnum.EM_ANALISE)
                            .FirstOrDefault();

            return result;
        }
    }
}