using AutoMapper;
using WebCoreApi.Data;
using WebCoreApi.Models;

namespace WebCoreApi.Configurations
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Equipment, EquipmentDTO>().ForMember(dest => dest.Condition, opt =>
                opt.MapFrom(src => src.Condition.ToString().ToLower())).ReverseMap();
            CreateMap<Location, LocationDTO>()
                .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager.Name)).ReverseMap(); 
        }

    }
}
