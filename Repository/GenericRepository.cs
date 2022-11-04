using Case2GK20221102.Controllers;
using Case2GK20221102.Entities;

namespace Case2GK20221102.Repository;

public class GenericRepository<T> where T : Document
{
    private List<T> _list;      //add bu listeye ekliyor. Save de hardiskke  kaydediyor.
    // private string _taskFilePath;
    // private string _devFilePath;

       
    public GenericRepository(List<T> list)
    {
        _list = list; 
    }

     // SaveDb
     public void SaveDb(string filepath)
     {
        // var saveDbText = json
     }

     public string Add(T data ) //
    {
        _list.Add(data);
        return "Data başarılı bir şekilde eklenmiştir.";
    }

    public List<T?> GetById(Guid id)
    {
        var searchId= _list.FirstOrDefault(x => x.Id == id);
        return new List<T?> { searchId }; // Emin olamadım bu kısımdan.
    }

    public void Update(T data)
    {
        
    }

    public string? Delete(Guid id)     // Silinen kullanıcıyı dönmesini düşündüm. 
    {
        var searchId = _list.FirstOrDefault(x => x.Id == id);
        if (true)
        {
            
        }
        
        return null;
    }

}