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
        var tasks = _taskService.GetAll();

        foreach (var t in tasks)
        {
            
        }
        // }
    }
    // 1. Aşaam
    //ya string arrayi al yada string al içerde parçalaa
    //parçaları valide et if if diye validasyondan geçenmeyenler için error fırlat
    // Errorların custom error oluşturma 
    // bu şekilde crud işlemleri tamamlanacak.
    
    //2. aşama
    // 1 dev silindiğinde ()
    
    
}