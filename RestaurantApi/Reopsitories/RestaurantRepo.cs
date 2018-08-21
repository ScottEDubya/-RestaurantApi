using System;
using System.Collections.Generic;
using System.Linq;
using RestaurantApi.Data;
using RestaurantApi.Models;
using RestaurantApi.Reopsitories.Interfaces;

namespace RestaurantApi.Reopsitories
{
    public class RestaurantRepo : IRestaurantRepo
    {
        public AppDbContext _db { get; set; }

        public RestaurantRepo(AppDbContext ctx)
        {
            _db = ctx;
        }

        public IEnumerable<Restaurant> Get()
        {
            try
            {
                return _db.Restaurants.OrderBy(c => c.Name).ToList();
            }
            catch (NullReferenceException)
            {
                return new List<Restaurant>();
            }
        }

        public bool TryGet(int id, out Restaurant entity)
        {
            entity = _db.Restaurants.SingleOrDefault(e => e.Id == id);
            if (entity == null)
            {
                return false;
            }
            return true;
        }

        public Restaurant Create(Restaurant entity)
        {
            if(_db.Menus.FirstOrDefault(x => x.Id == entity.Id) == null)
            {
                return null;
            }
            _db.Restaurants.Add(entity);
            _db.SaveChanges();
            return entity;
        }

        public Restaurant Update(int id, Restaurant entity)
        {
            _db.Restaurants.Update(entity);
            _db.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var deleteMe = Get().FirstOrDefault(e => e.Id == id);
            if (deleteMe == null)
            {
                return false;
            }
            _db.Restaurants.Remove(deleteMe);
            _db.SaveChanges();
            return true;
        }
    }
}