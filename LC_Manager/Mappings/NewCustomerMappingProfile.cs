﻿using System;
using AutoMapper;
using LC.Core.Domain;
using LC.Core.Shared.ModelViews.Customer;
using LC.Core.Shared.ModelViews.Address;
using LC.Core.Shared.ModelViews;

namespace LC.Manager.Mappings
{
    public class NewCustomerMappingProfile : Profile
    {
        public NewCustomerMappingProfile()
        {
            CreateMap<NewCustomer, Customer>()
                .ForMember(d => d.CreateDate, o => o.MapFrom(x => DateTime.Now))
                .ForMember(d => d.BirthDate, o => o.MapFrom(x => x.BirthDate.Date));

            CreateMap<NewAddress, Address>();
            CreateMap<NewPhone, Phone>();
            CreateMap<Customer, CustomerView>();
            CreateMap<Address, AddressView>();
            CreateMap<Phone, PhoneView>();
        }
    }
}
