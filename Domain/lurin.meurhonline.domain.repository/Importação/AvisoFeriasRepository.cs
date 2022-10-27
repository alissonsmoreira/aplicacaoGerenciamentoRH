using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class AvisoFeriasRepository : IAvisoFeriasRepository<AvisoFeriasModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public AvisoFeriasRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public AvisoFeriasModel GetAvisoFeriasById(int id)
        {
            var result = _db.AvisoFerias
                            .Where(x => x.Id == id)
                            .Include(x => x.Colaborador)
                            .Include(x => x.Empresa)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<AvisoFeriasModel> GetAvisoFeriasByColaboradorIdAno(int colaboradorId, string ano)
        {
            var result = _db.AvisoFerias
                            .Where(x => x.ColaboradorId == colaboradorId && x.Ano == ano)
                            .Include(x => x.Empresa)
                            .OrderByDescending(x => x.DataCadastro)
                            .ToList();

            return result;
        }
    }
}