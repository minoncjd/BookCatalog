using BookCatalog.Model;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Features.Books;

public class GetBookHandler : IRequestHandler<GetBook, GetBookDto>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetBookHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetBookDto> Handle(GetBook request, CancellationToken cancellationToken)
    {
        var model = await _context.Books.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

        if (model == null)
        {
            throw new KeyNotFoundException("Book not found");
        }

        var dto = _mapper.Map<GetBookDto>(model);

        return dto;
    }
}

