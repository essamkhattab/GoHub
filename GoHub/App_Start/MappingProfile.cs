using AutoMapper;
using GoHub.Controllers.API;
using GoHub.Dtos;
using GoHub.Models;

namespace GoHub.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<ApplicationUser, UserDto>();
            Mapper.CreateMap<Go, GoDto>();
            Mapper.CreateMap<Notification, NotificationDto>();

        }
    }
}