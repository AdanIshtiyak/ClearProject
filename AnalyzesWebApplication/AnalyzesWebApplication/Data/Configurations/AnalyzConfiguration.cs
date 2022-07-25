using AnalyzesWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnalyzesWebApplication.Data.Configurations
{
    public class AnalyzConfiguration : IEntityTypeConfiguration<Analyz>
    {
        public void Configure(EntityTypeBuilder<Analyz> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();

            builder.HasData(
                new Analyz { Id = 1, Name = "OAK"},
                new Analyz { Id = 2, Name = "OAM" },
                new Analyz { Id = 3, Name = "Сахар" });
        }
    }
}
