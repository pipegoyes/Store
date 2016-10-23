using AutoMapper;
using Store.Model;
using Store.Model.Dto;
using Store.ViewModels;

namespace Store.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Gadget, GadgetViewModel>();
        }

        public override string ProfileName => "DomainToViewModelMappings";
    }
}