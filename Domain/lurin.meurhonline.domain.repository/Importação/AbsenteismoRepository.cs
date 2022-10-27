using System.Linq;
using System.Collections.Generic;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using System.Data.Entity;

namespace lurin.meurhonline.domain.repository
{
    public class AbsenteismoRepository : IAbsenteismoRepository<AbsenteismoModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public AbsenteismoRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public AbsenteismoModel GetAbsenteismoByColaboradorIdAnoMes(int colaboradorId, string ano, string mes)
        {
            var result = _db.Absenteismo
                            .Where(x => x.ColaboradorId == colaboradorId)
                            .Where(x => x.Ano == ano)
                            .Where(x => x.Mes == mes)
                            .Include(x => x.Colaborador)
                            .OrderByDescending(x => x.Ano)
                            .OrderByDescending(x => x.Mes)
                            .FirstOrDefault();

            return result;
        }

        public List<AbsenteismoModel> GetAbsenteismoByAnoMes(string ano, string mes)
        {
            var result = _db.Absenteismo
                            .Where(x => x.Ano == ano)
                            .Where(x => x.Mes == mes)
                            .Include(x => x.Colaborador)
                            .OrderByDescending(x => x.Ano)
                            .OrderByDescending(x => x.Mes)
                            .ToList();

            return result;
        }

        public List<AbsenteismoModel> GetAbsenteismoByColaboradorId(int colaboradorId)
        {
            var result = _db.Absenteismo
                            .Where(x => x.ColaboradorId == colaboradorId)
                            .Include(x => x.Colaborador)
                            .OrderByDescending(x => x.Ano)
                            .OrderByDescending(x => x.Mes)
                            .ToList();

            return result;
        }

    }
}