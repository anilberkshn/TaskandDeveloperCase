using Case2GK20221102.Services;
using Task = Case2GK20221102.Entities.Task;

namespace Case2GK20221102.Controllers;

public class DeveloperController    
{
    private DeveloperService _developerService;
    private TaskService _taskService;

    public DeveloperController(DeveloperService developerService, TaskService taskService)
    {
        _developerService = developerService;
        _taskService = taskService;
    }

    public void DeleteTaskDeveloperId(string[] developerParts)
    {
        // if (developerParts[1] == "dev" && developerParts[0] == "delete")
        // {
            var task = new Task();
            if (developerParts[2] == Convert.ToString(task.DeveloperId))
            {
                task.DeveloperId = Guid.Empty;
            }
            _developerService.Delete(developerParts);
        // }
        
    }
}