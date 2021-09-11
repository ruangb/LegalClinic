using LC.Core.Shared.ModelViews.Address;
using System;
using System.Collections.Generic;

namespace LC.Core.Shared.ModelViews.Customer
{
    public class CustomerView 
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
    }
}
