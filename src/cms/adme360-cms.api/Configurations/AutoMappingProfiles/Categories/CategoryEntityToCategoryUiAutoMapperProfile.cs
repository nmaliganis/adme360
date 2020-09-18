using adme360.cms.model.Categories;
using adme360.common.dtos.Vms.Categories;
using AutoMapper;

namespace adme360.cms.api.Configurations.AutoMappingProfiles.Categories
{
    public class CategoryEntityToCategoryUiAutoMapperProfile : Profile
    {
        public CategoryEntityToCategoryUiAutoMapperProfile()
        {
            ConfigureMapping();
        }

        public void ConfigureMapping()
        {
            CreateMap<Category, CategoryUiModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CategoryCreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.CategoryCreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.CategoryModifiedDate, opt => opt.MapFrom(src => src.ModifiedDate))
                .ForMember(dest => dest.CategoryModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                .MaxDepth(1)
                .PreserveReferences()
                ;
            
        }
    }
}