using FluentValidation;
using Viajemos.Test.Web.Models;

namespace Viajemos.Test.Web.Validators
{
    public class EditorialValidator: AbstractValidator<EditorialModel>
    {
        public EditorialValidator()
        {
            RuleFor(it => it.Name)
                .NotNull().WithMessage("Nombre es obligatorio");
            RuleFor(it => it.Campus)
                .NotNull().WithMessage("Sede es obligatorio");
        }
    }
}
