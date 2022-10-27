using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class CargoPlanoUnidadeRepository : ICargoPlanoUnidadeRepository<CargoPlanoUnidadeModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public CargoPlanoUnidadeRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public CargoPlanoUnidadeModel GetCargoPlanoUnidadeById(int cargoPlanoId, int cargoUnidadeId)
        {
            var result = _db.CargoPlanoUnidade
                            .Where(x => x.CargoPlanoId == cargoPlanoId)
                            .Where(x => x.CargoUnidadeId == cargoUnidadeId)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<CargoPlanoUnidadeModel> GetCargoPlanoUnidade(CargoPlanoUnidadeModel cargoPlanoUnidade)
        {
            var result = _db.CargoPlanoUnidade
                            .Where(x => cargoPlanoUnidade.CargoPlanoId != 0 ? x.CargoPlanoId == cargoPlanoUnidade.CargoPlanoId : x.CargoPlanoId != 0 || x.CargoPlanoId == 0)
                            .Where(x => cargoPlanoUnidade.CargoUnidadeId != 0 ? x.CargoUnidadeId == cargoPlanoUnidade.CargoUnidadeId : x.CargoUnidadeId != 0)
                            .ToList();

            return result;
        }

        public IEnumerable<CargoPlanoUnidadeModel> GetCargoPlanoUnidadeByCargoPlanoId(int cargoPlanoId)
        {
            var result = _db.CargoPlanoUnidade
                            .Where(x => x.CargoPlanoId == cargoPlanoId)
                            .ToList();

            return result;
        }
        public IEnumerable<CargoPlanoUnidadeModel> GetCargoUnidadeByEmpresaId(int empresaId)
        {
            var result = _db.CargoPlanoUnidade
                            .Include(x => x.CargoUnidade)
                            .Where(x => x.CargoPlano.EmpresaId == empresaId)
                            .ToList();

            return result;
        }

        public CargoPlanoUnidadeModel GetCargoPlanoUnidadeValidation(CargoPlanoUnidadeModel cargoPlanoUnidade)
        {
            var result = _db.CargoPlanoUnidade
                            .Where(x => x.CargoPlanoId == cargoPlanoUnidade.CargoPlanoId)
                            .Where(x => x.CargoUnidadeId == cargoPlanoUnidade.CargoUnidadeId)
                            .FirstOrDefault();

            return result;
        }
    }
}