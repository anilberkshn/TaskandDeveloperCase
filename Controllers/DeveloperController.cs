using Case2GK20221102.Entities;
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

    public void ControlDeveloper(string[] developerParts)
    {
        if (developerParts[1] == "dev" && developerParts[0] == "delete")
        {
            var task = new Task();
            _developerService.Delete(developerParts);
           // if (developerParts[2] == _taskService.Get(developerParts[2]))
            {
                
            }
            
        }

       

        
    }
}