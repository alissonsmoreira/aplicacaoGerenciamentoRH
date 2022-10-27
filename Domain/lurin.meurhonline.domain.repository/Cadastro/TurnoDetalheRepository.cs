using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class TurnoDetalheRepository : ITurnoDetalheRepository<TurnoDetalheModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public TurnoDetalheRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public TurnoDetalheModel GetTurnoDetalhebyId(int id)
        {
            var result = _db.TurnoDetalhe
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<TurnoDetalheModel> GetTurnoDetalhe(TurnoDetalheModel turnoDetalhe)
        {
            var result = _db.TurnoDetalhe
                            .Where(x => !string.IsNullOrEmpty(turnoDetalhe.DiaSemana) ? x.DiaSemana.Contains(turnoDetalhe.DiaSemana) : x.DiaSemana != string.Empty)
                            .Where(x => !string.IsNullOrEmpty(turnoDetalhe.HorarioInicial) ? x.HorarioInicial.Contains(turnoDetalhe.HorarioInicial) : x.HorarioInicial != string.Empty)
                            .Where(x => !string.IsNullOrEmpty(turnoDetalhe.HorarioFinal) ? x.HorarioFinal.Contains(turnoDetalhe.HorarioFinal) : x.HorarioFinal != string.Empty)
                            .ToList();

            return result;
        }

        public TurnoDetalheModel GetTurnoDetalheValidation(TurnoDetalheModel turnoDetalhe)
        {
            var result = _db.TurnoDetalhe
                            .Where(x => turnoDetalhe.Id != 0 ? x.Id != turnoDetalhe.Id : x.Id != 0)
                            .Where(x => x.TurnoId == turnoDetalhe.TurnoId)
                            .Where(x => x.DiaSemana == turnoDetalhe.DiaSemana)
                            .FirstOrDefault();

            return result;

        }
    }
}