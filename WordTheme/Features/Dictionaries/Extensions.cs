using WordTheme.Features.Dictionaries.Data;
using WordTheme.Features.Dictionaries.Repositories;
using WordTheme.Features.Dictionaries.Services;

namespace WordTheme.Features.Dictionaries;

public static class Extensions
{
    public static void RegisterDictionariesFeature(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DictionaryService>();
        services.AddScoped<DictionaryRepository>();
        
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddNpgsql<DictionaryContext>(connectionString);
    }
}