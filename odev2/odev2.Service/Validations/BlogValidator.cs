using FluentValidation;
using odev2.Core.Models;

namespace odev2.Service.Validations
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("{PropertName} is required")
                .MinimumLength(3).MaximumLength(100);

            RuleFor(x => x.Content).NotNull().WithMessage("{PropertName} is required")
                .MinimumLength(100).MaximumLength(2000);


        }
    }
}
