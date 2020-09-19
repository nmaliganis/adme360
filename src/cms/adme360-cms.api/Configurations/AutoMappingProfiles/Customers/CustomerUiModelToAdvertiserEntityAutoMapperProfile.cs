using adme360.cms.model.Customers;
using adme360.common.dtos.Vms.Customers;
using AutoMapper;

namespace adme360.cms.api.Configurations.AutoMappingProfiles.Customers
{
    public class CustomerUiModelToAdvertiserEntityAutoMapperProfile : Profile
    {
        public CustomerUiModelToAdvertiserEntityAutoMapperProfile()
        {
            ConfigureMapping();
        }

        public void ConfigureMapping()
        {
            CreateMap<CustomerForCreationUiModel, Advertiser>()
                            .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.CustomerFirstname))
                            .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.CustomerLastname))
                            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.CustomerBrand))
                            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.CustomerEmail))
                            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.CustomerPhone))
                            .ForMember(dest => dest.Vat, opt => opt.MapFrom(src => src.CustomerVat))
                            .ForMember(dest => dest.Website, opt => opt.MapFrom(src => src.CustomerWebsite))
                            .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.CustomerNotes))
                            .ForPath(dest => dest.Address.StreetOne, opt => opt.MapFrom(src => src.CustomerStreetOne))
                            .ForPath(dest => dest.Address.StreetTwo, opt => opt.MapFrom(src => src.CustomerStreetTwo))
                            .ForPath(dest => dest.Address.PostCode, opt => opt.MapFrom(src => src.CustomerPostCode))
                            .ForPath(dest => dest.Address.City, opt => opt.MapFrom(src => src.CustomerCity))
                            .ForPath(dest => dest.Address.Region, opt => opt.MapFrom(src => src.CustomerRegion))
                            .MaxDepth(1)
                            .PreserveReferences()
                            ;
        }
    }
}