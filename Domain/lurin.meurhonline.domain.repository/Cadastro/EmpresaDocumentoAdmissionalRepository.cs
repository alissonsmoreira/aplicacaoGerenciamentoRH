using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class EmpresaDocumentoAdmissionalRepository : IEmpresaDocumentoAdmissionalRepository<EmpresaDocumentoAdmissionalModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public EmpresaDocumentoAdmissionalRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public EmpresaDocumentoAdmissionalModel GetEmpresaDocumentoAdmissionalById(int empresaId, int documentoAdmissionalId)
        {
            var result = _db.EmpresaDocumentoAdmissional
                            .Where(x => x.EmpresaId == empresaId)
                            .Where(x => x.DocumentoAdmissionalId == documentoAdmissionalId)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<EmpresaDocumentoAdmissionalModel> GetEmpresaDocumentoAdmissional(EmpresaDocumentoAdmissionalModel empresaDocumentoAdmissional)
        {
            var result = _db.EmpresaDocumentoAdmissional
                            .Where(x => empresaDocumentoAdmissional.EmpresaId != 0 ? x.EmpresaId == empresaDocumentoAdmissional.EmpresaId : x.EmpresaId != 0 || x.EmpresaId == 0)
                            .Where(x => empresaDocumentoAdmissional.DocumentoAdmissionalId != 0 ? x.DocumentoAdmissionalId == empresaDocumentoAdmissional.DocumentoAdmissionalId : x.DocumentoAdmissionalId != 0)
                            .ToList();

            return result;
        }

        public IEnumerable<EmpresaDocumentoAdmissionalModel> GetEmpresaDocumentoAdmissionalByEmpresaId(int empresaId)
        {
            var result = _db.EmpresaDocumentoAdmissional
                            .Where(x => x.EmpresaId == empresaId)
                            .ToList();

            return result;
        }

        public IEnumerable<EmpresaDocumentoAdmissionalModel> GetEmpresaDocumentoAdmissionalNaoPadraoByEmpresaId(int empresaId)
        {
            var result = _db.EmpresaDocumentoAdmissional
                            .Where(x => x.EmpresaId == empresaId)
                            .Where(x => x.DocumentoAdmissional.Nome != "Carteira de Habilitação" && x.DocumentoAdmissional.Nome != "Comprovante de Residência")
                            .ToList();

            return result;
        }
    }
}