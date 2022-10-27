using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class ReciboFeriasRepository : IReciboFeriasRepository<ReciboFeriasModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public ReciboFeriasRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public ReciboFeriasModel GetReciboFeriasById(int id)
        {
            var result = _db.ReciboFerias
                            .Where(x => x.Id == id)
                            .Include(x => x.Colaborador)
                            .Include(x => x.Empresa)
                            .Include(x => x.Vencimentos)
                            .Include(x => x.Descontos)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<ReciboFeriasModel> GetReciboFeriasAnoColaboradorById(string ano, int colaboradorId)
        {
            var result = _db.ReciboFerias
                            .Where(x => x.Ano == ano)
                            .Where(x => x.ColaboradorId == colaboradorId)
                            .Include(x => x.Colaborador)
                            .Include(x => x.Empresa)
                            .Include(x => x.Vencimentos)
                            .Include(x => x.Descontos)
                            .OrderByDescending(x => x.DataCadastro)
                            .ToList();

            return result;
        }
    }
}