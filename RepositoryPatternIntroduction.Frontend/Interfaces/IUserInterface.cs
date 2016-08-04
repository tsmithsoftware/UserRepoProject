namespace RepositoryPatternIntroduction.Frontend.Interfaces
{
    public interface IUserInterface
    {
       /** bool Search(string name);
        IPerson Get(string name);
        bool Delete(string name);
        IEnumerable<IPerson> GetAll();
        bool Insert(IPerson toInsert);
        void ListCommands();**/
        void HandleCommands();
    }
}
