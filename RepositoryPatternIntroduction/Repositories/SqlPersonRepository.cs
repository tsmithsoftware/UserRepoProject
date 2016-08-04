using System;
using System.Linq;
using RepositoryPatternIntroduction.Backend.Contexts;
using RepositoryPatternIntroduction.Backend.Entities;
using RepositoryPatternIntroduction.Backend.Interfaces;

namespace RepositoryPatternIntroduction.Backend.Repositories
{
    public class SqlPersonRepository : IRepository<Person>
    {
        private PersonContext _context;
        public SqlPersonRepository()
        {
            _context = new PersonContext();
        }
        public bool Delete(Person entity)
        {
            return _context.Persons.Remove(entity) != null;
        }

        public Person Get(object id)
        {
            return _context.Persons.Find(id);
        }

        public IQueryable<Person> GetAll()
        {
            return _context.Persons.ToList().AsQueryable();
        }

        public bool Insert(Person entity)
        {
           return _context.Persons.Add(entity) != null;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
