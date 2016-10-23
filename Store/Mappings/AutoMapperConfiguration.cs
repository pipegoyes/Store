using AutoMapper;

namespace Store.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(s =>
            {
                s.AddProfile<DomainToViewModelMappingProfile>();
                s.AddProfile<ViewModelToDomainMappingProfile>();
                //s.AddProfile<ViewModelToDomainMappingProfile>();
            });
            
        }
    }
}