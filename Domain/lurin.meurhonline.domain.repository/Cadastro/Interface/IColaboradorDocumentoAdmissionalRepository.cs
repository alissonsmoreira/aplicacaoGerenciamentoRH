using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IColaboradorDocumentoAdmissionalRepository<T> : IRepositoryCustom<T>
    {
        T GetColaboradorDocumentoAdmissionalbyId(int id);
        T GetColaboradorDocumentoAdmissionalEditarById(int id);
        IEnumerable<T> GetColaboradorDocumentoAdmissional(T colaboradorDocumentoAdmissional);
        IEnumerable<T> GetColaboradorPreAdmissaoDocumentoAdmissional(T colaboradorDocumentoAdmissional);        
        T GetColaboradorValidation(T colaboradorDocumentoAdmissional);
    }
}