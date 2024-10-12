using Microsoft.EntityFrameworkCore;
using WordTheme.Features.Dictionaries.Data;
using WordTheme.Features.Dictionaries.DTOs;
using WordTheme.Features.Dictionaries.Models;

namespace WordTheme.Features.Dictionaries.Repositories;

public class DictionaryRepository(DictionaryContext context)
{
    public async Task<List<DictionaryListDto>> GetAllDictionariesAsync()
    {
        return await context.Dictionaries
                            .Select(d => new DictionaryListDto { Id = d.Id, Title = d.Title, WordsCount = d.Words.Count })
                            .ToListAsync();
    }

    public async Task<Dictionary?> GetDictionaryByIdAsync(int id)
    {
        return await context.Dictionaries.FindAsync(id);
    }

    public async Task AddDictionaryAsync(Dictionary dictionary)
    {
        context.Dictionaries.Add(dictionary);
        await context.SaveChangesAsync();
    }

    public async Task UpdateDictionaryAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task DeleteDictionaryAsync(Dictionary dictionary)
    {
        context.Dictionaries.Remove(dictionary);
        await context.SaveChangesAsync();
    }
}