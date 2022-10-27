using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class CargoPlanoRepository : ICargoPlanoRepository<CargoPlanoModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public CargoPlanoRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public CargoPlanoModel GetCargoPlanobyId(int id)
        {
            var result = _db.CargoPlano
                            .Where(x => x.Id == id)
                            .Include(x => x.Empresa)
                            .Include(x => x.CargoPlanosUnidades.Select(u => u.CargoUnidade))
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<CargoPlanoModel> GetCargoPlano(CargoPlanoModel cargoPlano)
        {
            var result = _db.CargoPlano
                            .Where(x => cargoPlano.Codigo != 0 ? x.Codigo == cargoPlano.Codigo : x.Codigo != 0 || x.Codigo == 0)
                            .Where(x => !string.IsNullOrEmpty(cargoPlano.Nome) ? x.Nome.Contains(cargoPlano.Nome) : x.Nome != string.Empty)
                            .Where(x => cargoPlano.EmpresaId != 0 ? x.EmpresaId == cargoPlano.EmpresaId : x.EmpresaId != 0 || x.EmpresaId == 0)
                            .Include(x => x.Empresa)
                            .Include(x => x.CargoPlanosUnidades.Select(u => u.CargoUnidade))
                            .ToList();

            return result;
        }

        public CargoPlanoModel GetCargoPlanoValidation(CargoPlanoModel cargoPlano)
        {
            var result = _db.CargoPlano
                            .Where(x => cargoPlano.Id != 0 ? x.Id != cargoPlano.Id : x.Id != 0)
                            .Where(x => x.EmpresaId == cargoPlano.EmpresaId)
                            //.Where(x => x.Codigo == cargoPlano.Codigo)
                            //.Where(x => x.Nome == cargoPlano.Nome)
                            .FirstOrDefault();

            return result;
        }

    }
}