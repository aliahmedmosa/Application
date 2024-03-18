namespace Application.MappingProfiles
{
    public class ItemMappingProfile : Profile
    {
        public ItemMappingProfile()
        {
            //Configure Automapper
            CreateMap<Item, ItemDTO>().ReverseMap();
        }
    }
}
