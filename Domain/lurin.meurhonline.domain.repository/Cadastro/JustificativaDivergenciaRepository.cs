using System.Linq;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class JustificativaDivergenciaRepository : IJustificativaDivergenciaRepository<JustificativaDivergenciaModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public JustificativaDivergenciaRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public JustificativaDivergenciaModel GetJustificativaDivergenciabyId(int id)
        {
            var result = _db.JustificativaDivergencia
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<JustificativaDivergenciaModel> GetTodasJustificativasDivergencia()
        {
            var result = _db.JustificativaDivergencia
                            .ToList();

            return result;
        }


        public IEnumerable<JustificativaDivergenciaModel> GetJustificativaDivergencia(JustificativaDivergenciaModel justificativaDivergencia)
        {
            var result = _db.JustificativaDivergencia
                            .Where(x => !string.IsNullOrEmpty(justificativaDivergencia.Tipo) ? x.Tipo.Contains(justificativaDivergencia.Tipo) : x.Tipo != string.Empty)
                            .ToList();

            return result;
        }

        public JustificativaDivergenciaModel GetJustificativaDivergenciaValidation(JustificativaDivergenciaModel justificativaDivergencia)
        {
            var result = _db.JustificativaDivergencia
                            .Where(x => justificativaDivergencia.Id != 0 ? x.Id != justificativaDivergencia.Id : x.Id != 0)
                            .Where(x => x.Tipo == justificativaDivergencia.Tipo)
                            .FirstOrDefault();

            return result;
        }
    }
}