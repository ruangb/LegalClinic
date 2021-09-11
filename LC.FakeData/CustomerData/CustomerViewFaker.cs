using Bogus;
using Bogus.Extensions.Brazil;
using LC.Core.Shared.ModelViews.Customer;

namespace LC.FakeData.CustomerData
{
    public class CustomerViewFaker : Faker<CustomerView>
    {
        public CustomerViewFaker()
        {
            var id = new Faker().Random.Number(1, 999999);

            RuleFor(p => p.Id, f => id);
            RuleFor(p => p.Name, f => f.Person.FullName);
            RuleFor(p => p.Gender, f => f.PickRandom<GenderView>());
            RuleFor(p => p.Document, f => f.Person.Cpf());
            RuleFor(p => p.CreateDate, f => f.Date.Past());
            RuleFor(p => p.UpdateDate, f => f.Date.Past());
            RuleFor(p => p.Document, f => f.Person.Cpf());
        }
    }
}
