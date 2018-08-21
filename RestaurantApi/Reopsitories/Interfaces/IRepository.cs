using System.Collections.Generic;

namespace RestaurantApi.Reopsitories.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();

        bool TryGet(int id, out T entity);

        T Create(T entity);

        T Update(int id, T entity);

        bool Delete(int id);
    }
}
