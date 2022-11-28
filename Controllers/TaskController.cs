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

    public Guid AddTask(string[] taskParts) //Add,task,title,description, department,
    {
        if (taskParts[2].Length < 3)
        {
            throw new ValidationErrorException();
        }
        if (taskParts[3].Length < 3)
        {
            throw new ValidationErrorException();
        }
        if (taskParts[4] is not ("0" or "1" or "2"))
        {
            throw new ValidationErrorException();
       // todo: daha sonra exception içinde validasyonlar yapılabilir mi? içine atılan parta göre o
       // partta hata olduğunu belirtmesi için 
       // TODO: exception'ı fırlatan yer ile ilgili bilgileri exception'ın içine almalısın.
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
            throw new ValidationErrorException();
        }
        if (taskParts[3].Length < 3) //TODO: Else'ler hatalı yine
        {
            throw new ValidationErrorException();
        }
        if (taskParts[4].Length < 5)
        {
            throw new ValidationErrorException();
        }
        if (taskParts[5] is not ("0" or "1" or "2"))
        {
            throw new ValidationErrorException();
            ;
        }
        if (taskParts[6] == "3" && taskParts[6] is not ("0" or "1" or "2")) 
          // 3- completed status //ilk if koşulu da gereksiz gibi 2.yi yazınca
        {
            throw new ValidationErrorException();
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
        var tasks = _taskService.Get(taskParts[2]);
        var developers = _developerService.Get(taskParts[7]);

        if (taskParts[7] == developers!.Id.ToString()
            && taskParts[5] == developers.Department.ToString())
        {
            UpdateTask(taskParts);
            return true;
        }
        return false;
    }
}