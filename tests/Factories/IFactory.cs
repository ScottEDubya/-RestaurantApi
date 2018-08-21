using System.Collections.Generic;

namespace RestaurantApi.IntegrationTests.Factories
{
    public interface IFactory<T>
    {
        T Get();
        T Create();
        T Create(T entity);
        List<T> Create(int count);
    }
}
