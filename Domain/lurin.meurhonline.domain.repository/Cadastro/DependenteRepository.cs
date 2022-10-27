using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class DependenteRepository : IDependenteRepository<DependenteModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public DependenteRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public DependenteModel GetDependentebyId(int id)
        {
            var result = _db.Dependente
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<DependenteModel> GetDependentebyIds(IEnumerable<int> ids)
        {
            var result = _db.Dependente
                            .Where(x => ids.Contains(x.Id))
                            .ToList();

            return result;
        }

        public IEnumerable<DependenteModel> GetDependente(DependenteModel dependente)
        {
            var result = _db.Dependente
                            .Where(x => !string.IsNullOrEmpty(dependente.Nome) ? x.Nome.Contains(dependente.Nome) : x.Nome != string.Empty)
                            .Where(x => !string.IsNullOrEmpty(dependente.CPF) ? x.CPF.Contains(dependente.CPF) : x.CPF != string.Empty)
                            .Where(x => !string.IsNullOrEmpty(dependente.Sexo) ? x.Sexo.Contains(dependente.Sexo) : x.Sexo != string.Empty)
                            .Where(x => dependente.DataNascimento != System.DateTime.MinValue ? x.DataNascimento == dependente.DataNascimento : x.DataNascimento != System.DateTime.MinValue)
                            .Where(x => !string.IsNullOrEmpty(dependente.NomeMae) ? x.NomeMae.Contains(dependente.NomeMae) : x.NomeMae != string.Empty)
                            .Where(x => !string.IsNullOrEmpty(dependente.GrauDependencia) ? x.GrauDependencia.Contains(dependente.GrauDependencia) : x.GrauDependencia != string.Empty)
                            .Where(x => dependente.ColaboradorId != 0 ? x.ColaboradorId == dependente.ColaboradorId : x.ColaboradorId != 0 || x.ColaboradorId == 0)
                            .ToList();

            return result;
        }

        public DependenteModel GetDependenteValidation(DependenteModel dependente)
        {
            var result = _db.Dependente
                            .Where(x => dependente.Id != 0 ? x.Id != dependente.Id : x.Id != 0)
                            .Where(x => x.ColaboradorId == dependente.ColaboradorId)
                            .Where(x => x.CPF == dependente.CPF)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<DependenteModel> GetDependentebyColaboradorId(int id)
        {
            var result = _db.Dependente
                            .Where(x => x.ColaboradorId == id)
                            .ToList();

            return result;
        }
    }
}