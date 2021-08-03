using AutoMapper;
using LC.Core;
using LC.Core.Shared.ModelViews;
using System;

namespace LC.Manager.Mappings
{
    public class NewDoctorMappingProfile : Profile
    {
        public NewDoctorMappingProfile()
        {
            //CreateMap<NewDoctor, Doctor>();
            CreateMap<NewPhone, Phone>();
        }
    }
}
