using System.Linq;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class CategoriaSalarialRepository : ICategoriaSalarialRepository<CategoriaSalarialModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public CategoriaSalarialRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public CategoriaSalarialModel GetCategoriaSalarialbyId(int id)
        {
            var result = _db.CategoriaSalarial
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<CategoriaSalarialModel> GetCategoriaSalarial(CategoriaSalarialModel categoriaSalarial)
        {
            var result = _db.CategoriaSalarial
                            .Where(x => !string.IsNullOrEmpty(categoriaSalarial.Nome) ? x.Nome.Contains(categoriaSalarial.Nome) : x.Nome != string.Empty)
                            .ToList();

            return result;
        }

        public CategoriaSalarialModel GetCategoriaSalarialValidation(CategoriaSalarialModel categoriaSalarial)
        {
            var result = _db.CategoriaSalarial
                            .Where(x => categoriaSalarial.Id != 0 ? x.Id != categoriaSalarial.Id : x.Id != 0)
                            .Where(x => x.Nome == categoriaSalarial.Nome)
                            .FirstOrDefault();

            return result;
        }
    }
}