using System;
namespace RepositoryPatternIntroduction.Backend.Interfaces
{
    public interface IPerson
    {
        int Id { get; set; }
        string Name { get; set; }
        int Age { get; set; }
    }
}
