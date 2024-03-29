﻿using FluentValidation;
using LC.Core.Shared.ModelViews.Address;

namespace LC.Manager.Validator
{
    public class NewAddressValidator : AbstractValidator<NewAddress>
    {
        public NewAddressValidator()
        {
            RuleFor(x => x.City).NotNull().NotEmpty().MaximumLength(200);
        }
    }
}
