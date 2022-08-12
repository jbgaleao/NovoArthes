


using FluentValidation;

namespace Arthes.WEB.Validations
{
    public class ValidatorReceitaVM : AbstractValidator<Models.ReceitaVM>
    {
        public ValidatorReceitaVM()
        {

            _ = RuleFor(r => r.Nome).NotEmpty().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.Nome).NotNull().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.Nome).MaximumLength(100).WithMessage("Máximo de 100 caracteres");

            _ = RuleFor(r => r.Altura).NotEmpty().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.Altura).NotNull().WithMessage("Campo obrigatório");
            _ = RuleFor(r => r.Altura).InclusiveBetween(5, 50).WithMessage("Altura inválida");

            //_ = RuleFor(r => r.IdRevista).NotNull().WithMessage("Campo obrigatório");
            //_ = RuleFor(r => r.IdRevista).NotEqual(0).WithMessage("Campo obrigatório");

        }
    }
}
