using LC.Core.Domain;
using System;
using System.Collections.Generic;

namespace LC.Core
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public ICollection<Phone> Phones { get; set; }
        public string Document { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Address Address { get; set; }
    }
}
