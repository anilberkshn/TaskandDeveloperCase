using Case2GK20221102.Repository;
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
            Title = taskParts[2],
            Description = taskParts[3],
            Department = Convert.ToInt32(taskParts[4]),
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
            Id =Guid.Parse(taskParts[2]),
            Title = taskParts[3],
            Description = taskParts[4],
            Department = Convert.ToInt32(taskParts[5]),
            Status = Convert.ToInt32(taskParts[6]),
            DeveloperId = Guid.Parse(taskParts[7])
        };
       
        return  _repositoryTask.Update(task); 
    }

    public bool Delete(string[] taskParts)
    {
        return _repositoryTask.Delete(Guid.Parse(taskParts[2]));    
    }
    
    public List<Task> GetAll()
    {
        return _repositoryTask.GetAll();    
    }
}
