using System.ComponentModel.DataAnnotations;
using Case2GK20221102.Errors;
using Case2GK20221102.Services;
using Task = Case2GK20221102.Entities.Task;

namespace Case2GK20221102.Controllers;

public class TaskController
{
    private readonly DeveloperService _developerService;
    private readonly TaskService _taskService;

    public TaskController(DeveloperService developerService, TaskService taskService)
    {
        _developerService = developerService;
        _taskService = taskService;
    }

    public Guid AddTask(string[] taskParts) //Add,task 1,title 2 ,description 3 , department 4 ,
    {
        if (taskParts[2].Length < 3)
        {
            throw new ValidationErrorException("TaskController title input error",taskParts[2]);
        }
        if (taskParts[3].Length < 3)
        {
            throw new ValidationErrorException("TaskController description input error",taskParts[3]);
        }
        if (taskParts[4] is not ("0" or "1" or "2"))
        {
            throw new ValidationErrorException("TaskController department input error",taskParts[4]);
        }

        return _taskService.Add(taskParts);
    }

    public Task GetTask(string[] taskParts) 
    {
        return _taskService.Get(taskParts[2]) ?? throw new InvalidOperationException();
    }

    public bool UpdateTask(string[] taskParts)
    {
        //Update,task,Id 2 ,title 3 ,description 4 ,department 5 ,status 6 ,DeveloperId 7
        Guid guidResult;
        bool isValid = Guid.TryParse(taskParts[2], out guidResult);
        if (isValid != true) // ID guid değilse hata verdirmek istedim.
        {
            throw new ValidationErrorException("TaskController ID input error",taskParts[2]);
        }

        if (taskParts[3].Length < 3)
        {
            throw new ValidationErrorException("TaskController title input error",taskParts[3]);
        }

        if (taskParts[4].Length < 5)
        {
            throw new ValidationErrorException("TaskController description input error",taskParts[4]);
        }

        if (taskParts[5] is not ("0" or "1" or "2"))
        {
            throw new ValidationErrorException("TaskController department input error",taskParts[5]);
            ;
        }

        if (taskParts[6] == "3" && taskParts[6] is not ("0" or "1" or "2"))
        {
            throw new ValidationErrorException("TaskController status input error",taskParts[6]);
        }

        if (null == _developerService.Get(taskParts[7]))
        {
            throw new DeveloperNotFoundException();
        }

        return _taskService.Update(taskParts);
    }

    public bool DeleteTask(string[] taskParts) //Delete,task,id
    {
        return _taskService.Delete(taskParts);
    }


    
    public bool TaskAssign(string[] taskParts)
     //Update(Assign) ,task,Id 2 ,title 3 ,description 4 ,department 5 ,status 6 ,DeveloperId 7
    {
        //var task = _taskService.Get(taskParts[2]);
        var developer = _developerService.Get(taskParts[7]);
        
        if (developer == null)
        {
            throw new DeveloperNotFoundException();
        }
        
        if (taskParts[7] == developer.Id.ToString() 
            && taskParts[5] == developer.Department.ToString())
        {
            UpdateTask(taskParts);
            return true;
        }
        return false;
    }
}