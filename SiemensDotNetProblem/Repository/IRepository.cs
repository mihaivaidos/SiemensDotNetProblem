using SiemensDotNetProblem.Model;

namespace SiemensDotNetProblem.Repository
{
    public interface IRepository<T> where T : IHasID
    {
        void Add(T obj);
        
        T Get(int id);
        
        void Update(T obj);
        
        void Delete(int id);
        
        List<T> GetAll();
    }
}