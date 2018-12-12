using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;
using EFTest.Models;

namespace EFTest.Framework.Mappings
{
    public class SandwichMapping : EntityTypeConfiguration<Sandwich>
    {
        public SandwichMapping()
        {
            HasRequired(s => s.Order)
                .WithMany(o => o.Sandwiches)
                .HasForeignKey(s => s.OrderId);

            HasRequired(s => s.Person)
                .WithMany(o => o.SandwichesEaten)
                .HasForeignKey(s => s.PersonId);

            HasIndex(s => new { s.OrderId, s.PersonId })
                .IsUnique();
        }
    }
}
