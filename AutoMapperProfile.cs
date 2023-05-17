using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_WebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, GetEmployeeRequestDto>();
            CreateMap<AddEmployeeRequestDto, Employee>();
            CreateMap<UpdateEmployeeRequestDto, Employee>();


        }
    }
}