using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DictionaryEntity = WordTheme.Features.Dictionaries.Models.Dictionary;

namespace WordTheme.Features.Dictionaries.Configurations;

public class DictionaryConfigurations : IEntityTypeConfiguration<DictionaryEntity>
{
    public void Configure(EntityTypeBuilder<DictionaryEntity> builder)
    {
        builder.ToTable("Dictionaries");
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Title).HasMaxLength(128).IsRequired();

        builder.HasMany(d => d.Words)
               .WithOne(w => w.Dictionary)
               .HasForeignKey(w => w.DictionaryId);

        builder.HasMany(d => d.Themes)
               .WithOne(th => th.Dictionary)
               .HasForeignKey(th => th.DictionaryId);
    }
}