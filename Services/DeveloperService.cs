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
     public Guid Add(Developer developer)
     {
          return Guid.Empty; // gecici
     }

     public Developer? Get(string id)
     {
          return null;
     }
     
     public bool Upsert(Developer developer)
     {
          return true;          // gecici
     }

     public bool Delete(Developer developer)
     {
          return false;          // gecici
     }

     public Developer[] GetAll()
     {
          return _developersList.ToArray();            //geçici
     }
}