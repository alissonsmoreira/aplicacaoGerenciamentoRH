using System.Linq;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class SindicatoRepository : ISindicatoRepository<SindicatoModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public SindicatoRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public SindicatoModel GetSindicatobyId(int id)
        {
            var result = _db.Sindicato
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<SindicatoModel> GetSindicato(SindicatoModel sindicato)
        {
            var result = _db.Sindicato
                            //Obrigatório
                            .Where(x => !string.IsNullOrEmpty(sindicato.Nome) ? x.Nome.Contains(sindicato.Nome) : x.Nome != string.Empty)
                            .Where(x => !string.IsNullOrEmpty(sindicato.Cnpj) ? x.Cnpj.Contains(sindicato.Cnpj) : x.Cnpj != string.Empty)
                            .Where(x => !string.IsNullOrEmpty(sindicato.DataBaseMes) ? x.DataBaseMes.Contains(sindicato.DataBaseMes) : x.DataBaseMes != string.Empty)
                            .Where(x => !string.IsNullOrEmpty(sindicato.DataBaseAno) ? x.DataBaseAno.Contains(sindicato.DataBaseAno) : x.DataBaseMes != string.Empty)
                            //Opcional
                            .Where(x => !string.IsNullOrEmpty(sindicato.Representante) ? x.Representante.Contains(sindicato.Representante) : x.Representante != string.Empty || x.Representante == string.Empty)
                            .Where(x => !string.IsNullOrEmpty(sindicato.TelefoneComercial) ? x.TelefoneComercial.Contains(sindicato.TelefoneComercial) : x.TelefoneComercial != string.Empty || x.TelefoneComercial == string.Empty)
                            .Where(x => !string.IsNullOrEmpty(sindicato.TelefoneCelular) ? x.TelefoneCelular.Contains(sindicato.TelefoneCelular) : x.TelefoneCelular != string.Empty || x.TelefoneCelular == string.Empty)
                            .ToList();

            return result;
        }
        public SindicatoModel GetSindicatoValidation(SindicatoModel sindicato)
        {
            var result = _db.Sindicato
                            .Where(x => sindicato.Id != 0 ? x.Id != sindicato.Id : x.Id != 0)
                            .Where(x => x.Cnpj == sindicato.Cnpj)
                            .FirstOrDefault();

            return result;
        }
    }
}