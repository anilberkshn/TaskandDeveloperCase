using Case2GK20221102.Entities;
using Case2GK20221102.Errors;
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
   
    public Guid AddDeveloper(string[] developerParts) // Add,developer,name,surname,departmant
    {
        // todo: 0-1 ve bir partı routerda yönlenmesi gerekli diye düşündüm. 
        
        if (developerParts[2].Length < 2)
        {
            throw new ValidationErrorException();
        }
        else if (developerParts[3].Length < 2)
        {
            throw new ValidationErrorException();
        }
        else if (developerParts[4] is not ("0" or "1" or "2"))
        {
            throw new Exception("Developer Departmanı 0,1,2 olmalıdır.");
        }
        
        return _developerService.Add(developerParts);
    }
    
    public Developer GetDeveloper(string[] developerParts)
        //Service string id istiyor gelen partı bölüp gönderdim.
        //Get,Develepor,Id program girişinde beklenen.
    {
        return _developerService.Get(developerParts[2]) ?? throw new DeveloperNotFoundException();
    }
    
    public bool UpdateDeveloper(string[] developerParts) 
        // Update 0,developer 1 ,Id 2 ,name 3 ,surname 4 ,department 5
       {
        if (developerParts[2].Length < 2 )
        {
            throw new ValidationErrorException(); 
        }
        else if (developerParts[3].Length < 2 )
        {
            throw new ValidationErrorException();
        }
        else if (developerParts[4].Length < 2)
        {
            throw new ValidationErrorException();
        }
        else if (developerParts[5] is not ("0" or "1" or "2"))
        {
            throw new ValidationErrorException();
        }
       
        return _developerService.Update(developerParts);
    }

    public bool DeleteDeveloper(string[] developerParts) // Delete,Developer,Id
    {
        // try
        // {
            // int sayac = 0; 
            // var developers = _developerService.GetAll();
            // foreach (var dev in developers)
            // {
            //     if (dev.Id == Guid.Parse(developerParts[2]))
            //     {
            //         _developerService.Delete(developerParts);
            //         sayac++;
            //     }
            // }
            //
            // if (sayac == 0)
            // {
            //     throw new Exception("Girilen id değerine ait kullanıcı bulunamamıştır");
            // }

            return _developerService.Delete(developerParts); 
            //// Her zaman true dönecek. 

            // }
            // catch (Exception )
            // {
            //     Console.WriteLine("Girilen id değerine ait kullanıcı bulunamamıştır");
            //     throw;
            // }

            // sürekli hata verir.
            //throw new Exception("Girilen id değerine ait kullanıcı bulunamamıştır");
    }


    
    
    
    
    
    
    //*********************************2. KISIM 

    // public void DeleteTaskDeveloperId(string[] developerParts)
    // {
    //     // if (developerParts[1] == "dev" && developerParts[0] == "delete")
    //     // {
    //     var task = new Task(); // burada bomboş yeni bir task oluşturmak yanlış. 
    //     if (developerParts[2] == Convert.ToString(task.DeveloperId))
    //     {
    //         task.DeveloperId = Guid.Empty;
    //     }
    //
    //     _developerService.Delete(developerParts);
    //     var tasks = _taskService.GetAll();
    //
    //     foreach (var t in tasks)
    //     {
    //     }
    //     // }
    // }
    // 1. Aşaam
    //ya string arrayi al yada string al içerde parçalaa
    //parçaları valide et if if diye validasyondan geçenmeyenler için error fırlat
    // Errorların custom error oluşturma 
    // bu şekilde crud işlemleri tamamlanacak.

    //2. aşama
    // 1 dev silindiğinde ()
}