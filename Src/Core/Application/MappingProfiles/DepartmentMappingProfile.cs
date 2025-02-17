namespace Application.MappingProfiles
{
    public class DepartmentMappingProfile:Profile
    {

        public DepartmentMappingProfile()
        {
            //Configure Automapper
            CreateMap<Department, DepartmentDTO>().ReverseMap();
        }
    }
}
