using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using RestaurantApi.Models;
using RestaurantApi.Reopsitories;

namespace RestaurantApi.Controllers
{
    [Route("api/meals")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly IMealRepo _repository;

        public MealsController(IMealRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Meal> Get()
        {
            return _repository.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Meal> Get(int id)
        {
            if (!_repository.TryGet(id, out Meal meal))
            {
                return NotFound();
            }
            return meal;
        }

        [HttpPost]
        public IActionResult Post(Meal meal)
        {
            var createdMeal = _repository.Create(meal);
            if(createdMeal != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult<Meal> Put(int id, Meal entity)
        {
            _repository.Update(id, entity);

            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(_repository.Delete(id))
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}