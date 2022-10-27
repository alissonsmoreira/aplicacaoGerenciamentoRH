using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class EquipeGestorRepository : IEquipeGestorRepository<EquipeGestorModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public EquipeGestorRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public EquipeGestorModel GetEquipeGestorbyId(int id)
        {
            var result = _db.EquipeGestor
                            .Include(x => x.Colaborador)
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<EquipeGestorModel> GetEquipeGestor(EquipeGestorModel equipeGestor)
        {
            var result = _db.EquipeGestor
                            .Include(x => x.Colaborador)
                            .Where(x => equipeGestor.ColaboradorId != 0 ? x.ColaboradorId == equipeGestor.ColaboradorId : x.ColaboradorId != 0 || x.ColaboradorId == 0)
                            .Where(x => equipeGestor.LotacaoUnidadeInicialId != 0 ? x.LotacaoUnidadeInicialId == equipeGestor.LotacaoUnidadeInicialId : x.LotacaoUnidadeInicialId != 0 || x.LotacaoUnidadeInicialId == 0)
                            .Where(x => equipeGestor.LotacaoUnidadeFinalId != 0 ? x.LotacaoUnidadeFinalId == equipeGestor.LotacaoUnidadeFinalId : x.LotacaoUnidadeFinalId != 0 || x.LotacaoUnidadeFinalId == 0)
                            .ToList();

            return result;
        }

        public IEnumerable<EquipeGestorModel> GetEquipeGestorByGestorId(int id)
        {
            var result = _db.EquipeGestor
                            .Include(x => x.Colaborador)
                            .Where(x => x.ColaboradorId == id)
                            .ToList();

            return result;
        }

        public EquipeGestorModel GetEquipeGestorValidation(EquipeGestorModel equipeGestor)
        {
            var result = _db.EquipeGestor
                            .Where(x => x.ColaboradorId == equipeGestor.ColaboradorId)
                            .Where(x => x.LotacaoUnidadeInicialId == equipeGestor.LotacaoUnidadeInicialId)
                            .Where(x => x.LotacaoUnidadeFinalId == equipeGestor.LotacaoUnidadeFinalId)
                            .FirstOrDefault();

            return result;
        }

    }
}