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
    
    public void Add(T[] data ) //
    {
       // C:\Users\asuspc\RiderProjects\ABerkSolution1\Case2GK20221102\DeveloperDb.txt
    }

    public List<T>? GetById(Guid id)
    {

        _list.FirstOrDefault(x => x.Id == id);
        return null; 
    }

    public void Update(T[] data)
    {
        
    }

    public string? Delete(T id)     // Silinen kullanıcıyı dönmesini düşündüm. 
    {
        return null;
    }

}