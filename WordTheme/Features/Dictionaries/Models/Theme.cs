namespace WordTheme.Features.Dictionaries.Models;

public class Theme
{
    public int Id { get; set; }
    public required string Title { get; set; }

    public int? ParentThemeId { get; set; }
    public Theme? ParentTheme { get; set; }
    public int DictionaryId { get; set; }
    public required Dictionary Dictionary { get; set; }

    public ICollection<Theme>? ChildThemes { get; set; } = [];
    public ICollection<Word> Words { get; set; } = [];
    
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}