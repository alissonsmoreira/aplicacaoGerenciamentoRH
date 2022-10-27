using System.Collections.Generic;
using System.Threading.Tasks;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface INotificacaoRepository<T> : IRepositoryCustom<T>
    {
        T GetNotificacaoById(int id);
        Task<T> GetNotificacaoByIdAsync(int id);        
        IEnumerable<T> GetNotificacaoByNotificacaoDetalheId(int id);
        IEnumerable<T> GetNotificacaoUsuario(int NotificacaoStatusLeituraId);
        IEnumerable<T> GetNotificacaoGestor(int NotificacaoStatusLeituraId);
    }
}