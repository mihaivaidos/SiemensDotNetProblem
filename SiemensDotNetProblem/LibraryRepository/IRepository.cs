namespace SiemensDotNetProblem.LibraryRepository;

public interface IRepository<T> where T : IHasID
{
    void Add(T obj);
    void Update(T obj);
    void Delete(int id);
    T Get(int id);
    List<T> GetAll();
    
}