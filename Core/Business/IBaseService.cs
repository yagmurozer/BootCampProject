

namespace Core.Business;

public interface IBaseService<T> where T : class
{
    void Add(T entity);
    void Delete(int id);
    List<T> GetAll();
    T Get(int id);
    void Update(T entity);

}
