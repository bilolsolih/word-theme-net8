namespace WordTheme.Features.Dictionary.Models;

public class WordEntity
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public int DictionaryEntityId { get; set; }
    public required DictionaryEntity DictionaryEntity { get; set; }
    
}