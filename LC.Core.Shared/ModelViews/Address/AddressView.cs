using LC.Core.Domain;

namespace LC.Core.Shared.ModelViews.Address
{
    public class AddressView
    {
        public int CustomerId { get; set; }
        public string ZipCode { get; set; }
        public State State { get; set; }
        public string City { get; set; }
        public string PublicPlace { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
    }
}
