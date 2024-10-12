using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WordTheme.Features.Dictionary.Models;

namespace WordTheme.Features.Dictionary.Configurations;

public class DictionaryConfigurations : IEntityTypeConfiguration<DictionaryEntity>
{
    public void Configure(EntityTypeBuilder<DictionaryEntity> builder)
    {
        builder.HasKey(d => d.Id);

        builder.HasMany(d => d.Words)
            .WithOne(w => w.DictionaryEntity)
            .HasForeignKey(w => w.DictionaryEntity);
        
        builder.HasMany(d => d.Themes)
            .WithOne(th => th.DictionaryEntity)
            .HasForeignKey(th => th.DictionaryEntityId);
    }
}