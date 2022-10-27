using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class BeneficioRepository : IBeneficioRepository<BeneficioModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public BeneficioRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public BeneficioModel GetBeneficiobyId(int id)
        {
            var result = _db.Beneficio
                            .Include(x => x.BeneficioTipo)
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<BeneficioModel> GetBeneficio(BeneficioModel beneficio)
        {
            var result = _db.Beneficio
                            .Include(x => x.BeneficioTipo)
                            .Where(x => !string.IsNullOrEmpty(beneficio.Nome) ? x.Nome.Contains(beneficio.Nome) : x.Nome != string.Empty)
                            .Where(x => !string.IsNullOrEmpty(beneficio.RegraDesconto) ? x.RegraDesconto.Contains(beneficio.RegraDesconto) : x.RegraDesconto != string.Empty)
                            .Where(x => beneficio.CustoBeneficio != 0 ? x.CustoBeneficio == beneficio.CustoBeneficio : x.CustoBeneficio != 0 || x.CustoBeneficio == 0)
                            .Where(x => beneficio.BeneficioTipoId != 0 ? x.BeneficioTipoId == beneficio.BeneficioTipoId : x.BeneficioTipoId != 0)
                            .ToList();            

            return result;
        }

        public IEnumerable<BeneficioModel> GetAllBeneficio()
        {
            var result = _db.Beneficio
                            .Include(x => x.BeneficioTipo)
                            .ToList();

            return result;
        }

        public BeneficioModel GetBeneficioValidation(BeneficioModel beneficio)
        {
            var result = _db.Beneficio
                            .Where(x => beneficio.Id != 0 ? x.Id != beneficio.Id : x.Id != 0)
                            .Where(x => x.Nome == beneficio.Nome)
                            .FirstOrDefault();

            return result;
        }
    }
}