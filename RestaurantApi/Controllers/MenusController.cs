using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RestaurantApi.Models;
using RestaurantApi.Reopsitories.Interfaces;

namespace RestaurantApi.Controllers
{
    [Route("api/menus")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMenuRepo _repository;

        public MenusController(IMenuRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Menu> Get()
        {
            return _repository.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Menu> Get(int id)
        {
            if (!_repository.TryGet(id, out Menu menu))
            {
                return NotFound();
            }
            return menu;
        }

        [HttpPost]
        public IActionResult Post(Menu menu)
        {
            var createdMenu = _repository.Create(menu);
            if (createdMenu != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult<Menu> Put(int id, Menu entity)
        {
            _repository.Update(id, entity);

            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_repository.Delete(id))
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
