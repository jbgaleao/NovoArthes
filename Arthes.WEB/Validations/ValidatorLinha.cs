using Arthes.DATA.Models;

using FluentValidation;

namespace Arthes.WEB.Validations
{
    public class ValidatorLinha : AbstractValidator<Linha>
    {
        public ValidatorLinha()
        {
            RuleFor(r => r.CodLinha).NotEmpty().WithMessage("Campo obrigatório");
            RuleFor(r => r.CodLinha).NotNull().WithMessage("Campo obrigatório");
            RuleFor(r => r.CodLinha).MaximumLength(6).WithMessage("Máximo de 6 caracteres");

            RuleFor(r => r.NomeCor).NotEmpty().WithMessage("Campo obrigatório");
            RuleFor(r => r.NomeCor).NotNull().WithMessage("Campo obrigatório");
            RuleFor(r => r.NomeCor).MaximumLength(50).WithMessage("Máximo de 50 caracteres");

        }
    }
}
