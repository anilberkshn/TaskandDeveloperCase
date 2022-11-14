using Case2GK20221102.Entities;
using Case2GK20221102.Repository;

namespace Case2GK20221102.Services;

public class DeveloperService
{
     //DENEME COMMITI
     private readonly GenericRepository<Developer> _repositoryDeveloper;

     public DeveloperService(GenericRepository<Developer> genericRepository)
     {
          _repositoryDeveloper = genericRepository;
     } 
     
     public Guid Add(string[] developerParts)
     {
          var developer = new Developer
          {
               Id = new Guid(),
               Name = developerParts[2],
               Surname = developerParts[3],
               Department =Convert.ToInt32(developerParts[4])
          };
           
          _repositoryDeveloper.Add(developer);
          return developer.Id;
     }

     public Developer? Get(string id)
     {
          return _repositoryDeveloper.GetById(Guid.Parse(id)); 
     }
     
     public bool Update (string[] developerParts)
     {
          var developer = new Developer
          {
               Id = Guid.Parse(developerParts[2]),
               Name = developerParts[3],
               Surname = developerParts[4],
               Department =Convert.ToInt32(developerParts[5])
          };
          return _repositoryDeveloper.Update(developer);
     }

     public bool Delete(string[] developerParts)
     {
          return _repositoryDeveloper.Delete(Guid.Parse(developerParts[2]));          
     }

     public List<Developer> GetAll()
     {
          return _repositoryDeveloper.GetAll();
     }
}