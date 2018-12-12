using EFTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFTest.Core.Mappings
{
    public class PersonMapping: IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(p => p.FirstName)
                .HasDefaultValue("Adam");

            //No one can share a name with someone else, unless they're called Adam
            builder.HasIndex(p => p.FirstName)
                .IsUnique()
                .HasFilter("FirstName <> 'Adam'");
        }
    }
}
