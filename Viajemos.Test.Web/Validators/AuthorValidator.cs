using FluentValidation;
using Viajemos.Test.Web.Models;

namespace Viajemos.Test.Web.Validators
{
    public class AuthorValidator: AbstractValidator<AuthorModel>
    {
        public AuthorValidator()
        {
            RuleFor(it => it.Name)
                .NotNull().WithMessage("Nombre es requerido")
                .NotEmpty().WithMessage("Nombre es requerido");

            RuleFor(it => it.LastName)
                .NotNull().WithMessage("Apellido es requerido")
                .NotEmpty().WithMessage("Apellido es requerido");
        }
    }
}
