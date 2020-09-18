using adme360.auth.api.Helpers.Models;
using adme360.common.dtos.Vms.Users;
using AutoMapper;

namespace adme360.auth.api.Configurations.AutoMappingProfiles
{
    public class UserEntityToUserActivationUiAutoMapperProfile : Profile
    {
        public UserEntityToUserActivationUiAutoMapperProfile()
        {
            ConfigureMapping();
        }

        public void ConfigureMapping()
        {
            CreateMap<User, UserActivationUiModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.IsActivated, opt => opt.MapFrom(src => src.IsActivated))
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreatedDate))
                .MaxDepth(1)
                ;
        }
    }
}