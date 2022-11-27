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
            throw new ValidationErrorException();
        }
        if (developerParts[3].Length < 2) 
        { 
            throw new ValidationErrorException();
        }
        if (developerParts[4] is not ("0" or "1" or "2"))
        {
            throw new ValidationErrorException();
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
            throw new ValidationErrorException();
        }
        else if (developerParts[3].Length < 2)
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

    public bool DeleteDeveloper(string[] developerParts) // Delete,Developer,DeveloperId
    {
        if (_developerService.Delete(developerParts)) 
        {
            UnassignDeveloperOnTask(developerParts);   
        }

        return _developerService.Delete(developerParts);
        //TODO: DELETE işlemi kaç kez yapılıyor? neden?
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
    
     
     
     
    //  1. Aşaam
    // ya string arrayi al yada string al içerde parçalaa
    // parçaları valide et if if diye validasyondan geçenmeyenler için error fırlat
    //  Errorların custom error oluşturma 
    //  bu şekilde crud işlemleri tamamlanacak.

    //2. aşama
    // 1 dev silindiğinde ()
}










//********************** Delete metot denemeler
// public bool DeleteDeveloper(string[] developerParts) // Delete,Developer,Id
// {
//     // try
//     // {
//     // int sayac = 0; 
//     // var developers = _developerService.GetAll();
//     // foreach (var dev in developers)
//     // {
//     //     if (dev.Id == Guid.Parse(developerParts[2]))
//     //     {
//     //         _developerService.Delete(developerParts);
//     //         sayac++;
//     //     }
//     // }
//     //
//     // if (sayac == 0)
//     // {
//     //     throw new Exception("Girilen id değerine ait kullanıcı bulunamamıştır");
//     // }
//
//     return _developerService.Delete(developerParts); 
//     //// Her zaman true dönecek. 
//
//     // }
//     // catch (Exception )
//     // {
//     //     Console.WriteLine("Girilen id değerine ait kullanıcı bulunamamıştır");
//     //     throw;
//     // }
//
//     // sürekli hata verir.
//     //throw new Exception("Girilen id değerine ait kullanıcı bulunamamıştır");
// }