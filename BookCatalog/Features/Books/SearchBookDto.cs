namespace BookCatalog.Features.Books;

public class SearchBookDto
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime PublishDateUtc { get; set; }

}

public class SearchBookResultDto
{
    public List<SearchBookDto>? Books { get; set; }
    public int? Count { get; set; }
}

