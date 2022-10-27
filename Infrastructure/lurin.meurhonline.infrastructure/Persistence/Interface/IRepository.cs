using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lurin.meurhonline.infrastructure.persistence.interfaces
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Add(IEnumerable<T> entity);
        void Delete(T entity);
        void Delete(IEnumerable<T> entity);
        IEnumerable<T> GetAll();        
    }
}
