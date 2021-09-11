using AutoMapper;
using LC.Core.Domain;
using LC.Core.Shared.ModelViews.Customer;
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
