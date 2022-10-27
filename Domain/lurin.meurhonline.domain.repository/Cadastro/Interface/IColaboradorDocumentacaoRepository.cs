using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IColaboradorDocumentacaoRepository<T> : IRepositoryCustom<T>
    {
        T GetColaboradorDocumentacaobyId(int id);
        T GetColaboradorDocumentacaoEditarById(int id);
        IEnumerable<T> GetColaboradorDocumentacao(T colaboradorDocumentacao);
        IEnumerable<T> GetColaboradorPreAdmissaoDocumentacao(T colaboradorDocumentacao);
        T GetColaboradorDocumentacaoValidation(T colaboradorDocumentacao);
        T GetColaboradorDocumentacaobyColaboradorId(int id);
    }
}