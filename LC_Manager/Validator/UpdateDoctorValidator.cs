using FluentValidation;
using LC.Core.Shared.ModelViews;
using LC.Manager.Interfaces.Repositories;

namespace LC.Manager.Validator
{
    public class UpdateDoctorValidator : AbstractValidator<UpdateDoctor>
    {
        public UpdateDoctorValidator(ISpecialtyRepository repository)
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().GreaterThan(0);

            Include(new NewDoctorValidator(repository));
        }
    }
}
