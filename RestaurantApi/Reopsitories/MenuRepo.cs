using System;
using System.Collections.Generic;
using System.Linq;
using RestaurantApi.Data;
using RestaurantApi.Models;
using RestaurantApi.Reopsitories.Interfaces;

namespace RestaurantApi.Reopsitories
{
    public class MenuRepo : IMenuRepo
    {
        public AppDbContext _db { get; set; }

        public MenuRepo(AppDbContext ctx)
        {
            _db = ctx;
        }

        public IEnumerable<Menu> Get()
        {
            try
            {
                return _db.Menus.OrderBy(c => c.Name).ToList();
            }
            catch (NullReferenceException)
            {
                return new List<Menu>();
            }
        }

        public bool TryGet(int id, out Menu entity)
        {
            entity = _db.Menus.SingleOrDefault(e => e.Id == id);
            if (entity == null)
            {
                return false;
            }
            return true;
        }

        public Menu Create(Menu entity)
        {
            _db.Menus.Add(entity);
            _db.SaveChanges();
            return entity;
        }

        public Menu Update(int id, Menu entity)
        {
            if(!TryGet(id, out Menu entityToUpdate))
            {
                return null;
            }
            //TODO: replace with automapper
            entityToUpdate.Name = entity.Name;
            entityToUpdate.Description = entity.Description;
            //End TODO
            _db.Menus.Update(entityToUpdate);
            _db.SaveChanges();
            return entityToUpdate;
        }

        public bool Delete(int id)
        {
            var deleteMe = Get().FirstOrDefault(e => e.Id == id);
            if (deleteMe == null)
            {
                return false;
            }
            _db.Menus.Remove(deleteMe);
            _db.SaveChanges();
            return true;
        }
    }
}