using BookCatalog.Features.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] SearchBook request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            var request = new GetBook
            {
                Id = id
            };

            return Ok(await _mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBook request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBook request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var request = new DeleteBook
            {
                Id = id
            };

            return Ok(await _mediator.Send(request));
        }
    }
}
