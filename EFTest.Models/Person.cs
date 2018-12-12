using System;
using System.Collections.Generic;
using System.Text;

namespace EFTest.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        
        public string FirstName { get; set; } 

        public List<Sandwich> SandwichesEaten { get; set; } = new List<Sandwich>();
    }
}
