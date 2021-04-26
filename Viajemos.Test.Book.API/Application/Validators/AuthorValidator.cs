using FluentValidation;
using Viajemos.Test.Book.API.Application.Models;

namespace Viajemos.Test.Book.API.Application.Validators
{
    public class AuthorValidator: AbstractValidator<AuthorModel>
    {
        public AuthorValidator()
        {
            RuleFor(it => it.Name)
                .NotNull().WithMessage("Name is required")
                .NotEmpty().WithMessage("Name is required");

            RuleFor(it => it.LastName)
                .NotNull().WithMessage("LastName is required")
                .NotEmpty().WithMessage("LastName is required");
        }
    }
}
