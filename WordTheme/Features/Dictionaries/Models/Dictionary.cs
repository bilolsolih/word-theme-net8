namespace WordTheme.Features.Dictionaries.Models;

public class Dictionary
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public ICollection<Word> Words { get; set; } = [];
    public ICollection<Theme> Themes { get; set; } = [];
    
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}