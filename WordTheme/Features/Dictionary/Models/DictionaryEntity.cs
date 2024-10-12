namespace WordTheme.Features.Dictionary.Models;

public class DictionaryEntity
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public ICollection<WordEntity> Words { get; set; } = [];
    public ICollection<ThemeEntity> Themes { get; set; } = [];
}