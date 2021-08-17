using System;
using FluentValidation;
using LC.Core.Shared.ModelViews;
using LC.Manager.Interfaces.Repositories;

namespace LC.Manager.Validator
{
    public class NewDoctorValidator : AbstractValidator<NewDoctor>
    {
        public NewDoctorValidator(ISpecialtyRepository repository)
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(x => x.CRM).NotNull().NotEmpty().GreaterThan(0);
            RuleForEach(x => x.Specialties).SetValidator(new SpecialtyReferenceValidator(repository));
        }
    }
}
