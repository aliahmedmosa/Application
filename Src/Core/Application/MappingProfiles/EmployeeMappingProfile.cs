namespace Application.MappingProfiles
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            //Configure Automapper
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }

    }
}
