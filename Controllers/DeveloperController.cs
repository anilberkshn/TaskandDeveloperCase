using Case2GK20221102.Entities;
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
    //
    // Developer service add methodu
    // Add,developer,name,surname,departmant
    //     DeveloperService Update Method
    // Update,developer,Id,name,surname,department
    //     DeveloperService Delete Method
    // Delete,Developer,Id
    //     
    public void AddDeveloper(string[] developerParts) // Add,developer,name,surname,departmant
    {
        //0-1 ve bir partı routerda yönlenmesi gerekli diye düşündüm. 
        // todo: servis kısmında add de oluşturulacak nesne için buradan doğru gitmesi
        // if (developerParts[2] == null || developerParts[3] == null )
        // {
        //     throw new Exception("ad veya  soyad boş olamaz.");
        // }
        // else 
        if (developerParts[4] is not ("0" or "1" or "2"))
        {
            throw new Exception("Developer Departmanı 0,1,2 olmalıdır.");
        }
        else
        {
            _developerService.Add(developerParts);
        }
    }

    public void UpdateDeveloper(string[] developerParts)
    {
        
    }

    public void DeleteDeveloper(string[] developerParts) // Delete,Developer,Id
    {
        // try
        // {
            int sayac = 0; 
            var developers = _developerService.GetAll();
            foreach (var dev in developers)
            {
                if (dev.Id == Guid.Parse(developerParts[2]))
                {
                    _developerService.Delete(developerParts);
                    sayac++;
                }
            }

            if (sayac == 0)
            {
                throw new Exception("Girilen id değerine ait kullanıcı bulunamamıştır");
            }
        // }
        // catch (Exception )
        // {
        //     Console.WriteLine("Girilen id değerine ait kullanıcı bulunamamıştır");
        //     throw;
        // }
       
        // sürekli hata verir.
        //throw new Exception("Girilen id değerine ait kullanıcı bulunamamıştır");
    }


    public Developer GetDeveloper(string id)
    {
        // todo: Ne yapacağını tekrar düşüneceğim, return hata vermesin diye yazdım. 
        return _developerService.Get(id);
    }


    public void DeleteTaskDeveloperId(string[] developerParts)
    {
        // if (developerParts[1] == "dev" && developerParts[0] == "delete")
        // {
        var task = new Task(); // burada bomboş yeni bir task oluşturmak yanlış. 
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