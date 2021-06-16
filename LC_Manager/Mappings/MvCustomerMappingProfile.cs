﻿using AutoMapper;
using LC.Core;
using LC.Core.Shared.ModelViews;
using System;

namespace LC.Manager.Mappings
{
    public class MvCustomerMappingProfile : Profile
    {
        public MvCustomerMappingProfile()
        {
            CreateMap<MvCustomer, Customer>()
                .ForMember(d => d.CreateDate, o => o.MapFrom(x => DateTime.Now))
                .ForMember(d => d.BirthDate, o => o.MapFrom(x => x.BirthDate.Date));
        }
    }
}
