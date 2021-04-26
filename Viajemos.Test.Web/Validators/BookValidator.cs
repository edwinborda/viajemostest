using FluentValidation;
using Viajemos.Test.Web.Models;

namespace Viajemos.Test.Web.Validators
{
    public class BookValidator: AbstractValidator<BookModel>
    {
        public BookValidator()
        {
            RuleFor(it => it.ISBN)
                .NotNull().WithMessage("ISBN es obligatorio")
                .NotEmpty().WithMessage("ISBN es obligatorio");
            RuleFor(it => it.Title)
                .NotNull().WithMessage("Título es obligatorio")
                .NotEmpty().WithMessage("Título es obligatorio");
            RuleFor(it => it.Sypnosis)
                .NotNull().WithMessage("Sipnosis es obligatorio")
                .NotEmpty().WithMessage("Sipnosis es obligatorio");
            RuleFor(it => it.NumberPages)
               .NotNull().WithMessage("Número de páginas es obligatorio")
               .NotEmpty().WithMessage("Número de páginas es obligatorio");
            RuleFor(it => it.Authors)
               .NotNull().WithMessage("Autores es obligatorio")
               .NotEmpty().WithMessage("Autores es obligatorio");
            RuleFor(it => it.Editorial)
               .NotNull().WithMessage("Editorial es obligatorio")
               .NotEmpty().WithMessage("Editorial es obligatorio");

        }
    }
}
