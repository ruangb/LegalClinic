﻿namespace LC.Core
{
    public class Address
    {
        public int Id { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PublicPlace{ get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}