using NUnit.Framework;
using RepositoryPatternIntroduction.Frontend.Utilities;

namespace RepositoryPatternIntroduction.Tests.Utilities
{
    [TestFixture]
    public class CommandParserTests
    {
        [Test]
        public void TestParserReturnsCorrectEnum()
        {
            Assert.IsTrue(CommandParser.ParseCommand("Search") == Command.Search);
            Assert.IsTrue(CommandParser.ParseCommand("Get") == Command.Get);
            Assert.IsTrue(CommandParser.ParseCommand("Delete") == Command.Delete);
        }
    }
}
