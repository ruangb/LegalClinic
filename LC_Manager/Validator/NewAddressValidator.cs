using System;
using FluentValidation;
using LC.Core.Shared.ModelViews;

namespace LC.Manager.Validator
{
    public class NewAddressValidator : AbstractValidator<NewAddress>
    {
        public NewAddressValidator()
        {
            RuleFor(x => x.City).NotNull().NotEmpty().MaximumLength(200);
        }

        private bool IsMorF(char gender)
        {
            return gender == 'M' || gender == 'F';
        }
    }
}
