﻿using FluentValidation;

namespace BookStore.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorDetailQueryValidator()
        {
            RuleFor(x => x.AuthorId).NotEmpty();
        }
    }
}
