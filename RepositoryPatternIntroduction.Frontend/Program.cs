using System;
using System.Linq;
using RepositoryPatternIntroduction.Backend.Contexts;
using RepositoryPatternIntroduction.Backend.Entities;

namespace RepositoryPatternIntroduction.Frontend
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new PersonContext())
            {
                //add user
                Console.WriteLine("Enter a name for the new person: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter an age for the new person: ");
                string age = Console.ReadLine();
                var user = new Person
                {
                    Name = name,
                    Age = int.Parse(age)
                };
                context.Persons.Add(user);
                context.SaveChanges();

                //list users
                var users = from value in context.Persons
                    orderby value.Name
                    select value;

                foreach (Person person in users)
                {
                    Console.Out.WriteLine(person.ToString());
                }
            }
        }
    }
}
