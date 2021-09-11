using Bogus;
using LC.Core.Shared.ModelViews;

namespace LC.FakeData.PhoneData
{
    public class PhoneViewFaker : Faker<PhoneView>
    {
        public PhoneViewFaker()
        {
            RuleFor(p => p.Id, f => f.Random.Number(1, 10)); 
            RuleFor(p => p.Number, f => f.Person.Phone);
        }
    }
}
