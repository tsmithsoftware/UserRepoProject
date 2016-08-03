using System;
using System.Linq;
using RepositoryPatternIntroduction.Backend.Entities;
using RepositoryPatternIntroduction.Backend.Interfaces;

namespace RepositoryPatternIntroduction.Backend.Repositories
{
    public class SqlPersonRepository : IRepository<Person>
    {
        public void Attach(Person entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Person entity)
        {
            throw new NotImplementedException();
        }

        public Person Get(object id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
