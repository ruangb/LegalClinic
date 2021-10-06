using Bogus;
using LC.Core.Domain;

namespace LC.FakeData.PhoneData
{
    public class PhoneFaker : Faker<Phone>
    {
        public PhoneFaker()
        {
            RuleFor(p => p.Number, f => f.Person.Phone);
        }
    }
}
