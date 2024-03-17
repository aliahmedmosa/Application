namespace Application.MappingProfiles
{
    public class UOMMappingProfile : Profile
    {
        public UOMMappingProfile()
        {
            //Configure Automapper
            CreateMap<UOM, UOMDTO>().ReverseMap();
        }
    }
}
