using FluentValidation;
namespace BookCatalog.Features.Books;

public class UpdateBookValidator : AbstractValidator<UpdateBook>
{
    public UpdateBookValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.CategoryId).NotEmpty().OverridePropertyName("Category");
        RuleFor(x => x.PublishDateUtc).NotEmpty();

    }
}