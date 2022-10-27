using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IColaboradorEstrangeiroRepository<T> : IRepositoryCustom<T>
    {
        T GetColaboradorEstrangeirobyId(int id);
        T GetColaboradorEstrangeiroEditarById(int id);
        IEnumerable<T> GetColaboradorEstrangeiro(T colaboradorEstrangeiro);
        IEnumerable<T> GetColaboradorPreAdmissaoEstrangeiro(T colaboradorEstrangeiro);        
        T GetColaboradorEstrangeiroValidation(T colaboradorEstrangeiro);
    }
}