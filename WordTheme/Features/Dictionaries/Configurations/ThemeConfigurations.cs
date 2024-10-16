﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WordTheme.Features.Dictionaries.Models;

namespace WordTheme.Features.Dictionaries.Configurations;

public class ThemeConfigurations : IEntityTypeConfiguration<Theme>
{
    public void Configure(EntityTypeBuilder<Theme> builder)
    {
        builder.ToTable("Themes");

        builder.HasKey(th => th.Id);
        
        builder.Property(th => th.Created)
               .HasDefaultValueSql("CURRENT_TIMESTAMP")
               .ValueGeneratedOnAdd();

        builder.Property(th => th.Updated)
               .HasDefaultValueSql("CURRENT_TIMESTAMP")
               .ValueGeneratedOnAddOrUpdate();

        builder.HasMany(th => th.Words)
               .WithOne(w => w.Theme)
               .HasForeignKey(w => w.ThemeId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(th => th.ParentTheme)
               .WithMany(p => p.ChildThemes)
               .HasForeignKey(th => th.ParentThemeId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(th => th.Title).HasMaxLength(128).IsRequired();
        builder.HasIndex(th => th.Title).HasDatabaseName("Theme_Title_Index").IsUnique(false);
    }
}