using Microsoft.EntityFrameworkCore;
using WordTheme.Features.Dictionaries.Configurations;
using WordTheme.Features.Dictionaries.Models;

namespace WordTheme.Features.Dictionaries.Data;

public class DictionaryContext(DbContextOptions<DictionaryContext> options) : DbContext(options)
{
    public DbSet<Dictionary> Dictionaries { get; set; }
    public DbSet<Word> Words { get; set; }
    public DbSet<Theme> Themes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new DictionaryConfigurations());
        modelBuilder.ApplyConfiguration(new WordConfigurations());
    }
}