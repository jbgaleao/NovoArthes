using Arthes.DATA.Models;

using FluentValidation;

namespace Arthes.WEB.Validations
{
    public class ValidatorTipoLinha : AbstractValidator<TipoLinha>
    {
        public ValidatorTipoLinha()
        {
            _ = RuleFor(r => r.Descricao).NotEmpty().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.Descricao).NotNull().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.Descricao).MaximumLength(50).WithMessage("Máximo de 50 caracteres");

        }
    }
}
