using Case2GK20221102.Repository;
using Case2GK20221102.Entities;
using Task = Case2GK20221102.Entities.Task;  // bu kısmı neden d

namespace Case2GK20221102.Services;

public abstract class TaskService
{    
    private readonly List<Task> _tasksList = new List<Task>();
    private readonly GenericRepository<Task> _repositoryTask;

    public TaskService()
    {
        _repositoryTask = new GenericRepository<Task>(_tasksList);
    }

    public Guid Add(Task task)
    {
        return Guid.Empty;          // gecici
    }

    public Task? Get(string id)
    {
        return null;          // gecici
    }
 
    public bool Upsert(Task task)
    {
        return true;          // gecici
    }

    public bool Delete(Task task)
    {
        return false;          // gecici
    }

    public Task[]? GetUnAssignet()
    {
        return null;          // gecici
    }

    public Task[] GetAll()
    {
        return _tasksList.ToArray();          // gecici
    }
}
