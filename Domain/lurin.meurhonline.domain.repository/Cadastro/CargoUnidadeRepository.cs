using System.Linq;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class CargoUnidadeRepository : ICargoUnidadeRepository<CargoUnidadeModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public CargoUnidadeRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public CargoUnidadeModel GetCargoUnidadebyId(int id)
        {
            var result = _db.CargoUnidade
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<CargoUnidadeModel> GetCargoUnidade(CargoUnidadeModel cargoUnidade)
        {
            var result = _db.CargoUnidade
                            .Where(x => cargoUnidade.Codigo != 0 ? x.Codigo == cargoUnidade.Codigo : x.Codigo != 0 || x.Codigo == 0)
                            .Where(x => !string.IsNullOrEmpty(cargoUnidade.Nome) ? x.Nome.Contains(cargoUnidade.Nome) : x.Nome != string.Empty)
                            .ToList();

            return result;
        }
        public CargoUnidadeModel GetCargoUnidadeValidation(CargoUnidadeModel cargoUnidade)
        {
            var result = _db.CargoUnidade
                            .Where(x => cargoUnidade.Id != 0 ? x.Id != cargoUnidade.Id : x.Id != 0)
                            .Where(x => x.Codigo == cargoUnidade.Codigo)
                            .Where(x => x.Nome == cargoUnidade.Nome)
                            .FirstOrDefault();

            return result;
        }
    }
}