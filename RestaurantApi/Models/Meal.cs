using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantApi.Models
{
    public class Meal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [Range(0, int.MaxValue)]
        public int? Calories { get; set; }

        [Range(0, int.MaxValue)]
        public int? Carbohydrates { get; set; }

        [Range(0, int.MaxValue)]
        public int? Sugar { get; set; }

        [Range(0, int.MaxValue)]
        public int? Protein { get; set; }
    }
}
