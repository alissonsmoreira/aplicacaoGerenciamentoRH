using System.Collections.Generic;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IDocumentoAdmissionalRepository<T> : IRepositoryCustom<T>
    {
        T GetDocumentoAdmissionalbyId(int id);
        IEnumerable<T> GetDocumentoAdmissional(T DocumentoAdmissional);
        T GetDocumentoAdmissionalValidation(T DocumentoAdmissional);
        IEnumerable<T> GetDocumentoAdmissionalPadrao();
    }
}