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

        public MealRepo(AppDbContext ctx)
        {
            _db = ctx;
        }

        public IEnumerable<Meal> Get()
        {
            try
            {
                return _db.Meals.OrderBy(c => c.Name).ToList();
            }
            catch(NullReferenceException)
            {
                return new List<Meal>();
            }
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

        public Meal Create(Meal entity)
        {
            _db.Meals.Add(entity);
            _db.SaveChanges();
            return entity;
        }

        public Meal Update(int id, Meal entity)
        {
            _db.Meals.Update(entity);
            _db.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var deleteMe = Get().FirstOrDefault(e => e.Id == id);
            if(deleteMe == null)
            {
                return false;
            }
            _db.Meals.Remove(deleteMe);
            _db.SaveChanges();
            return true;
        }
    }
}
