using Bogus;
using LC.Core.Domain;

namespace LC.FakeData.AddressData
{
    public class AddressFaker : Faker<Address>
    {
        public AddressFaker(int clientId)
        {
            RuleFor(o => o.CustomerId, f => clientId);
            RuleFor(p => p.Number, f => f.Address.BuildingNumber());
            RuleFor(p => p.ZipCode, f => f.Address.ZipCode());
            RuleFor(p => p.City, f => f.Address.City());
            RuleFor(p => p.State, f => f.PickRandom<State>());
            RuleFor(p => p.PublicPlace, f => f.Address.StreetName());
            RuleFor(p => p.Complement, f => f.Lorem.Sentence(20));
        }
    }
}
