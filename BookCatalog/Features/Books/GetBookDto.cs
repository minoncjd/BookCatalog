namespace BookCatalog.Features.Books;

public class GetBookDto
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime PublishDateUtc { get; set; }

}

