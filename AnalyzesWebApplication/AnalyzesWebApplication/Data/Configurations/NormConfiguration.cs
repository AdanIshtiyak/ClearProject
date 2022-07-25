using AnalyzesWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnalyzesWebApplication.Data.Configurations
{
    public class NormConfiguration : IEntityTypeConfiguration<Norm>
    {
        public void Configure(EntityTypeBuilder<Norm> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
            builder.HasOne(x => x.Anzlyz).WithMany(x => x.Norm).HasForeignKey(x => x.AnalyzId);

            builder.HasData(
                new Norm { Id = 1, Name = "Лейкоциты", ManMin = 1.45, ManMax = 1.86, WManMin = 1.40, WManMax = 1.87, AnalyzId = 1},
                new Norm { Id = 2, Name = "Соль", ManMin = 1.76, ManMax = 2.56, WManMin = 1.80, WManMax = 2.6, AnalyzId = 2 },
                new Norm { Id = 3, Name = "Уровень сахара", ManMin = 60, ManMax = 95, WManMin = 63, WManMax = 98, AnalyzId = 3 });
        }
    }
}
