using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using System;
using lurin.meurhonline.domain.model.enumerator;

namespace lurin.meurhonline.domain.repository
{
    public class DivergenciaRepository : IDivergenciaRepository<DivergenciaModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public DivergenciaRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public DivergenciaModel GetDivergenciaById(int id)
        {
            var result = _db.Divergencia
                            .Where(x => x.Id == id)
                            .Include(x => x.Detalhes)
                            .Include(x => x.Empresa)
                            .Include(x => x.Colaborador)
                            .Include(x => x.Detalhes.Select(y => y.JustificativaDivergencia))
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<DivergenciaModel> GetDivergenciaByColaboradorIdData(int? colaboradorId, DateTime inicio, DateTime fim)
        {
            var preResult = _db.Divergencia                            
                            .Where(x => x.Detalhes.Any(y => y.SolicitacaoStatusId != (int)SolicitacaoStatusEnum.APROVADO))
                            .Include(x => x.Detalhes)
                            .Include(x => x.Empresa)
                            .Include(x => x.Colaborador);

            if(colaboradorId.HasValue)
            {
                preResult = preResult.Where(x => x.ColaboradorId == colaboradorId);
            }

            var result = preResult.ToList();
                            
            foreach(DivergenciaModel div in result)
            {
                div.Detalhes = div.Detalhes.Where(x => x.Dia >= inicio && x.Dia <= fim).ToList();
            }

            //result = result.Where(x => x.Detalhes.Count > 0).OrderByDescending(x => x.DataCadastro).ToList();
            result = result.OrderByDescending(x => x.DataCadastro).ToList();
            
            return result;
        }
        public IEnumerable<DivergenciaModel> GetDivergenciaByColaboradorId(int? colaboradorId)
        {
            var preResult = _db.Divergencia

                            .Where(x => x.Detalhes.Any(y => !y.JustificativaDivergenciaId.HasValue && y.SolicitacaoStatusId != (int)SolicitacaoStatusEnum.APROVADO))
                            .Where(x => x.Detalhes.Count > 0)
                            .Include(x => x.Detalhes)
                            .Include(x => x.Empresa)
                            .Include(x => x.Colaborador);

                if(colaboradorId.HasValue && colaboradorId.Value != 0)
                {
                        preResult = preResult.Where(x => x.ColaboradorId == colaboradorId);
                }

                List<DivergenciaModel> result = preResult.OrderByDescending(x => x.DataCadastro).ToList();

            return result;
        }
    }
}