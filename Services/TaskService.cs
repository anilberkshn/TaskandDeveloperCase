using Case2GK20221102.Repository;
using Case2GK20221102.Entities;
using Task = Case2GK20221102.Entities.Task;  // bu kısmı neden d

namespace Case2GK20221102.Services;

public abstract class TaskService
{    
  private readonly GenericRepository<Task> _repositoryTask;

    public TaskService(GenericRepository<Task> genericRepository)
    {
        _repositoryTask = genericRepository;
    }

    public Guid Add(string[] taskParts)
    {
        var task = new Task
        {
            Id = new Guid(),
            Title = taskParts[1],
            Description = taskParts[2],
            Department = Convert.ToInt32(taskParts[3]),
            Status = 1
        };
        _repositoryTask.Add(task);
        return task.Id;
    }

    public Task? Get(string id)
    {
        return _repositoryTask.GetById(Guid.Parse(id));        
    }

    public bool Update(string[] taskParts)
    {
        var task = new Task
        {
            Id =Guid.Parse(taskParts[1]),
            Title = taskParts[2],
            Description = taskParts[3],
            Department = Convert.ToInt32(taskParts[4]),
            Status = Convert.ToInt32(taskParts[5]),
            DeveloperId = Guid.Parse(taskParts[6])
        };
       
        return  _repositoryTask.Update(task);         // gecici
    }

    public bool Delete(string[] taskParts)
    {
        return _repositoryTask.Delete(Guid.Parse(taskParts[1]));          // gecici
    }
    
    public List<Task> GetAll()
    {
        return _repositoryTask.GetAll();          // gecici
    }
}
