using System.ComponentModel.DataAnnotations;
using Case2GK20221102.Errors;
using Case2GK20221102.Services;
using Task = Case2GK20221102.Entities.Task;

namespace Case2GK20221102.Controllers;

//assign işleminde ilgili developerın var olduğunu doğrulamak.
//Task ile developer’ın departmanlarının aynı olduğunu doğrulamak

// Task statuleri:
// 0: -
// 1: Created
// 2: In-Dev
// 3: Completed
// Department bilgileri:
// 0: -
// 1: Backend
// 2: Frontend

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
        // GK: title, description vb diğer ne alanların varsa onlar için de validasyon yazmayı unutma
        /*Add ve task kısımları router tarafında yapılmalı gibi düşündüğüm için tittle ve
         description kısımlarına kontrollerli ekledim. */

        if (taskParts[2].Length < 3)
        {
            throw new ValidationErrorException();
        }
        else if (taskParts[3].Length < 3)
        {
            throw new ValidationErrorException();
        }
        else if (taskParts[4] is not ("0" or "1" or "2"))
        {
            //GK: Buralarda build-in exception'ı direkt trowlamak yerine kendin bir exception üretip (build-in exception'dan) onu throwlarsan daha iyi olur.
            throw new ValidationErrorException();
            // todo: daha sonra exception içinde validasyonlar yapılabilir mi? içine atılan parta göre o partta hata olduğunu belirtmesi için 
        }

        return _taskService.Add(taskParts);
    }

    public Task GetTask(string[] taskParts) //Get,task,id
    {
        //  GK: Bu get methodu mu delete methodu mu? bir üst satırdaki yorumda delete yazdığı için sordum. Get ise tüm taskları çekip içinde aramana gerek yok. Direkt getbyId methodunu kullanabilirisn
        //  Get ve delete aynı girdi parametresi alır diye koymuştum get diye değiştirmemişim.
        return _taskService.Get(taskParts[2]) ?? throw new InvalidOperationException();
    }

    public bool UpdateTask(string[] taskParts)
        //Update,task,Id 2 ,title 3 ,description 4 ,department 5 ,status 6 ,DeveloperId 7
        //Departmant 
        //Statusun bitmemiş olmalı
        //DeveloperId
        //GK: validasyonların aynı şekilde, tüm parçalar için yapabilirsin.
    {
        Guid guidResult;
        bool isValid = Guid.TryParse(taskParts[2], out guidResult);
        if (isValid != true) // ID guid değilse hata verdirmek istedim.
        {
            throw new ValidationErrorException();
        }
        else if (taskParts[3].Length < 3)
        {
            throw new ValidationErrorException();
            ;
        }
        else if (taskParts[4].Length < 5)
        {
            throw new ValidationErrorException();
        }
        else if (taskParts[5] is not ("0" or "1" or "2"))
        {
            throw new ValidationErrorException();
            ;
        }
        else if (taskParts[6] == "3" && taskParts[6] is not ("0" or "1" or "2")) // 3- completed status
        {
            //todo: ilk if koşulu da gereksiz gibi 2.yi yazınca
            throw new ValidationErrorException();
        }
        else if (null == _developerService.Get(taskParts[7]))
        {
            throw new DeveloperNotFoundException();
        }

        return _taskService.Update(taskParts);
    }

    public bool DeleteTask(string[] taskParts) //Delete,task,id
    {
        return _taskService.Delete(taskParts);
    }


    //*********************************2. KISIM 
    public bool TaskAssign(string[] taskParts)
    // todo: taskassign için Add de developer id yapmadığımız için developerId birtek update de var diye ona göre varsaydım. 
    ////Update,task,Id 2 ,title 3 ,description 4 ,department 5 ,status 6 ,DeveloperId 7
    {
        var tasks = _taskService.GetAll();
        var developers = _developerService.Get(taskParts[7]);

        foreach (var task in tasks)
        {
            if (task.DeveloperId == developers.Id)
            {
                
            }
            
        }
    
        // if (taskParts[7] == Convert.ToString(developer.Id) &&
        //     taskParts[5] == Convert.ToString(developer.Department) &&
        //     taskParts[2] == Convert.ToString(task.Id))
        // {
        //     _taskService.Update(taskParts);
        //     //Update,task,Id,title,description,department,status,DeveloperId
        // }
        //
        // if (taskParts[7] == Convert.ToString(developer.Id) &&
        //     taskParts[5] == Convert.ToString(developer.Department))
        // {
        //     _taskService.Add(taskParts);
        // }
    
        return true;
    }
}