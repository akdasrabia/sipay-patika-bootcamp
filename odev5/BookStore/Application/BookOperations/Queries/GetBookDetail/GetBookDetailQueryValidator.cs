﻿using FluentValidation;

namespace BookStore.Application.BookOperations.Queries.GetBookDetail;

public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
{
    public GetBookDetailQueryValidator()
    {
        RuleFor(command => command.BookId).NotEmpty().GreaterThan(0);
    }
}
