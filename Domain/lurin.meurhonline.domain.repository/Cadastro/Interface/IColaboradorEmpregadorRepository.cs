using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IColaboradorEmpregadorRepository<T> : IRepositoryCustom<T>
    {
        T GetColaboradorEmpregadorbyId(int id);
        T GetColaboradorEmpregadorEditarById(int id);
        IEnumerable<T> GetColaboradorEmpregador(T colaboradorEmpregador);
        IEnumerable<T> GetColaboradorPreAdmissaoEmpregador(T colaboradorEmpregador);
        T GetColaboradorEmpregadorValidation(T colaboradorEmpregador);
        T GetColaboradorEmpregadorbyColaboradorId(int id);
    }
}