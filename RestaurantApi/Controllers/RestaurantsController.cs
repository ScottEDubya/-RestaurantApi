using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RestaurantApi.Models;
using RestaurantApi.Reopsitories.Interfaces;

namespace RestaurantApi.Controllers
{
    [Route("api/restaurants")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantRepo _repository;

        public RestaurantsController(IRestaurantRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Restaurant> Get()
        {
            return _repository.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Restaurant> Get(int id)
        {
            if (!_repository.TryGet(id, out Restaurant restaurant))
            {
                return NotFound();
            }
            return restaurant;
        }

        [HttpPost]
        public IActionResult Post(Restaurant restaurant)
        {
            var createdRestaurant = _repository.Create(restaurant);
            if (createdRestaurant != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult<Restaurant> Put(int id, Restaurant entity)
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
