using Case2GK20221102.Entities;

namespace Case2GK20221102.Repository;

public class GenericRepository<T> where T : Document
{
    private readonly List<T> _list;      //add bu listeye ekliyor. Save de hardiskke  kaydediyor.
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

    public T? GetById(Guid id)
    {
        return _list.FirstOrDefault(x => x.Id == id);
    }

    public void Update(T data)
    {
        
        
    }

    public void Delete(Guid id)  
    {
       var searchId =  _list.FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException();
      
        _list.Remove(searchId);
       
    }

}