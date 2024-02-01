using BookCatalog.Model;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Features.Books;

public class UpdateBookHandler : IRequestHandler<UpdateBook, int>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public UpdateBookHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<int> Handle(UpdateBook request, CancellationToken cancellationToken)
    {
        var model = await _context.Books.FirstOrDefaultAsync(m => m.Id == request.Id);

        if (model == null)
        {
            throw new KeyNotFoundException("Book not found");
        }

        _mapper.Map(request, model);
        _context.Update(model);

        await _context.SaveChangesAsync(cancellationToken);

        return model.Id;
    }
}

