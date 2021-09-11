using System;

namespace LC.Core.Shared.ModelViews.Address
{
    public class AddressView : ICloneable
    {
        public string ZipCode { get; set; }
        public StateView State { get; set; }
        public string City { get; set; }
        public string PublicPlace { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
