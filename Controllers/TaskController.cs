using System.Data;
using System.Reflection.Metadata;
using Case2GK20221102.Entities;
using Case2GK20221102.Services;
using Task = Case2GK20221102.Entities.Task;

namespace Case2GK20221102.Controllers;

//assign işleminde ilgili developerın var olduğunu doğrulamak.
//Task ile developer’ın departmanlarının aynı olduğunu doğrulamak
public class TaskController
{
    private DeveloperService _developerService;
    private TaskService _taskService;

    public TaskController(DeveloperService developerService, TaskService taskService)
    {
        _developerService = developerService;
        _taskService = taskService;
    }
    public void TaskAdd(string[] taskParts)   //Guid
    {  
    }
    
    public bool TaskAssign(string[] taskParts)
    {   
        var developer = new Developer();
        var task = new Task();
       
        if (taskParts[7] == Convert.ToString(developer.Id) && 
            taskParts[5] ==Convert.ToString(developer.Department) &&
            taskParts[2] == Convert.ToString(task.Id))
        {
           _taskService.Update(taskParts); 
           //Update,task,Id,title,description,department,status,DeveloperId
        }
        if (taskParts[7] == Convert.ToString(developer.Id) && 
            taskParts[5] ==Convert.ToString(developer.Department))
        {
            _taskService.Add(taskParts); 
        }
        return true;
    }


} 