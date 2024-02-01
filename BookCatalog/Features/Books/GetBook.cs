using MediatR;

namespace BookCatalog.Features.Books;

public class GetBook : IRequest<GetBookDto>
{
    public long Id { get; set; }
}

