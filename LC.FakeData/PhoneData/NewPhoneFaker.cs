using Bogus;
using LC.Core.Shared.ModelViews;

namespace LC.FakeData.PhoneData
{
    public class NewPhoneFaker : Faker<NewPhone>
    {
        public NewPhoneFaker()
        {
            RuleFor(p => p.Number, f => f.Person.Phone);
        }
    }
}
