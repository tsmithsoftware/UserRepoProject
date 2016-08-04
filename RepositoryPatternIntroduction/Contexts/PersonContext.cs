using System.Data.Entity;
using RepositoryPatternIntroduction.Backend.Entities;

namespace RepositoryPatternIntroduction.Backend.Contexts
{
    public class PersonContext:DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }
}
