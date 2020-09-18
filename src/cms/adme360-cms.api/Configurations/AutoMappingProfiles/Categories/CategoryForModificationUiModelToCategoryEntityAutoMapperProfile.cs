using adme360.cms.model.Categories;
using adme360.common.dtos.Vms.Categories;
using AutoMapper;

namespace adme360.cms.api.Configurations.AutoMappingProfiles.Categories
{
    public class CategoryForModificationUiModelToCategoryEntityAutoMapperProfile : Profile
    {
        public CategoryForModificationUiModelToCategoryEntityAutoMapperProfile()
        {
            ConfigureMapping();
        }

        public void ConfigureMapping()
        {
            CreateMap<CategoryForModificationUiModel, Category>()
                .ForMember(dest => dest.Name, opt => 
                  opt.MapFrom(src => src.CategoryName))
                .MaxDepth(1)
                .PreserveReferences()
                ;
        }
    }
}