using AutoMapper;
using WebCoreApi.Data;
using WebCoreApi.Models;

namespace WebCoreApi.Configurations
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<StudentDTO, Student>().ReverseMap();
        }

    }
}
