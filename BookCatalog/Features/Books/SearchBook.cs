using MediatR;
namespace BookCatalog.Features.Books;

public class SearchBook : IRequest<SearchBookResultDto>
{
    public string? Title { get; set; }
    public int? Skip { get; set; }
    public int? Take { get; set; }
}

