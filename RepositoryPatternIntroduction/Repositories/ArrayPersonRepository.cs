using System;
using System.Collections.Generic;
using System.Linq;
using RepositoryPatternIntroduction.Backend.Entities;
using RepositoryPatternIntroduction.Backend.Interfaces;

namespace RepositoryPatternIntroduction.Backend.Repositories
{
    public class ArrayPersonRepository : IRepository<IPerson>
    {
        private List<IPerson> people = null;

        public ArrayPersonRepository()
        {
            people = new List<IPerson>()
            {
                new Person()
                {
                    Name = "Bob"
                },
                new Person()
                {
                    Name = "John"
                },
                new Person()
                {
                    Name = "Tim"
                },
                new Person()
                {
                    Name = "Adam"
                }
            };
        }

        public ArrayPersonRepository(List<IPerson> initPeople)
        {
            people = initPeople;
        }

        public bool Delete(IPerson entity)
        {
            try
            {
                people.Remove(entity);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public IPerson Get(object id)
        {
            try
            {
                return people.First(p => p.Name.Equals((string) id));
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public IQueryable<IPerson> GetAll()
        {
            return people.AsQueryable();
        }

        public bool Insert(IPerson entity)
        {
            try
            {
                people.Add(entity);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public void Save()
        {
            //placeholder
        }

        public void Dispose()
        {
            people = null;
        }
    }
}
