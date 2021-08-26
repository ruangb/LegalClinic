using AutoMapper;
using LC.Core;
using LC.Core.Domain;
using LC.Core.Shared.ModelViews;
using System;

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
        }
    }
}
