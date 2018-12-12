using System;
using System.Collections.Generic;

namespace EFTest.Models
{
    public class Sandwich
    {
        public int SandwichId { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public List<SandwichIngredient> Ingredients { get; set; } = new List<SandwichIngredient>();
    }
}
