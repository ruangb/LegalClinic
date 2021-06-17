using AutoMapper;
using LC.Core;
using LC.Core.Shared.ModelViews;
using System;

namespace LC.Manager.Mappings
{
    public class UpdateCustomerMappingProfile : Profile
    {
        public UpdateCustomerMappingProfile()
        {
            CreateMap<UpdateCustomer, Customer>()
                .ForMember(d => d.UpdateDate, o => o.MapFrom(x => DateTime.Now))
                .ForMember(d => d.BirthDate, o => o.MapFrom(x => x.BirthDate.Date));
        }
    }
}
