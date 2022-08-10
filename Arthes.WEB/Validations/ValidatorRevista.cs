using Arthes.DATA.Models;

using FluentValidation;

namespace Arthes.WEB.Validations
{
    public class ValidatorRevista : AbstractValidator<Revista>
    {
        public ValidatorRevista()
        {

            _ = RuleFor(r => r.Tema).NotEmpty().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.Tema).NotNull().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.Tema).MaximumLength(50).WithMessage("Máximo de 50 caracteres");

            _ = RuleFor(r => r.AnoEdicao).NotEmpty().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.AnoEdicao).NotNull().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.AnoEdicao).InclusiveBetween(2015, 2025).WithMessage("Ano deve ser posterior a 2014 e anterior a 2026");

            _ = RuleFor(r => r.NumEdicao).NotEmpty().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.NumEdicao).NotNull().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.NumEdicao).GreaterThanOrEqualTo(1).WithMessage("Numero deve ser positivo");

        }
    }
}
