using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RepositoryPatternIntroduction.Backend.Entities;
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
            Person barry = repo.Get("Barry");
            Assert.IsTrue(barry.Name == "Barry");
            Assert.IsTrue(barry.Age == 32);
        }

        [Test]
        public void TestGetAllReturnsExpectedCollection()
        {
            bool testPasses = true;
            CsvPersonRepository repo = new CsvPersonRepository();
            IQueryable<Person> repoPeople = repo.GetAll();
            foreach (Person person in GetExpectedCollection())
            {
                if (!repoPeople.Contains(person,new PersonComparator())) testPasses = false;
            }

            Assert.IsTrue(testPasses);
        }

        [Test]
        public void TestDeleteRemovesPassedPerson()
        {
            CsvPersonRepository repo = new CsvPersonRepository();
            bool barryExistsPrior = repo.Get("Barry") != null;
            repo.Delete(repo.Get("Barry"));
            bool barryExistsAfter = repo.Get("Barry") != null;
            Assert.IsTrue(barryExistsPrior && !barryExistsAfter);
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
