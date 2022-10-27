using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.domain.model.enumerator;

namespace lurin.meurhonline.domain.repository
{
    public class ColaboradorDocumentoAdmissionalRepository : IColaboradorDocumentoAdmissionalRepository<ColaboradorDocumentoAdmissionalModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public ColaboradorDocumentoAdmissionalRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public ColaboradorDocumentoAdmissionalModel GetColaboradorDocumentoAdmissionalbyId(int id)
        {
            var result = _db.ColaboradorDocumentoAdmissional
                            .Include(x => x.Colaborador.Empresa)
                            .Include(x => x.DocumentoAdmissional)
                            .Where(x => x.Id == id)
                            .Where(x => x.Colaborador.ColaboradorStatusId != (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .FirstOrDefault();

            return result;
        }

        public ColaboradorDocumentoAdmissionalModel GetColaboradorDocumentoAdmissionalPreAdmissaobyId(int id)
        {
            var result = _db.ColaboradorDocumentoAdmissional
                            .Include(x => x.Colaborador.Empresa)
                            .Include(x => x.DocumentoAdmissional)
                            .Where(x => x.Id == id)
                            .Where(x => x.Colaborador.ColaboradorStatusId == (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .FirstOrDefault();

            return result;
        }

        public ColaboradorDocumentoAdmissionalModel GetColaboradorDocumentoAdmissionalEditarById(int id)
        {
            var result = _db.ColaboradorDocumentoAdmissional
                            .Include(x => x.Colaborador.Empresa)
                            .Include(x => x.DocumentoAdmissional)
                            .Where(x => x.Id == id)                            
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<ColaboradorDocumentoAdmissionalModel> GetColaboradorDocumentoAdmissional(ColaboradorDocumentoAdmissionalModel colaboradorDocumentoAdmissional)
        {
            var result = _db.ColaboradorDocumentoAdmissional
                            .Include(x => x.Colaborador.Empresa)
                            .Include(x => x.DocumentoAdmissional)
                            .Where(x => x.Colaborador.ColaboradorStatusId != (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .Where(x => colaboradorDocumentoAdmissional.ColaboradorId != 0 ? x.ColaboradorId == colaboradorDocumentoAdmissional.ColaboradorId : x.ColaboradorId != 0)
                            .Where(x => colaboradorDocumentoAdmissional.DocumentoAdmissionalId != 0 ? x.DocumentoAdmissionalId == colaboradorDocumentoAdmissional.DocumentoAdmissionalId : x.DocumentoAdmissionalId != 0)
                            .ToList();

            return result;
        }

        public IEnumerable<ColaboradorDocumentoAdmissionalModel> GetColaboradorPreAdmissaoDocumentoAdmissional(ColaboradorDocumentoAdmissionalModel colaboradorDocumentoAdmissional)
        {
            var result = _db.ColaboradorDocumentoAdmissional
                            .Include(x => x.Colaborador.Empresa)
                            .Include(x => x.DocumentoAdmissional)
                            .Where(x => x.Colaborador.ColaboradorStatusId == (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .Where(x => colaboradorDocumentoAdmissional.ColaboradorId != 0 ? x.ColaboradorId == colaboradorDocumentoAdmissional.ColaboradorId : x.ColaboradorId != 0)
                            .Where(x => colaboradorDocumentoAdmissional.DocumentoAdmissionalId != 0 ? x.DocumentoAdmissionalId == colaboradorDocumentoAdmissional.DocumentoAdmissionalId : x.DocumentoAdmissionalId != 0)
                            .ToList();

            return result;
        }

        public ColaboradorDocumentoAdmissionalModel GetColaboradorValidation(ColaboradorDocumentoAdmissionalModel colaboradorDocumentoAdmissional)
        {
            var result = _db.ColaboradorDocumentoAdmissional
                            .Where(x => x.ColaboradorId == colaboradorDocumentoAdmissional.ColaboradorId)
                            .Where(x => x.DocumentoAdmissionalId == colaboradorDocumentoAdmissional.DocumentoAdmissionalId)
                            .FirstOrDefault();

            return result;

        }

        public ColaboradorDocumentoAdmissionalModel GetColaboradorCarteiraHabilitacao(int colaboradorId)
        {
            var result = _db.ColaboradorDocumentoAdmissional
                            .Where(x => x.ColaboradorId == colaboradorId)
                            .Where(x => x.DocumentoAdmissional.Nome == "Carteira de Habilitação")
                            .FirstOrDefault();

            return result;

        }

        public ColaboradorDocumentoAdmissionalModel GetColaboradorComprovanteResidencia(int colaboradorId)
        {
            var result = _db.ColaboradorDocumentoAdmissional
                            .Where(x => x.ColaboradorId == colaboradorId)
                            .Where(x => x.DocumentoAdmissional.Nome == "Comprovante de Residência")
                            .FirstOrDefault();

            return result;

        }
    }
}