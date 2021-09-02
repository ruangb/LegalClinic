using AutoMapper;
using LC.Core.Domain;
using LC.Core.Shared.ModelViews;

namespace LC.Manager.Mappings
{
    public class NewDoctorMappingProfile : Profile
    {
        public NewDoctorMappingProfile()
        {
            CreateMap<NewDoctor, Doctor>();
            CreateMap<Doctor, DoctorView>();
            CreateMap<Specialty, SpecialtyReference>().ReverseMap();
            CreateMap<Specialty, SpecialtyView>().ReverseMap();
            CreateMap<UpdateDoctor, Doctor>().ReverseMap();
        }
    }
}
