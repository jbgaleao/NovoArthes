
using Arthes.DATA.Models;

using FluentValidation;

namespace Arthes.DATA.Validations
{
    public class ValidatorReceita : AbstractValidator<Receita>
    {
        public ValidatorReceita()
        {

            _ = RuleFor(r => r.Nome).NotEmpty().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.Nome).NotNull().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.Nome).MaximumLength(100).WithMessage("Máximo de 100 caracteres");

            _ = RuleFor(r => r.Altura).NotEmpty().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.Altura).NotNull().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.Altura).Must(AlturaValida).WithMessage("Altura inválida");
        }

        private bool AlturaValida(string altura)
        {
            decimal altConvertida = Convert.ToDecimal(altura);
            return altConvertida is >= 5.0m and <= 50.0m;

        }
    }
}
