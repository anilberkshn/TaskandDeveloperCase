using Case2GK20221102.Entities;
using Newtonsoft.Json;

namespace Case2GK20221102.Repository;

public class GenericRepository<T> where T : Document 
{
    private readonly List<T> _list;      //add bu listeye ekliyor. Save de hardiskke  kaydediyor.
   
    public GenericRepository(List<T> list)
    {
        _list = list; 
    }

     // SaveDb
     public void SaveDb(string filePath)
     {
        // var saveDbText = json
        var jsonText = JsonConvert.SerializeObject(_list, Formatting.Indented);
        File.WriteAllText(filePath, jsonText);
     }

     public bool  Add(T data ) //guid 
    {
        _list.Add(data);
        return true;
    }

    public T? GetById(Guid id)
    {
        return _list.FirstOrDefault(x => x.Id == id);
    }
                    
    public bool Update(T data) //List<T?>  bool 
    {
        var searchId = _list.FirstOrDefault(x => x.Id == data.Id) ?? throw new InvalidOperationException();
        _list.Remove(searchId);
        _list.Add(data);
        return true;
    }

    public bool Delete(Guid id)  //bool
    {
        return _list.Remove(_list.FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException());
    }

    public List<T> GetAll()
    {
        return _list;
    }

}