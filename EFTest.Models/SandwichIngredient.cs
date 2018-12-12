using EFTest.Models.Enums;

namespace EFTest.Models
{
    public class SandwichIngredient
    {
        public int SandwichIngredientId { get; set; }

        public int SandwichId { get; set; }
        public virtual Sandwich Sandwich { get; set; }

        public Ingredient Ingredient { get; set; }
    }
}