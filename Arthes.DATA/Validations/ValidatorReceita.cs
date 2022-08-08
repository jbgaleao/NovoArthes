
using Arthes.DATA.Models;

using FluentValidation;

namespace Arthes.DATA.Validations
{
    public class ValidatorNovaReceitaViewModel : AbstractValidator<NovaReceitaViewModel>
    {
        public ValidatorNovaReceitaViewModel()
        {

            _ = RuleFor(r => r.Nome).NotEmpty().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.Nome).NotNull().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.Nome).MaximumLength(100).WithMessage("Máximo de 100 caracteres");

            _ = RuleFor(r => r.Altura).NotEmpty().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.Altura).NotNull().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.Altura).InclusiveBetween(5,50).WithMessage("Altura inválida");
        }
    }
}
