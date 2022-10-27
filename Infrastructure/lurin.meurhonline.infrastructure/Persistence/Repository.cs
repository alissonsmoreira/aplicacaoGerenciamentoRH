using System;
using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.infrastructure.persistence
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private static IUnitOfWork _db;

        public Repository(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;            
        }

        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        public void Add(IEnumerable<T> entity)
        {
            _db.Set<T>().AddRange(entity);
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        public void Delete(IEnumerable<T> entity)
        {
            _db.Set<T>().RemoveRange(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }
    }
}