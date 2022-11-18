using Case2GK20221102.Controllers;

namespace Case2GK20221102;

public class Router
{
    private DeveloperController _developerController;
    private TaskController _taskController;

    public Router(DeveloperController developerController, TaskController taskController)
    {
        _developerController = developerController;
        _taskController = taskController;
    }
}