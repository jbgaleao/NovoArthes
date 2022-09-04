using Arthes.WEB.Models;

using FluentValidation;

namespace Arthes.WEB.Validations
{
    public class ValidatorLinhaVM : AbstractValidator<LinhaVM>
    {
        public ValidatorLinhaVM()
        {
            _ = RuleFor(r => r.CodLinha).NotEmpty().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.CodLinha).NotNull().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.CodLinha).MaximumLength(6).WithMessage("Máximo de 6 caracteres");

            _ = RuleFor(r => r.NomeCor).NotEmpty().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.NomeCor).NotNull().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.NomeCor).MaximumLength(50).WithMessage("Máximo de 50 caracteres");

        }
    }
}
