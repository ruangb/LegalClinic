using System.Threading.Tasks;
using FluentValidation;
using LC.Core.Shared.ModelViews;
using LC.Manager.Interfaces.Repositories;

namespace LC.Manager.Validator
{
    public class SpecialtyReferenceValidator : AbstractValidator<SpecialtyReference>
    {
        private readonly ISpecialtyRepository repository;

        public SpecialtyReferenceValidator(ISpecialtyRepository repository)
        {
            this.repository = repository;
            RuleFor(x => x.Id).NotNull().NotEmpty().GreaterThan(0)
                .MustAsync(async (id, cancel) => 
                { 
                    return await ExistsOnBase(id); 
                }).WithMessage("Especialidade não cadastrada");
        }

        private async Task<bool> ExistsOnBase(int id)
        {
            return await repository.Exists(id);
        }
    }
}
