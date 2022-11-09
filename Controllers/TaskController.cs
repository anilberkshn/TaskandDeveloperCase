using Case2GK20221102.Services;

namespace Case2GK20221102.Controllers;

public class TaskController
{
    private DeveloperService _developerService;
    private TaskService _taskService;

    public TaskController(DeveloperService developerService, TaskService taskService)
    {
        _developerService = developerService;
        _taskService = taskService;
    }
} 