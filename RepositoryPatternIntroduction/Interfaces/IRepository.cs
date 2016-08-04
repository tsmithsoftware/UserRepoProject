using System;
using System.Linq;

namespace RepositoryPatternIntroduction.Backend.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(object id);
        IQueryable<T> GetAll();
        bool Insert(T entity);
        bool Delete(T entity);
        void Save();
        void Dispose();
    }
}
