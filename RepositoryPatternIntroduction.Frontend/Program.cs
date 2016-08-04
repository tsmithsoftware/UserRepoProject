using System;
using RepositoryPatternIntroduction.Backend.Entities;
using RepositoryPatternIntroduction.Backend.Interfaces;

namespace RepositoryPatternIntroduction.Frontend
{
    public class Program
    {
        static void Main(string[] args)
        {
            IRepository<Person> repo;
            foreach (var person in repo.GetAll())
            {
                Console.Out.WriteLine(person.ToString());
            }
        }
    }
}
