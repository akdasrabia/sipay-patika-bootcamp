using FluentValidation;

namespace BookStore.BookOperations.GetBook;

public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
{
    public GetBookDetailQueryValidator()
    {
        RuleFor(command => command.BookId).NotEmpty().GreaterThan(0);
    }
}
