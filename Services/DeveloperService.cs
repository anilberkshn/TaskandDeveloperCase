using Case2GK20221102.Entities;
using Case2GK20221102.Repository;

namespace Case2GK20221102.Services;

public class DeveloperService
{
     private readonly List<Developer> _developersList = new List<Developer>();
     private GenericRepository<Developer> _repositoryDeveloper;

     public DeveloperService()
     {
          _repositoryDeveloper = new GenericRepository<Developer>(_developersList);
     }
     //repository  <developer> 
}