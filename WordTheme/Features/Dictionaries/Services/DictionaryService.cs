using WordTheme.Features.Dictionaries.DTOs;
using WordTheme.Features.Dictionaries.Models;
using WordTheme.Features.Dictionaries.Repositories;

namespace WordTheme.Features.Dictionaries.Services;

public class DictionaryService(DictionaryRepository repository)
{
    public async Task<List<DictionaryListDto>> GetAllDictionariesAsync()
    {
        return await repository.GetAllDictionariesAsync();
    }

    public async Task<DictionaryMinimalDto> CreateDictionaryAsync(DictionaryCreateDto dictionaryDto)
    {
        var newDictionary = new Dictionary { Title = dictionaryDto.Title };
        await repository.AddDictionaryAsync(newDictionary);

        return new DictionaryMinimalDto { Id = newDictionary.Id, Title = newDictionary.Title };
    }

    public async Task<DictionaryMinimalDto?> UpdateDictionaryAsync(int id, DictionaryUpdateDto dictionaryDto)
    {
        var existingDictionary = await repository.GetDictionaryByIdAsync(id);
        if (existingDictionary == null)
        {
            return null;
        }

        existingDictionary.Title = dictionaryDto.Title;
        await repository.UpdateDictionaryAsync();

        return new DictionaryMinimalDto { Id = existingDictionary.Id, Title = existingDictionary.Title };
    }

    public async Task<bool> DeleteDictionaryAsync(int id)
    {
        var dictionary = await repository.GetDictionaryByIdAsync(id);
        if (dictionary == null) return false;

        await repository.DeleteDictionaryAsync(dictionary);
        return true;
    }
}