using LC.Core.Shared.ModelViews.Address;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LC.Core.Shared.ModelViews.Customer
{
    public class CustomerView : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderView Gender { get; set; }
        public ICollection<PhoneView> Phones { get; set; }
        public string Document { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public AddressView Address { get; set; }

        public object Clone()
        {
            var customer = (CustomerView)MemberwiseClone();
            customer.Address = (AddressView)customer.Address.Clone();
            var phones = new List<PhoneView>();
            customer.Phones.ToList().ForEach(p => phones.Add((PhoneView)p.Clone()));
            customer.Phones = phones;

            return customer;
        }

        public CustomerView TypedClone()
        {
            return (CustomerView)Clone();
        }
    }
}
