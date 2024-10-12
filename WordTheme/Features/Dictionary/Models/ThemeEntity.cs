namespace WordTheme.Features.Dictionary.Models;

public class ThemeEntity
{
    public int Id { get; set; }

    public int DictionaryEntityId { get; set; }
    public required DictionaryEntity DictionaryEntity { get; set; }

    public int? ParentThemeId { get; set; }
    public ThemeEntity? ParentTheme { get; set; }

    public ICollection<ThemeEntity>? ChildThemes { get; set; } = [];

    public required string Title { get; set; }

    public ICollection<WordEntity> Words { get; set; } = [];
}