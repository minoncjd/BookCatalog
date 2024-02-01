using MediatR;

namespace BookCatalog.Features.Books
{
    public class DeleteBook : IRequest<int>
    {
        public long Id { get; set; }
    }
}
