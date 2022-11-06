using Case2GK20221102.Controllers;
using Case2GK20221102.Entities;

namespace Case2GK20221102.Repository;

public class GenericRepository<T> where T : Document
{
    protected List<T> List;      //add bu listeye ekliyor. Save de hardiskke  kaydediyor.
    // private string _taskFilePath;
    // private string _devFilePath;

       
    public GenericRepository(List<T> list)
    {
        List = list; 
    }

     // SaveDb
     public void SaveDb(string filepath)
     {
        // var saveDbText = json
     }

     public string Add(T data ) //
    {
        List.Add(data);
        return "Data başarılı bir şekilde eklenmiştir.";
    }

    public T? GetById(Guid id)
    {
        return List.FirstOrDefault(x => x.Id == id);
    }

    public void Update(T data)
    {
        
    }

    public string? Delete(Guid id)     // Silinen kullanıcıyı dönmesini düşündüm. 
    {
        var searchId = List.FirstOrDefault(x => x.Id == id);
        if (true)
        {
            
        }
        
        return null;
    }

}