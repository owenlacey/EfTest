using System;
using System.Collections.Generic;
using System.Text;
using EFTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFTest.Core.Mappings
{
    public class SandwichIngredientMapping : IEntityTypeConfiguration<SandwichIngredient>
    {
        public void Configure(EntityTypeBuilder<SandwichIngredient> builder)
        {
        }
    }
}
