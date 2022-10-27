using System.Threading.Tasks;
using System.Data.Entity;

namespace lurin.meurhonline.infrastructure.persistence.interfaces
{
    public interface IUnitOfWork
    {
        DbSet<T> Set<T>() where T : class;

        void Commit();

        Task CommitAsync();

        void CloseConn();
    }
}
