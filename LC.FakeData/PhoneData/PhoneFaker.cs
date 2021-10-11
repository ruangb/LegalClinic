using Bogus;
using LC.Core.Domain;

namespace LC.FakeData.PhoneData
{
    public class PhoneFaker : Faker<Phone>
    {
        public PhoneFaker(int clientId)
        {
            RuleFor(o => o.CustomerId, f => clientId);
            RuleFor(o => o.Number, f => f.Person.Phone);
        }
    }
}
