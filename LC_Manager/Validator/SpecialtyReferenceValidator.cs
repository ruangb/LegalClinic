using System;
using FluentValidation;
using LC.Core.Shared.ModelViews;

namespace LC.Manager.Validator
{
    public class SpecialtyReferenceValidator : AbstractValidator<SpecialtyReference>
    {
        public SpecialtyReferenceValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().GreaterThan(0).Must(ExistsOnBase).WithMessage("Especialidade não cadastrada");
        }

        private bool ExistsOnBase(int id)
        {
            throw new NotImplementedException();
        }
    }
}
