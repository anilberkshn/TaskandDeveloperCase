using Case2GK20221102.Entities;
using Case2GK20221102.Repository;

namespace Case2GK20221102.Services;

public class DeveloperService
{
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
               Name = developerParts[1],
               Surname = developerParts[2],
               Department =Convert.ToInt32(developerParts[3])
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
               Id = Guid.Parse(developerParts[1]),
               Name = developerParts[2],
               Surname = developerParts[3],
               Department =Convert.ToInt32(developerParts[4])
          };
          return _repositoryDeveloper.Update(developer);
     }

     public bool Delete(string[] developerParts)
     {
          return _repositoryDeveloper.Delete(Guid.Parse(developerParts[1]));          
     }

     public List<Developer> GetAll()
     {
          return _repositoryDeveloper.GetAll();
     }
}