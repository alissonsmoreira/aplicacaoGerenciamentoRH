using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IEmpresaDocumentoAdmissionalRepository<T> : IRepositoryCustom<T>
    {
        T GetEmpresaDocumentoAdmissionalById(int empresaId, int documentoAdmissionalId);
        IEnumerable<T> GetEmpresaDocumentoAdmissional(T empresaDocumentoAdmissional);
        IEnumerable<T> GetEmpresaDocumentoAdmissionalByEmpresaId(int empresaId);
    }
}