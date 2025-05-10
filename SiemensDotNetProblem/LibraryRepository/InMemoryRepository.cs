namespace SiemensDotNetProblem.LibraryRepository;

public class InMemoryRepository<T> : IRepository<T> where T : IHasID
{
    
    private readonly Dictionary<int, T> _data = new();
    
    public void Add(T obj)
    {
        if (!_data.ContainsKey(obj.ID))
        {
            _data[obj.ID] = obj;
        }
    }

    public void Update(T obj)
    {
        if (_data.ContainsKey(obj.ID))
        {
            _data[obj.ID] = obj;
        }
    }

    public void Delete(int id)
    {
        _data.Remove(id);
    }

    public T Get(int id)
    {
        _data.TryGetValue(id, out var obj);
        return obj!;
    }

    public List<T> GetAll()
    {
        return new List<T>(_data.Values);
    }
}