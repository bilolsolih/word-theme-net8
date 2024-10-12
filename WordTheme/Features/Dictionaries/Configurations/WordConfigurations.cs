using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WordTheme.Features.Dictionaries.Models;

namespace WordTheme.Features.Dictionaries.Configurations;

public class WordConfigurations : IEntityTypeConfiguration<Word>
{
    public void Configure(EntityTypeBuilder<Word> builder)
    {
        builder.ToTable("Words");
        builder.HasKey(w => w.Id);

        builder.Property(w => w.Title).HasMaxLength(512).IsRequired();
        builder.HasIndex(w => w.Title).HasDatabaseName("Word_Title_Index");
    }
}