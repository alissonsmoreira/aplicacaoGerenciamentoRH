using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IColaboradorPagamentoRepository<T> : IRepositoryCustom<T>
    {
        T GetColaboradorPagamentobyId(int id);
        T GetColaboradorPagamentoEditarById(int id);
        IEnumerable<T> GetColaboradorPagamento(T colaboradorPagamento);
        IEnumerable<T> GetColaboradorPreAdmissaoPagamento(T colaboradorPagamento);        
        T GetColaboradorPagamentoValidation(T colaboradorPagamento);
        T GetColaboradorPagamentobyColaboradorId(int id);
    }
}