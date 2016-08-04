using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepositoryPatternIntroduction.Backend.Entities;
using RepositoryPatternIntroduction.Backend.Interfaces;

namespace RepositoryPatternIntroduction.Tests.Utilities
{
    public class PersonComparator : EqualityComparer<IPerson>
    {
        public override bool Equals(IPerson firstPerson, IPerson secondPerson)
        {
            if (firstPerson == null && secondPerson == null)
                return true;
            if (firstPerson == null || secondPerson == null)
                return false;
            return firstPerson.Name.Equals(secondPerson.Name)
                   && firstPerson.Age.Equals(secondPerson.Age);
        }

        public override int GetHashCode(IPerson obj)
        {
            return base.GetHashCode();
        }
    }
}
