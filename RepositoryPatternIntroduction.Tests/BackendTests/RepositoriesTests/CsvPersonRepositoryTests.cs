using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RepositoryPatternIntroduction.Backend.Entities;
using RepositoryPatternIntroduction.Backend.Interfaces;
using RepositoryPatternIntroduction.Backend.Repositories;
using RepositoryPatternIntroduction.Tests.Utilities;

namespace RepositoryPatternIntroduction.Tests.BackendTests.RepositoriesTests
{
    [TestFixture]
    public class CsvPersonRepositoryTests
    {
        [Test]
        public void TestGetPersonReturnsCorrectPerson()
        {
            CsvPersonRepository repo = new CsvPersonRepository();
            IPerson barry = repo.Get("Barry");
            try
            {
                Assert.IsTrue(barry.Name == "Barry");
                Assert.IsTrue(barry.Age == 32);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [Test]
        public void TestGetAllReturnsExpectedCollection()
        {
            bool testPasses = true;
            CsvPersonRepository repo = new CsvPersonRepository();
            IQueryable<IPerson> repoPeople = repo.GetAll();
            foreach (IPerson person in GetExpectedCollection())
            {
                if (!repoPeople.Contains(person,new PersonComparator())) testPasses = false;
            }

            Assert.IsTrue(testPasses);
        }

        [Test]
        public void TestDeleteRemovesPassedPerson()
        {
            CsvPersonRepository repo = new CsvPersonRepository();
            IPerson barry = repo.Get("Barry");
            bool barryExistsPrior = repo.Get("Barry") != null;
            repo.Delete(repo.Get("Barry"));
            bool barryExistsAfter = repo.Get("Barry") != null;
            repo.Insert(barry);
            Assert.IsTrue(barryExistsPrior && !barryExistsAfter);
        }

        [Test]
        public void TestInsertInsertsPassedPerson()
        {
            CsvPersonRepository repo = new CsvPersonRepository();
            Person newPerson = new Person()
            {
                Name = "TestMan",
                Age = 999
            };
            bool personExistsBeforeInsert = repo.Get("TestMan") != null;
            bool personExistsAfterInsert = repo.Insert(newPerson);
            bool personCanBeRetrieved = repo.Get("TestMan") != null;

            Assert.IsTrue(!personExistsBeforeInsert && personExistsAfterInsert && personCanBeRetrieved);
        }

        private IEnumerable<Person> GetExpectedCollection()
        {
            return new List<Person>()
            {
                new Person()
                {
                    Name = "John",
                    Age = 34
                },
                new Person()
                {
                    Name = "Barry",
                    Age = 32
                },
                new Person()
                {
                    Name = "Bob",
                    Age = 21
                },
                new Person()
                {
                    Name = "Bill",
                    Age = 28
                }
            };
        }
    }
}
