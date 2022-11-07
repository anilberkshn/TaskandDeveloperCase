using Case2GK20221102.Repository;
using Case2GK20221102.Entities;
using Task = Case2GK20221102.Entities.Task;

namespace Case2GK20221102.Services;

public class TaskService
{    
    private readonly List<Task> _tasksList = new List<Task>();
    private readonly GenericRepository<Task> _repositoryTask;

    public TaskService()
    {
        _repositoryTask = new GenericRepository<Task>(_tasksList);
    }
}