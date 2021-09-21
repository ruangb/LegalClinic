using System;
using FluentValidation;
using LC.Core.Shared.ModelViews.Customer;

namespace LC.Manager.Validator
{
    public class NewCustomerValidator : AbstractValidator<NewCustomer>
    {
        public NewCustomerValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(10).MaximumLength(150);
            RuleFor(x => x.BirthDate).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-130));
            RuleFor(x => x.Document).NotNull().NotEmpty().MinimumLength(4).MaximumLength(14);
            RuleFor(x => x.Phones).NotNull().NotEmpty();
            RuleFor(x => x.Gender).NotNull();
            RuleFor(x => x.Address).SetValidator(new NewAddressValidator());
        }
    }
}
