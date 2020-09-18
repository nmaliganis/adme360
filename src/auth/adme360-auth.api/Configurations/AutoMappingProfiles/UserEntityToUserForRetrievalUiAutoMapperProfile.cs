using System.Linq;
using adme360.auth.api.Helpers.Models;
using adme360.common.dtos.Vms.Users;
using AutoMapper;

namespace adme360.auth.api.Configurations.AutoMappingProfiles
{
    public class UserEntityToUserForRetrievalUiAutoMapperProfile : Profile
    {
        public UserEntityToUserForRetrievalUiAutoMapperProfile()
        {
            ConfigureMapping();
        }

        public void ConfigureMapping()
        {
            CreateMap<User, UserForRetrievalUiModel>()
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.UsersRoles.Select(x=>x.Role).ToList()))
                .ForMember(dest => dest.IsActivated, opt => opt.MapFrom(src => src.IsActivated))
                .ForMember(dest => dest.RefreshToken, opt => opt.MapFrom(src => src.UserTokens.FirstOrDefault(t=>t.Expired == false).RefreshToken))
                .MaxDepth(1)
                ;
        }
    }
}