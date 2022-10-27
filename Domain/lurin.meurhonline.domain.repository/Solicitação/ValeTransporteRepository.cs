using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.domain.model.enumerator;

namespace lurin.meurhonline.domain.repository
{
    public class ValeTransporteRepository : IValeTransporteRepository<ValeTransporteModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public ValeTransporteRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public ValeTransporteModel GetValeTransportebyId(int id)
        {
            var result = _db.ValeTransporte
                            .Include(x => x.Colaborador)
                            .Include(x => x.ValeTransporteUtilizacao)
                            .Include(x => x.ValeTransporteSituacao)
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<ValeTransporteModel> GetValeTransporte(ValeTransporteModel ValeTransporte)
        {
            var result = _db.ValeTransporte
                            .Include(x => x.Colaborador)
                            .Include(x => x.ValeTransporteUtilizacao)
                            .Include(x => x.ValeTransporteSituacao)
                            .Where(x => ValeTransporte.ColaboradorId != 0 ? x.ColaboradorId == ValeTransporte.ColaboradorId : x.ColaboradorId == x.ColaboradorId)
                            .Where(x => ValeTransporte.SolicitacaoStatusId != 0 ? x.SolicitacaoStatusId == ValeTransporte.SolicitacaoStatusId : x.SolicitacaoStatusId == x.SolicitacaoStatusId)
                            .ToList();

            return result;
        }

        public IEnumerable<ValeTransporteModel> GetValeTransportebyColaboradorId(int id)
        {
            var result = _db.ValeTransporte
                            .Include(x => x.Colaborador)
                            .Include(x => x.ValeTransporteUtilizacao)
                            .Include(x => x.ValeTransporteSituacao)
                            .Where(x => x.ColaboradorId == id)
                            .ToList();

            return result;
        }

        public ValeTransporteModel GetValeTransporteValidation(ValeTransporteModel ValeTransporte)
        {
            var result = _db.ValeTransporte
                            .Where(x => ValeTransporte.Id != 0 ? x.Id != ValeTransporte.Id : x.Id != 0)
                            .Where(x => x.ColaboradorId == ValeTransporte.ColaboradorId)
                            .Where(x => x.SolicitacaoStatusId == (int)SolicitacaoStatusEnum.EM_ANALISE)
                            .FirstOrDefault();

            return result;
        }
    }
}