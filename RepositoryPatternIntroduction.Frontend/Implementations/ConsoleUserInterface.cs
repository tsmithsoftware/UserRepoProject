using System;
using RepositoryPatternIntroduction.Backend.Entities;
using RepositoryPatternIntroduction.Backend.Interfaces;
using RepositoryPatternIntroduction.Frontend.Interfaces;
using RepositoryPatternIntroduction.Frontend.Utilities;

namespace RepositoryPatternIntroduction.Frontend.Implementations
{
    public class ConsoleUserInterface:IUserInterface
    {
        private IRepository<IPerson> _repository;

        public ConsoleUserInterface(IRepository<IPerson> repo)
        {
            _repository = repo;
        }
 
        public void HandleCommands()
        {
            Console.WriteLine("Please write a command, or type Help for a command list. Type quit to exit.");
            bool quit = false;
            while (!quit)
            {
                CommandObject command = null;
                try
                {
                    command = CommandObjectGenerator.ReturnCommandObject(Console.ReadLine());
                }
                catch
                {
                   Console.WriteLine("Please enter an appropriate value.");
                   continue;
                }
                
                switch (command.Command)
                {
                    case Command.DELETE:
                        Delete(command);
                        break;
                    case Command.GET:
                        IPerson user = GetUser(command);
                        if (user != null)
                        {
                            Console.WriteLine(user.ToString() != "" ? user.ToString() : "No user information found.");
                        }
                        else
                        {
                            Console.WriteLine("No user information found");
                        }
                        break;
                    case Command.GETALL:
                        WriteAllUsers();
                        break;
                    case Command.HELP:
                        DisplayHelp();
                        break;
                    case Command.INSERT:
                        InsertUser(command);
                        break;
                    case Command.SEARCH:
                        Search(command);
                        break;
                    case Command.QUIT:
                        quit = true;
                        break;
                }
            }
        }

        private void Search(CommandObject command)
        {
            IPerson person = (_repository.Get(command.PersonName));
            if (person != null)
            {
                Console.WriteLine("Found: " + person);
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }

        private void InsertUser(CommandObject command)
        {
            bool success = _repository.Insert(
                new Person()
                {
                    Name = command.PersonName,
                    Age = int.Parse(command.PersonAge)
                });
            Console.WriteLine("Success: " + success);
        }

        private static void DisplayHelp()
        {
            Console.WriteLine("DELETE {USER} : delete user if found");
            Console.WriteLine("GET {USER} : retrieve user details if found");
            Console.WriteLine("GETALL : retrive all user details");
            Console.WriteLine("HELP : display this help message");
            Console.WriteLine("INSERT {USERNAME} {AGE}: insert new user with age X ");
            Console.WriteLine("SEARCH {USERNAME} : attempt to find user");
            Console.WriteLine("QUIT : exit the program");
        }

        private void WriteAllUsers()
        {
            foreach (IPerson person in _repository.GetAll())
            {
                Console.WriteLine(person.ToString());
            }
        }

        private IPerson GetUser(CommandObject command)
        {
            return _repository.Get(
                command.PersonName
                );
        }

        private void Delete(CommandObject command)
        {
            _repository.Delete(
                _repository.Get(
                    command.PersonName
                    )
                );
        }
    }
}
