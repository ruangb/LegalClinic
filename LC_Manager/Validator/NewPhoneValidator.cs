using System;
using FluentValidation;
using LC.Core.Shared.ModelViews;

namespace LC.Manager.Validator
{
    public class NewPhoneValidator : AbstractValidator<NewPhone>
    {
        public NewPhoneValidator()
        {
            RuleFor(p => p.Number).Matches("[1-9][0-9][0-9]{10}").WithMessage("O telefone tem que ter o formato[2-9][0-9]{10}");
        }

        private bool IsMorF(char gender)
        {
            return gender == 'M' || gender == 'F';
        }
    }
}
