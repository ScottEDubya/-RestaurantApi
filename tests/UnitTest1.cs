using RestaurantApi.Models;
using Xunit;

namespace tests
{
    public class UnitTest1
    {
        [Fact]
        public void CanCreateIngredientObject()
        {
            var obj = new Ingredient
            {
                Calories = 123,
                Sugar = 10,
                Carbohydrates = 10,
                Description = "not mine",
                Name = "yours",
                Protein = 14
            };

            Assert.Equal(123, obj.Calories);
        }
    }
}
