using FluentValidation;

namespace BookStore.Application.GenreOperations.Commands.DeleteBook;

public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
{
    public DeleteGenreCommandValidator()
    {
        RuleFor(command => command.GenreId).NotEmpty().GreaterThan(0);
    }
}
