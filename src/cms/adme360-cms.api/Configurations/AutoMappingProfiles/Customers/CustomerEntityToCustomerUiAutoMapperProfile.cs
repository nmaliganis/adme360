using adme360.cms.model.Customers;
using adme360.common.dtos.Vms.Customers;
using AutoMapper;

namespace adme360.cms.api.Configurations.AutoMappingProfiles.Customers
{
  public class CustomerEntityToCustomerUiAutoMapperProfile : Profile
  {
    public CustomerEntityToCustomerUiAutoMapperProfile()
    {
      ConfigureMapping();
    }

    public void ConfigureMapping()
    {
      CreateMap<Customer, CustomerUiModel>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.CustomerFirstname, opt => opt.MapFrom(src => src.Firstname))
        .ForMember(dest => dest.CustomerLastname, opt => opt.MapFrom(src => src.Lastname))
        .ForMember(dest => dest.CustomerBrand, opt => opt.MapFrom(src => src.Brand))
        .ForMember(dest => dest.CustomerEmail, opt => opt.MapFrom(src => src.Email))
        .ForMember(dest => dest.CustomerCategoryTypeValue, opt => opt.MapFrom(src => src.Type))
        .ForMember(dest => dest.CustomerCategoryType, opt => opt.MapFrom(src => src.Type.ToString()))
        .ForMember(dest => dest.CustomerPhone, opt => opt.MapFrom(src => src.Phone))
        .ForMember(dest => dest.CustomerVat, opt => opt.MapFrom(src => src.Vat))
        .ForMember(dest => dest.CustomerWebsite, opt => opt.MapFrom(src => src.Website))
        .ForMember(dest => dest.CustomerNotes, opt => opt.MapFrom(src => src.Notes))
        .ForMember(dest => dest.CustomerCreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
        .ForMember(dest => dest.CustomerCreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
        .ForMember(dest => dest.CustomerModifiedDate, opt => opt.MapFrom(src => src.ModifiedDate))
        .ForMember(dest => dest.CustomerModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
        .ForMember(dest => dest.CustomerAddressStreetOne, opt => opt.MapFrom(src => src.Address.StreetOne))
        .ForMember(dest => dest.CustomerAddressStreetTwo, opt => opt.MapFrom(src => src.Address.StreetTwo))
        .ForMember(dest => dest.CustomerAddressCity, opt => opt.MapFrom(src => src.Address.City))
        .ForMember(dest => dest.CustomerAddressRegion, opt => opt.MapFrom(src => src.Address.Region))
        .ForMember(dest => dest.CustomerAddressPostcode, opt => opt.MapFrom(src => src.Address.PostCode))
        .ForMember(dest => dest.CustomerActivated, opt => opt.MapFrom(src => src.Activated))
        .ForMember(dest => dest.CustomerActive, opt => opt.MapFrom(src => src.IsActive))
        .ForMember(dest => dest.CustomerCategoryId, opt => opt.MapFrom(src => src.Category.Id))
        .ForMember(dest => dest.CustomerCategoryName, opt => opt.MapFrom(src => src.Category.Name))
        .MaxDepth(1)
        .PreserveReferences()
        ;
    }
  }
}