using Case2GK20221102.Entities;
using Case2GK20221102.Errors;
using Case2GK20221102.Services;

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

    public Guid AddDeveloper(string[] developerParts) // Add,developer,name,surname,departmant
    {
        if (developerParts[2].Length < 2)
        {
            throw new ValidationErrorException("DeveloperController name input error",developerParts[2]);
        }
        if (developerParts[3].Length < 2) 
        { 
            throw new ValidationErrorException("DeveloperController Surname input error",developerParts[3]);
        }
        if (developerParts[4] is not ("0" or "1" or "2"))
        {
            throw new ValidationErrorException("DeveloperController Department input error",developerParts[4]);
        }

        return _developerService.Add(developerParts);
    }

    public Developer GetDeveloper(string[] developerParts)
    {
     return _developerService.Get(developerParts[2]) ?? throw new DeveloperNotFoundException();
    }

    public bool UpdateDeveloper(string[] developerParts)
    {
        // Update 0,developer 1 ,Id 2 ,name 3 ,surname 4 ,department 5
        if (developerParts[2].Length < 2)
        {
            throw new ValidationErrorException("DeveloperController ID input error",developerParts[2]);
        }
        else if (developerParts[3].Length < 2)
        {
            throw new ValidationErrorException("DeveloperController name input error",developerParts[3]);
        }
        else if (developerParts[4].Length < 2)
        {
            throw new ValidationErrorException("DeveloperController Surname input error",developerParts[4]);
        }
        else if (developerParts[5] is not ("0" or "1" or "2"))
        {
            throw new ValidationErrorException("DeveloperController Department input error",developerParts[5]);
        }

        return _developerService.Update(developerParts);
    }

    public bool DeleteDeveloper(string[] developerParts) // Delete,Developer,DeveloperId
    {
        _developerService.Delete(developerParts);
        UnassignDeveloperOnTask(developerParts);
        return true;
    }
    public void UnassignDeveloperOnTask(string[] developerParts) 
         //delete,developer,DeveloperId
     {
         var tasks = _taskService.GetAll(); 
         foreach (var task in tasks)
         {
             if (developerParts[2] == Convert.ToString(task.DeveloperId)
                 && task.Status != 3)
             {
                 task.DeveloperId = Guid.Empty;
             }
         }
     }
}