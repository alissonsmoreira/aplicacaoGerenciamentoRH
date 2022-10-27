using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class HoleriteRepository : IHoleriteRepository<HoleriteModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public HoleriteRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public HoleriteModel GetHoleriteById(int id)
        {
            var result = _db.Holerite
                            .Where(x => x.Id == id)
                            .Include(x => x.Colaborador)
                            .Include(x => x.Empresa)
                            .Include(x => x.HoleriteEventos)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<HoleriteModel> GetHoleriteByColaboradorIdMesAno(int? colaboradorId, string mes, string ano, int? empresaId)
        {
            List<HoleriteModel> result = new List<HoleriteModel>();

            var preResult  = _db.Holerite
                .Include(x => x.HoleriteEventos)
                .Include(x => x.Colaborador)
                .Include(x => x.Empresa)
                .Where(x => x.Mes == mes && x.Ano == ano);

            if (colaboradorId != 0 && colaboradorId != null)
            {
                preResult = preResult.Where(x => x.ColaboradorId == colaboradorId);
            }

            if (empresaId != 0 && empresaId != null)
            {
                preResult = preResult.Where(x => x.EmpresaId == empresaId);
            }

            result = preResult.OrderByDescending(x => x.DataCadastro).ToList();
            
            return result;
        }
        public bool ExcluirHolerites(List<HoleriteModel> holerites)
        {
            try
            {
                foreach (HoleriteModel holerite in holerites)
                {
                    _db.Holerite.Remove(holerite);
                    _db.Commit();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}