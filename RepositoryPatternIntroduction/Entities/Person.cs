using RepositoryPatternIntroduction.Backend.Interfaces;

namespace RepositoryPatternIntroduction.Backend.Entities
{
    public class Person:IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
