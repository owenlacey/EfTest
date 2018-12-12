using System.Data.Entity.ModelConfiguration;
using EFTest.Models;

namespace EFTest.Framework.Mappings
{
    public class PersonMapping: EntityTypeConfiguration<Person>
    {
        public PersonMapping()
        {
            ToTable("People");

            Property(p => p.FirstName)
                .HasMaxLength(50);
        }
    }
}
