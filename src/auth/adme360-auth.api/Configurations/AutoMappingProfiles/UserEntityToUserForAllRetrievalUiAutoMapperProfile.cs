using System.Linq;
using adme360.auth.api.Helpers.Models;
using adme360.common.dtos.Vms.Users;
using AutoMapper;

namespace adme360.auth.api.Configurations.AutoMappingProfiles
{
    public class UserEntityToUserForAllRetrievalUiAutoMapperProfile : Profile
    {
        public UserEntityToUserForAllRetrievalUiAutoMapperProfile()
        {
            ConfigureMapping();
        }

        public void ConfigureMapping()
        {
            CreateMap<User, UserForAllRetrievalUiModel>()
                .ForMember(dest => dest.Id, opt => opt
                    .MapFrom(src => src.Id))
                .ForMember(dest => dest.Login, opt => opt
                    .MapFrom(src => src.Login))
                .ForMember(dest => dest.Roles, opt => opt
                    .MapFrom(src => src.UsersRoles.Select(x=>x.Role).ToList()))
                .ForMember(dest => dest.IsActivated, opt => opt
                    .MapFrom(src => src.IsActivated))
                .ForMember(dest => dest.ActivationKey, opt => opt
                    .MapFrom(src => src.ActivationKey))
                .ForMember(dest => dest.CreatedBy, opt => opt
                    .MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.ModifiedBy, opt => opt
                    .MapFrom(src => src.ModifiedBy))
                .ForMember(dest => dest.CreateDate, opt => opt
                    .MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.LastModifiedDate, opt => opt
                    .MapFrom(src => src.ModifiedDate))
                .ForMember(dest => dest.ResetKey, opt => opt
                    .MapFrom(src => src.ResetKey))
                .ForMember(dest => dest.ResetDate, opt => opt
                    .MapFrom(src => src.ResetDate))
                .ForMember(dest => dest.LastModifiedBy, opt => opt
                    .MapFrom(src => src.ModifiedBy))
                .ForMember(dest => dest.Firstname, opt => opt
                    .MapFrom(src => src.Customer.Firstname))
                .ForMember(dest => dest.Lastname, opt => opt
                    .MapFrom(src => src.Customer.Lastname))
                .ForMember(dest => dest.Email, opt => opt
                    .MapFrom(src => src.Customer.Email))
                .ForMember(dest => dest.LastModifiedBy, opt => opt
                    .MapFrom(src => src.Customer.ModifiedBy))
                .ForMember(dest => dest.Phone, opt => opt
                    .MapFrom(src => src.Customer.Phone))
                .ForMember(dest => dest.Notes, opt => opt
                    .MapFrom(src => src.Customer.Notes))
                .ForMember(dest => dest.AddressStreetOne, opt => opt
                    .MapFrom(src => src.Customer.Address.StreetOne))
                .ForMember(dest => dest.AddressStreetTwo, opt => opt
                    .MapFrom(src => src.Customer.Address.StreetTwo))
                .ForMember(dest => dest.AddressPostcode, opt => opt
                    .MapFrom(src => src.Customer.Address.PostCode))
                .ForMember(dest => dest.AddressCity, opt => opt
                    .MapFrom(src => src.Customer.Address.City))
                .ForMember(dest => dest.AddressRegion, opt => opt
                    .MapFrom(src => src.Customer.Address.Region))
                .MaxDepth(1)
                ;
        }
    }
}