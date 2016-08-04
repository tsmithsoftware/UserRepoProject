using Castle.MicroKernel.Registration;
using Castle.Windsor;
using RepositoryPatternIntroduction.Backend.Entities;
using RepositoryPatternIntroduction.Backend.Interfaces;
using RepositoryPatternIntroduction.Backend.Repositories;
using RepositoryPatternIntroduction.Frontend.Implementations;
using RepositoryPatternIntroduction.Frontend.Interfaces;

namespace RepositoryPatternIntroduction.Frontend
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();

            //register interfaces and their implementations
            container.Register(Component.For<IPerson>()
                .ImplementedBy<Person>());
            container.Register(Component.For<IRepository<IPerson>>()
                .ImplementedBy<ArrayPersonRepository>());
            container.Register(Component.For<IUserInterface>()
                .ImplementedBy<ConsoleUserInterface>());

            //run project
            IUserInterface ui = (IUserInterface)container.Resolve(typeof(IUserInterface));
            ui.HandleCommands();
        }
    }
}
