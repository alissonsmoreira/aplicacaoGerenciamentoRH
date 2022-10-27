using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class OperadoraVTRepository : IOperadoraVTRepository<OperadoraVTModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public OperadoraVTRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public OperadoraVTModel GetOperadoraVTbyId(int id)
        {
            var result = _db.OperadoraVT
                            .Include(x => x.OperadoraVTBandeiraCartao)
                            .Include(x => x.OperadoraVTTarifaTipo)
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<OperadoraVTModel> GetOperadoraVT(OperadoraVTModel operadoraVT)
        {
            var result = _db.OperadoraVT
                            .Include(x => x.OperadoraVTBandeiraCartao)
                            .Include(x => x.OperadoraVTTarifaTipo)
                            .Where(x => !string.IsNullOrEmpty(operadoraVT.Nome) ? x.Nome.Contains(operadoraVT.Nome) : x.Nome != string.Empty)
                            .Where(x => operadoraVT.OperadoraVTBandeiraCartaoId != 0 ? x.OperadoraVTBandeiraCartaoId == operadoraVT.OperadoraVTBandeiraCartaoId : x.OperadoraVTBandeiraCartaoId != 0 || x.OperadoraVTBandeiraCartaoId == 0)
                            .Where(x => operadoraVT.OperadoraVTTarifaTipoId != 0 ? x.OperadoraVTTarifaTipoId == operadoraVT.OperadoraVTTarifaTipoId : x.OperadoraVTTarifaTipoId != 0)
                            .ToList();

            return result;
        }

        public IEnumerable<OperadoraVTModel> GetOperadoraVTByNome(string nomeOperadoraVT)
        {
            var result = _db.OperadoraVT                            
                            .Where(x => x.Nome.StartsWith(nomeOperadoraVT))
                            .ToList();            

            return result;
        }
        
        public OperadoraVTModel GetOperadoraVTValidation(OperadoraVTModel operadoraVT)
        {
            var result = _db.OperadoraVT
                            .Where(x => operadoraVT.Id != 0 ? x.Id != operadoraVT.Id : x.Id != 0)
                            .Where(x => x.Nome == operadoraVT.Nome)
                            .Where(x => x.OperadoraVTBandeiraCartaoId == operadoraVT.OperadoraVTBandeiraCartaoId)
                            .Where(x => x.OperadoraVTTarifaTipoId == operadoraVT.OperadoraVTTarifaTipoId)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<OperadoraVTModel> GetAllOperadoraVT()
        {
            var result = _db.OperadoraVT
                            .Include(x => x.OperadoraVTBandeiraCartao)
                            .Include(x => x.OperadoraVTTarifaTipo)
                            .ToList();

            return result;
        }
    }
}