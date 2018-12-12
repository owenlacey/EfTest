using System.Data.Common;
using System.Data.Entity;
using EFTest.Framework.Mappings;

namespace EFTest.Framework
{
    public class SandwichContext: DbContext
    {
        public SandwichContext(DbConnection existingConnection) : base(existingConnection, true)
        {
            //For use in unit tests
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SandwichMapping());
            modelBuilder.Configurations.Add(new PersonMapping());
            modelBuilder.Configurations.Add(new SandwichIngredientMapping());
            modelBuilder.Configurations.Add(new OrderMapping());
        }
    }
}
