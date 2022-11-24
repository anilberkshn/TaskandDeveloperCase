using Case2GK20221102.Entities;
using Case2GK20221102.Services;
using Task = Case2GK20221102.Entities.Task;

namespace Case2GK20221102.Controllers;

//assign işleminde ilgili developerın var olduğunu doğrulamak.
//Task ile developer’ın departmanlarının aynı olduğunu doğrulamak

// Task statuleri:
// 0: -
// 1: Created
// 2: In-Dev
// 3: CompletedDepartment bilgileri:
//
// 0: -
// 1: Backend
// 2: Frontend

public class TaskController
{
    private DeveloperService _developerService;
    private TaskService _taskService;

    public TaskController(DeveloperService developerService, TaskService taskService)
    {
        _developerService = developerService;
        _taskService = taskService;
    }

    public Guid AddTask(string[] taskParts)//Add,task,title,description, department,
    {
        //TODO: title, description vb diğer ne alanların varsa onlar için de validasyon yazmayı unutma
        if (taskParts[4] is not ("0" or "1" or "2"))
        {
            //TODO: Buralarda build-in exception'ı direkt trowlamak yerine kendin bir exception üretip (build-in exception'dan) onu throwlarsan daha iyi olur.
            throw new Exception("Task Departmanı 0,1,2 olmalıdır.");
        }
        return _taskService.Add(taskParts);
    }

    public Task GetTask(string[] taskParts) //Delete,task,id
    {
        //TODO: Bu get methodu mu delete methodu mu? bir üst satırdaki yorumda delete yazdığı için sordum. Get ise tüm taskları çekip içinde aramana gerek yok. Direkt getbyId methodunu kullanabilirisn
        var tasks = _taskService.GetAll();
        foreach (var task in tasks)
        {
            if (task.Id == Guid.Parse(taskParts[2]))
            {
                //TODO: buradaki methodunu direkt kullanabilirsin. for dönmene gerek yok yani.
                _taskService.Get(taskParts[2]);
            }
        }
        return _taskService.Get(taskParts[2]) ?? throw new InvalidOperationException();
    }

    public bool UpdateTask(string[] taskParts)
    //Update,task,Id,title,description,department,status,DeveloperId
    //Departmant 
    //Statusun bitmemiş olmalı
    //DeveloperId
    {
        //TODO: validasyonların aynı şekilde, tüm parçalar için yapabilirsin.
        if (taskParts[5] is not ("0" or "1" or "2"))
        {
            throw new Exception("Task Departmanı 0,1,2 olmalıdır.");
        }
        
        return _taskService.Update(taskParts);
    }

    public bool DeleteTask(string[] taskParts)
    {
        return _taskService.Delete(taskParts);
    }
    
    
    
    // public bool TaskAssign(string[] taskParts)
    // {
    //     var developer = new Developer();
    //     var task = new Task();
    //
    //     if (taskParts[7] == Convert.ToString(developer.Id) &&
    //         taskParts[5] == Convert.ToString(developer.Department) &&
    //         taskParts[2] == Convert.ToString(task.Id))
    //     {
    //         _taskService.Update(taskParts);
    //         //Update,task,Id,title,description,department,status,DeveloperId
    //     }
    //
    //     if (taskParts[7] == Convert.ToString(developer.Id) &&
    //         taskParts[5] == Convert.ToString(developer.Department))
    //     {
    //         _taskService.Add(taskParts);
    //     }
    //
    //     return true;
    // }
}