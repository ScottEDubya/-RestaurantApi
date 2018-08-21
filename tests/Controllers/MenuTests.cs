using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Controllers;
using RestaurantApi.IntegrationTests.Factories;
using RestaurantApi.Models;
using RestaurantApi.Reopsitories;
using tests;
using Xunit;

namespace RestaurantApi.IntegrationTests.Controllers
{
    public class MenuTests : TestFixture
    {
        const string ENDPOINT = "/api/menus";
        private readonly IFactory<Menu> _factory;
        private readonly MenusController _controller;
        public MenuTests()
        {
            _factory = new MenuFactory(_db);
            _controller = new MenusController(new MenuRepo(_db));
        }

        [Fact]
        public void GetMenus_ReturnsAllMenus()
        {
            //Arrange
            _db.Menus.RemoveRange();
            _db.SaveChanges();
            var newMenus = _factory.Create(3);

            // Act
            var menus = _controller.Get();

            // Assert
            Assert.Contains(newMenus[0], menus);
            Assert.Contains(newMenus[1], menus);
            Assert.Contains(newMenus[2], menus);
        }

        [Fact]
        public void GetMenu_ReturnsMenu()
        {
            //Arrange
            var newMenu = _factory.Create();

            //Act
            var menu = _controller.Get(newMenu.Id).Value;

            //Assert
            Assert.Equal(newMenu, menu);
        }

        [Fact]
        public void PostMenu_ReturnsOk()
        {
            //Arrange
            var newMenu = _factory.Get();

            //Act
            var resp = _controller.Post(newMenu);

            //Assert
            //should return createdAt TODO
            Assert.IsType<OkResult>(resp);
        }

        [Fact]
        public void Put_UpdatesMenu()
        {
            //Arrange
            var newMenu = _factory.Create();
            var updated = _factory.Get();

            // Act
            var menu = _controller.Put(newMenu.Id, updated).Value;

            // Assert
            Assert.Equal(updated.Name, menu.Name);
            Assert.Equal(updated.Description, menu.Description);
        }
    }
}