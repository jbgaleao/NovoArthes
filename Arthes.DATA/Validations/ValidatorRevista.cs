using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arthes.DATA.Models;

using FluentValidation;

namespace Arthes.DATA.Validations
{
    public class ValidatorRevista : AbstractValidator<Revista>
    {
        public ValidatorRevista()
        {
            RuleFor(r => r.Tema).NotNull().NotEmpty().WithMessage("Campo obrigatório");
            RuleFor(r => r.Tema).MaximumLength(50).WithMessage("Máximo de 50 caracteres");
            
            RuleFor(r => r.AnoEdicao).NotNull().NotEmpty().WithMessage("Campo obrigatório");
            RuleFor(r => r.AnoEdicao).InclusiveBetween(2015,2025).WithMessage("Ano deve ser posterior a 2014 e anterior a 2026");

            RuleFor(r => r.NumEdicao).GreaterThanOrEqualTo(1).WithMessage("Numero deve ser positivo");

        }
    }
}
