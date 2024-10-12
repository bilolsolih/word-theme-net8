namespace WordTheme.Features.Dictionaries.Models;

public class Word
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public int DictionaryId { get; set; }
    public int ThemeId { get; set; }
    public required Dictionary Dictionary { get; set; }
    public required Theme Theme { get; set; }
    
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}