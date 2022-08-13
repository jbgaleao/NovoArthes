using Arthes.DATA.Models;

using FluentValidation;

namespace Arthes.WEB.Validations
{
    public class ValidatorFabricante : AbstractValidator<Fabricante>
    {
        public ValidatorFabricante()
        {
            _ = RuleFor(r => r.Nome).NotEmpty().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.Nome).NotNull().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.Nome).MaximumLength(50).WithMessage("Máximo de 50 caracteres");

        }
    }
}
