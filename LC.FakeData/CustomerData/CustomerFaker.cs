using Bogus;
using Bogus.Extensions.Brazil;
using LC.Core.Domain;
using LC.FakeData.AddressData;
using LC.FakeData.PhoneData;

namespace LC.FakeData.CustomerData
{
    public class CustomerFaker : Faker<Customer>
    {
        public CustomerFaker()
        {
            var id = new Faker().Random.Number(1, 999999);

            RuleFor(p => p.Id, f => id);
            RuleFor(p => p.Name, f => f.Person.FullName);
            RuleFor(p => p.Gender, f => f.PickRandom<Gender>());
            RuleFor(p => p.BirthDate, f => f.Date.Past());
            RuleFor(p => p.Document, f => f.Person.Cpf());
            RuleFor(p => p.CreateDate, f => f.Date.Past());
            RuleFor(p => p.UpdateDate, f => f.Date.Past());
            RuleFor(p => p.Phones, f => new PhoneFaker(id).Generate(3));
            RuleFor(p => p.Address, f => new AddressFaker(id).Generate());
        }
    }
}
