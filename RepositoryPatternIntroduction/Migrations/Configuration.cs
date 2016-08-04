using System.Collections.Generic;
using RepositoryPatternIntroduction.Backend.Entities;

namespace RepositoryPatternIntroduction.Backend.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RepositoryPatternIntroduction.Backend.Contexts.PersonContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RepositoryPatternIntroduction.Backend.Contexts.PersonContext context)
        {
            context.Persons.AddRange(
                new List<Person>()
                {
                    new Person
                    {
                        Name = "Mikayla",
                        Age = 23
                    },
                    new Person
                    {
                        Name = "Jose",
                        Age = 78
                    },
                    new Person
                    {
                        Name = "Richard",
                        Age = 23
                    }
                });
            context.SaveChanges();
        }
    }
}
