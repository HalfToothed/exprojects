using Account.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.Api
{
    public class Configurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired(false);
            builder.Property(x => x.Standard).IsRequired();
            builder.Property(x => x.School).IsRequired(false);
        }
    }

    public class DatabaseConfiguration : IEntityTypeConfiguration<Database>
    {
        public void Configure(EntityTypeBuilder<Database> builder)
        {
            builder.ToTable("Databases");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired(false);
            builder.Property(x => x.ConnectionString).IsRequired(false);
        }
    }
}
