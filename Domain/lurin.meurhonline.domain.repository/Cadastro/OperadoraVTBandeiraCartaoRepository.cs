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
    public class OperadoraVTBandeiraCartaoRepository : IOperadoraVTBandeiraCartaoRepository<OperadoraVTBandeiraCartaoModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public OperadoraVTBandeiraCartaoRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public OperadoraVTBandeiraCartaoModel GetOperadoraVTBandeiraCartaobyId(int id)
        {
            var result = _db.OperadoraVTBandeiraCartao
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<OperadoraVTBandeiraCartaoModel> GetOperadoraVTBandeiraCartao(OperadoraVTBandeiraCartaoModel operadoraVTBandeiraCartao)
        {
            var result = _db.OperadoraVTBandeiraCartao
                            .Where(x => !string.IsNullOrEmpty(operadoraVTBandeiraCartao.Nome) ? x.Nome.Contains(operadoraVTBandeiraCartao.Nome) : x.Nome != string.Empty)
                            .ToList();

            return result;
        }


        public OperadoraVTBandeiraCartaoModel GetOperadoraVTBandeiraCartaoValidation(OperadoraVTBandeiraCartaoModel operadoraVTBandeiraCartao)
        {
            var result = _db.OperadoraVTBandeiraCartao
                            .Where(x => operadoraVTBandeiraCartao.Id != 0 ? x.Id != operadoraVTBandeiraCartao.Id : x.Id != 0)
                            .Where(x => x.Nome == operadoraVTBandeiraCartao.Nome)
                            .FirstOrDefault();

            return result;
        }

    }
}