using System.Linq;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class MotivoHoraExtraRepository : IMotivoHoraExtraRepository<MotivoHoraExtraModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public MotivoHoraExtraRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public MotivoHoraExtraModel GetMotivoHoraExtrabyId(int id)
        {
            var result = _db.MotivoHoraExtra
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<MotivoHoraExtraModel> GetMotivoHoraExtra(MotivoHoraExtraModel motivoHoraExtra)
        {
            var result = _db.MotivoHoraExtra
                            .Where(x => !string.IsNullOrEmpty(motivoHoraExtra.Motivo) ? x.Motivo.Contains(motivoHoraExtra.Motivo) : x.Motivo != string.Empty)
                            .ToList();

            return result;
        }

        public MotivoHoraExtraModel GetMotivoHoraExtraValidation(MotivoHoraExtraModel motivoHoraExtra)
        {
            var result = _db.MotivoHoraExtra
                            .Where(x => motivoHoraExtra.Id != 0 ? x.Id != motivoHoraExtra.Id : x.Id != 0)
                            .Where(x => x.Motivo == motivoHoraExtra.Motivo)
                            .FirstOrDefault();

            return result;
        }
    }
}