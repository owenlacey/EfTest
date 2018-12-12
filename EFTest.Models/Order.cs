using System;
using System.Collections.Generic;
using System.Text;

namespace EFTest.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime DueDate { get; set; }

        public List<Sandwich> Sandwiches { get; set; } = new List<Sandwich>();
    }
}
