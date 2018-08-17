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
        private readonly MealRepo _repository;

        public MealsController(MealRepo repository)
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
        public void Post([FromBody] string value)
        {
            Console.WriteLine("post");
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            Console.WriteLine("put");
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Console.WriteLine("delete");
        }
    }
}