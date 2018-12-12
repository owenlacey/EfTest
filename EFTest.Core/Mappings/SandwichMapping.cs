using System;
using System.Collections.Generic;
using System.Text;
using EFTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFTest.Core.Mappings
{
    public class SandwichMapping : IEntityTypeConfiguration<Sandwich>
    {
        public void Configure(EntityTypeBuilder<Sandwich> builder)
        {
            builder.HasOne(s => s.Order)
                .WithMany(o => o.Sandwiches)
                .HasForeignKey(s => s.OrderId);

            builder.HasOne(s => s.Person)
                .WithMany(o => o.SandwichesEaten)
                .HasForeignKey(s => s.PersonId);

            builder.HasIndex(s => new { s.OrderId, s.PersonId })
                .IsUnique();
        }
    }
}
