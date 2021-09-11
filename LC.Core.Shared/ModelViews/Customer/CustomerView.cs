using LC.Core.Domain;
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
        public Gender Gender { get; set; }
        public ICollection<Phone> Phones { get; set; }
        public string Document { get; set; }
        public NewAddress Address { get; set; }
    }
}
