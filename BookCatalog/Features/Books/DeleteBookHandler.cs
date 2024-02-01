
using BookCatalog.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Features.Books
{
    public class DeleteBookHandler : IRequestHandler<DeleteBook, int>
    {
        private readonly AppDbContext _context;

        public DeleteBookHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteBook request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FirstOrDefaultAsync(m => m.Id == request.Id);

            if (book == null)
            {
                throw new KeyNotFoundException("Book not found");
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }
    }
}
