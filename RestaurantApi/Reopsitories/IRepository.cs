using System.Collections.Generic;

namespace RestaurantApi.Reopsitories
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();

        bool TryGet(int id, out T entity);
    }
}
