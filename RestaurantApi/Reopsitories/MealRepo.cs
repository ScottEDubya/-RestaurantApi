using System;
using System.Collections.Generic;
using System.Linq;
using RestaurantApi.Data;
using RestaurantApi.Models;

namespace RestaurantApi.Reopsitories
{
    public class MealRepo : IMealRepo
    {
        public AppDbContext _db { get; set; }

        public IEnumerable<Meal> Get()
        {
            return _db.Meals.OrderBy(c => c.Name).ToList();
        }

        public bool TryGet(int id, out Meal entity)
        {
            entity = _db.Meals.SingleOrDefault(e => e.Id == id);
            if (entity == null)
            {
                return false;
            }
            return true;
        }
    }
}
