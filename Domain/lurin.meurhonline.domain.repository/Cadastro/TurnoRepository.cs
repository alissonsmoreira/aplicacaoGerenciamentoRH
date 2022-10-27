using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class TurnoRepository : ITurnoRepository<TurnoModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public TurnoRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public TurnoModel GetTurnobyId(int id)
        {
            var result = _db.Turno
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<TurnoModel> GetTurno(TurnoModel turno)
        {
            var result = _db.Turno
                            .Where(x => turno.Codigo != 0 ? x.Codigo == turno.Codigo : x.Codigo != 0 || x.Codigo == 0)
                            .Where(x => !string.IsNullOrEmpty(turno.Descricao) ? x.Descricao.Contains(turno.Descricao) : x.Descricao != string.Empty)
                            .ToList();

            return result;
        }

        public TurnoModel GetTurnoValidation(TurnoModel turno)
        {
            var result = _db.Turno
                            .Where(x => turno.Id != 0 ? x.Id != turno.Id : x.Id != 0)
                            .Where(x => x.Codigo == turno.Codigo)
                            .Where(x => x.Descricao == turno.Descricao)
                            .FirstOrDefault();

            return result;
        }

        public TurnoModel GetTurnoDetalhebyTurnoId(int id)
        {
            var result = _db.Turno
                            .Where(x => x.Id == id)
                            .Include(x => x.TurnoDetalhe)
                            .FirstOrDefault();

            return result;
        }
    }
}