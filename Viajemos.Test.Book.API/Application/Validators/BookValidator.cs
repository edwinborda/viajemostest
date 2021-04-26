using FluentValidation;
using Viajemos.Test.Book.API.Application.Models;

namespace Viajemos.Test.Book.API.Application.Validators
{
    public class BookValidator: AbstractValidator<BookModel>
    {
        public BookValidator()
        {
            RuleFor(it => it.ISBN)
                .NotNull().WithMessage("ISBN is required")
                .NotEmpty().WithMessage("ISBN is required");
            RuleFor(it => it.Title)
                .NotNull().WithMessage("Title is required")
                .NotEmpty().WithMessage("Title is required");
            RuleFor(it => it.Sypnosis)
                .NotNull().WithMessage("Sypnosis is required")
                .NotEmpty().WithMessage("Sypnosis is required");
            RuleFor(it => it.NumberPages)
               .NotNull().WithMessage("NumberPages is required")
               .NotEmpty().WithMessage("NumberPages is required");
            RuleFor(it => it.Authors)
               .NotNull().WithMessage("Authors is required")
               .NotEmpty().WithMessage("Authors is required");
            RuleFor(it => it.Editorial)
               .NotNull().WithMessage("Editorial is required")
               .NotEmpty().WithMessage("Editorial is required");

        }
    }
}
