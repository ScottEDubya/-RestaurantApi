using Bogus;
using RestaurantApi.Data;
using RestaurantApi.Models;
using System.Collections.Generic;

namespace RestaurantApi.IntegrationTests.Factories
{
    public class MenuFactory : IFactory<Menu>
    {
        private readonly AppDbContext _db;
        private readonly Randomizer random = new Randomizer();
        public MenuFactory(AppDbContext db)
        {
            _db = db;
        }

        public Menu Create()
        {
            return Insert(Get());
        }

        public Menu Create(Menu entity)
        {
            return Insert(entity);
        }

        public List<Menu> Create(int count)
        {
            var menus = new List<Menu>();
            for(var x = 0; x < count; x++)
            {
                menus.Add(Insert(Get()));
            }
            return menus;
        }

        public Menu Get()
        {
            return new Faker<Menu>()
                .RuleFor(u => u.Name, (r, f) => r.Company.CompanyName())
                .RuleFor(u => u.Description, (r, f) => random.String(0, 250));
        }

        private Menu Insert(Menu m)
        {
            _db.Menus.Add(m);
            _db.SaveChanges();
            return m;
        }
    }
}
