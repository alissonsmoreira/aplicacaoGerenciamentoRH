using System.Linq;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class DocumentoAdmissionalRepository : IDocumentoAdmissionalRepository<DocumentoAdmissionalModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public DocumentoAdmissionalRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public DocumentoAdmissionalModel GetDocumentoAdmissionalbyId(int id)
        {
            var result = _db.DocumentoAdmissional
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<DocumentoAdmissionalModel> GetDocumentoAdmissional(DocumentoAdmissionalModel documentoAdmissional)
        {
            var result = _db.DocumentoAdmissional
                            .Where(x => !string.IsNullOrEmpty(documentoAdmissional.Nome) ? x.Nome.Contains(documentoAdmissional.Nome) : x.Nome != string.Empty)
                            .ToList();

            return result;
        }

        public DocumentoAdmissionalModel GetDocumentoAdmissionalValidation(DocumentoAdmissionalModel documentAdmissional)
        {
            var result = _db.DocumentoAdmissional
                            .Where(x => documentAdmissional.Id != 0 ? x.Id != documentAdmissional.Id : x.Id != 0)
                            .Where(x => x.Nome == documentAdmissional.Nome)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<DocumentoAdmissionalModel> GetDocumentoAdmissionalPadrao()
        {
            var result = _db.DocumentoAdmissional
                            .Where(x => x.Nome == "Carteira de Habilitação" || x.Nome == "Comprovante de Residência")
                            .ToList();

            return result;
        }

        public DocumentoAdmissionalModel GetDocumentoAdmissionalbyName(string nome)
        {
            var result = _db.DocumentoAdmissional
                            .Where(x => x.Nome == nome)
                            .FirstOrDefault();

            return result;
        }
    }
}