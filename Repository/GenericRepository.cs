namespace Case2GK20221102.Repository;

public class GenericRepository<T>
{
    private List<T> _list;
    private string _taskFilePath;
    private string _devFilePath;

    public GenericRepository(string taskFilePath, string devFilePath, List<T> list)
    {
        _taskFilePath = taskFilePath;
        _devFilePath = devFilePath;
        _list = list;
    }

    public void AddDb(T[] data )
    {
        
    }

    public List<T>? GetById(T id)
    {
        return null; 
    }

    public void UpdateDb(T[] data)
    {
        
    }

    public string? Delete(T id)     // Silinen kullanıcıyı dönmesini düşündüm. 
    {
        return null;
    }

}