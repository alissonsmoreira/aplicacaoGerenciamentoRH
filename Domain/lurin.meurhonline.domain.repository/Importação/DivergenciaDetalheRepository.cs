using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using System;

namespace lurin.meurhonline.domain.repository
{
    public class DivergenciaDetalheRepository : IDivergenciaDetalheRepository<DivergenciaDetalheModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public DivergenciaDetalheRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public DivergenciaDetalheModel GetDivergenciaDetalheById(int id)
        {
            var result = _db.DivergenciaDetalhe
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<DivergenciaDetalheModel> GetDivergenciaDetalheByColaboradorIdData(int colaboradorId, DateTime inicio, DateTime fim)
        {
            var result = _db.DivergenciaDetalhe
                            .Where(x => x.DivergenciaId == colaboradorId)
                            .Where(x => x.Dia >= inicio && x.Dia <= fim)
                            .Where(x => x.Divergencia.ColaboradorId == colaboradorId)
                            .ToList();

            return result;
        }
    }
}