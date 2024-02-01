using BookCatalog.Model;
using MapsterMapper;
using MediatR;

namespace BookCatalog.Features.Books;

public class CreateBookHandler : IRequestHandler<CreateBook, int>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CreateBookHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateBook request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<Book>(request);
        await _context.AddAsync(model);
        await _context.SaveChangesAsync(cancellationToken);

        return model.Id;
    }
}

