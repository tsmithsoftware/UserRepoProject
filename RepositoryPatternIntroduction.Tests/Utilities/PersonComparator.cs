using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepositoryPatternIntroduction.Backend.Entities;

namespace RepositoryPatternIntroduction.Tests.Utilities
{
    public class PersonComparator : EqualityComparer<Person>
    {
        public override bool Equals(Person firstPerson, Person secondPerson)
        {
            if (firstPerson == null && secondPerson == null)
                return true;
            if (firstPerson == null || secondPerson == null)
                return false;
            return firstPerson.Name.Equals(secondPerson.Name)
                   && firstPerson.Age.Equals(secondPerson.Age);
        }

        public override int GetHashCode(Person obj)
        {
            return base.GetHashCode();
        }
    }
}
