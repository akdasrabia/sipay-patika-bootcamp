using FluentValidation;

namespace BookStore.Application.GenreOperations.Commands.UpdateBook;

public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
{
    public UpdateGenreCommandValidator()
    {
        RuleFor(command => command.GenreId).GreaterThan(0);
    }
}
