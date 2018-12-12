using EFTest.Core.Mappings;
using Microsoft.EntityFrameworkCore;

namespace EFTest.Core
{
    /// <summary>
    /// For how to use in tangent with production, see https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory
    /// </summary>
    public class SandwichContext: DbContext
    {
        public SandwichContext(DbContextOptions<SandwichContext> options)
            : base(options)
        {
            //For use in unit tests
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SandwichMapping());
            modelBuilder.ApplyConfiguration(new PersonMapping());
            modelBuilder.ApplyConfiguration(new SandwichIngredientMapping());
            modelBuilder.ApplyConfiguration(new OrderMapping());
        }
    }
}
