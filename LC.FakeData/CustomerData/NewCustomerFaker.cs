using Bogus;
using Bogus.Extensions.Brazil;
using LC.Core.Shared.ModelViews.Customer;
using LC.FakeData.AddressData;
using LC.FakeData.PhoneData;

namespace LC.FakeData.CustomerData
{
    public class NewCustomerFaker : Faker<NewCustomer>
    {
        public NewCustomerFaker()
        {
            var id = new Faker().Random.Number(1, 999999);

            RuleFor(p => p.Name, f => f.Person.FullName);
            RuleFor(p => p.Gender, f => f.PickRandom<GenderView>());
            RuleFor(p => p.Document, f => f.Person.Cpf());
            RuleFor(p => p.BirthDate, f => f.Date.Past());
            RuleFor(p => p.Phones, f => new NewPhoneFaker().Generate(3));
            RuleFor(p => p.Address, f => new NewAddressFaker().Generate());
        }
    }
}
