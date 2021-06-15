using System;
using LC.Core;
using FluentValidation;

namespace LC.Manager.Validator
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(10).MaximumLength(150);
            RuleFor(x => x.BirthDate).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-130));
            RuleFor(x => x.Document).NotNull().NotEmpty().MinimumLength(4).MaximumLength(14);
            RuleFor(x => x.Phone).NotNull().NotEmpty().Matches("[2-9][0-9]{10}").WithMessage("O telefone tem que ter o formato[2-9][0-9]{10}");
            RuleFor(x => x.Gender).NotNull().NotEmpty().Must(IsMorF).WithMessage("O sexo precisa ser M ou F");
        }

        private bool IsMorF(char gender)
        {
            return gender == 'M' || gender == 'F';
        }
    }
}
