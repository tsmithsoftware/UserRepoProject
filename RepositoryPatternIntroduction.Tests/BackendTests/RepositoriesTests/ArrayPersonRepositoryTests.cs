using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using RepositoryPatternIntroduction.Backend.Interfaces;
using RepositoryPatternIntroduction.Backend.Repositories;

namespace RepositoryPatternIntroduction.Tests.BackendTests.RepositoriesTests
{
    [TestFixture]
    public class ArrayPersonRepositoryTests
    {
        [Test]
        public void TestGetPersonReturnsCorrectPerson()
        {
            Mock<IPerson> mockPersonBob = new Mock<IPerson>();
            mockPersonBob.Setup(x => x.Name).Returns("Bob");

            Mock<IPerson> mockPersonJohn = new Mock<IPerson>();
            mockPersonJohn.Setup(x => x.Name).Returns("John");

            ArrayPersonRepository arrayRepoSut = new ArrayPersonRepository(new List<IPerson>()
            {
                mockPersonJohn.Object,
                mockPersonBob.Object
            }
            );

            Assert.IsTrue(
                arrayRepoSut.Get("John").Equals(mockPersonJohn.Object)
                );
        }

        [Test]
        public void TestGetAllContainsAllPeople()
        {
            Mock<IPerson> mockPersonBob = new Mock<IPerson>();
            mockPersonBob.Setup(x => x.Name).Returns("Bob");

            Mock<IPerson> mockPersonJohn = new Mock<IPerson>();
            mockPersonJohn.Setup(x => x.Name).Returns("John");

            ArrayPersonRepository arrayRepoSut = new ArrayPersonRepository(new List<IPerson>()
            {
                mockPersonJohn.Object,
                mockPersonBob.Object
            }
            );

            Assert.IsTrue(
                arrayRepoSut.GetAll().Contains(mockPersonJohn.Object)
                );

            Assert.IsTrue(
                arrayRepoSut.GetAll().Contains(mockPersonBob.Object)
                );
        }

        [Test]
        public void TestDeletePersonDeletesPerson()
        {
            Mock<IPerson> mockPersonBob = new Mock<IPerson>();
            mockPersonBob.Setup(x => x.Name).Returns("Bob");

            Mock<IPerson> mockPersonJohn = new Mock<IPerson>();
            mockPersonJohn.Setup(x => x.Name).Returns("John");

            ArrayPersonRepository arrayRepoSut = new ArrayPersonRepository(new List<IPerson>()
            {
                mockPersonJohn.Object,
                mockPersonBob.Object
            }
            );

            arrayRepoSut.Delete(mockPersonJohn.Object);

            Assert.IsFalse(
                arrayRepoSut.Get("John") != null
                );
        }

        [Test]
        public void TestInsertInsertsPerson()
        {
            Mock<IPerson> mockPersonBob = new Mock<IPerson>();
            mockPersonBob.Setup(x => x.Name).Returns("Bob");

            Mock<IPerson> mockPersonJohn = new Mock<IPerson>();
            mockPersonJohn.Setup(x => x.Name).Returns("John");

            ArrayPersonRepository arrayRepoSut = new ArrayPersonRepository(new List<IPerson>()
            {
                mockPersonJohn.Object
            }
            );

            arrayRepoSut.Insert(mockPersonBob.Object);

            Assert.IsTrue(
                arrayRepoSut.Get("Bob") != null
                );
        }
    }
}
