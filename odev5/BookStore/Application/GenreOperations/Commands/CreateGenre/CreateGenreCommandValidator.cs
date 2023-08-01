using FluentValidation;

namespace BookStore.Application.GenreOperations.Commands.CreateBook;

public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
{
    public CreateGenreCommandValidator()
    {
        RuleFor(command => command.Model.Name).NotEmpty();
    }
}
