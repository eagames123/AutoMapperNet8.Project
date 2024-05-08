using AutoMapper;
using AutoMapperNet8.Project.DTOs;
using AutoMapperNet8.Project.Models;

namespace AutoMapperNet8.Project.Mappings
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            //CreateMap<Employee, EmployeeDTO>().ForMember(dtoData => dtoData.FullName, fulldata => fulldata.MapFrom(src => src.FirstName + " " + src.LastName))
            //    .ReverseMap();

            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}
