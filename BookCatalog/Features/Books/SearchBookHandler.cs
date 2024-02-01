using BookCatalog.Model;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Features.Books;

public class SearchBookHandler : IRequestHandler<SearchBook, SearchBookResultDto>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public SearchBookHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SearchBookResultDto> Handle(SearchBook request, CancellationToken cancellationToken)
    {
        var query = _context.Books.OrderByDescending(m => m.Id).AsQueryable();

        if (!string.IsNullOrEmpty(request.Title))
        {
            query = query.Where(x =>
                x.Title.Contains(request.Title)
            );
        }

        var count = await query.CountAsync(cancellationToken);

        if (request.Skip.HasValue)
        {
            query = query.Skip(request.Skip.Value);
        }

        if (request.Take.HasValue)
        {
            query = query.Take(request.Take.Value);
        }

        var models = await query.ToListAsync(cancellationToken);
        var dtos = _mapper.Map<List<SearchBookDto>>(models);

        var result = new SearchBookResultDto
        {
            Books = dtos,
            Count = count
        };

        return result;
    }
}

