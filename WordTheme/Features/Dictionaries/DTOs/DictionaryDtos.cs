namespace WordTheme.Features.Dictionaries.DTOs;

public class DictionaryListDto
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required int WordsCount { get; set; }
}

public class DictionaryMinimalDto
{
    public required int Id { get; set; }
    public required string Title { get; set; }
}
public class DictionaryCreateDto
{
    public required string Title { get; set; }
}

public class DictionaryUpdateDto
{
    public required string Title { get; set; }
}