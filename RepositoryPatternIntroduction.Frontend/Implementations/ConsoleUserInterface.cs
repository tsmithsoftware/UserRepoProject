using System;
using System.Collections.Generic;
using RepositoryPatternIntroduction.Backend.Interfaces;
using RepositoryPatternIntroduction.Frontend.Interfaces;

namespace RepositoryPatternIntroduction.Frontend.Implementations
{
    public class ConsoleUserInterface:IUserInterface
    {
        private IRepository<IPerson> _repository;

        public ConsoleUserInterface(IRepository<IPerson> repo)
        {
            _repository = repo;
        }
        public bool Search(string name)
        {
            return _repository.Get(name) != null;
        }

        public IPerson Get(string name)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPerson> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(IPerson toInsert)
        {
            throw new NotImplementedException();
        }

        public void ListCommands()
        {
            throw new NotImplementedException();
        }

        public void HandleCommands()
        {
            throw new NotImplementedException();
        }
    }
}
