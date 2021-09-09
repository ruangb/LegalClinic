using FluentValidation;
using LC.Core.Shared.ModelViews.Customer;

namespace LC.Manager.Validator
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomer>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().GreaterThan(0);
            Include(new NewCustomerValidator());
        }
    }
}
