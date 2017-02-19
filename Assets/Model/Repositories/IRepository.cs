using System.Collections.Generic;

namespace Assets.Model.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        bool Update(T obj);
        bool Delete(int id);
        bool Delete(T obj);
    }
}
