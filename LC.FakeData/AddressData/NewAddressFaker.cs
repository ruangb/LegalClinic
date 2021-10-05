using Bogus;
using LC.Core.Shared.ModelViews.Address;

namespace LC.FakeData.AddressData
{
    public class NewAddressFaker : Faker<NewAddress>
    {
        public NewAddressFaker()
        {
            RuleFor(p => p.Number, f => f.Address.BuildingNumber());
            RuleFor(p => p.ZipCode, f => f.Address.ZipCode());
            RuleFor(p => p.City, f => f.Address.City());
            RuleFor(p => p.State, f => f.PickRandom<StateView>());
            RuleFor(p => p.PublicPlace, f => f.Address.StreetName());
            RuleFor(p => p.Complement, f => f.Lorem.Sentence(20));
        }
    }
}
