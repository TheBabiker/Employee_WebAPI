using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_WebAPI.Services
{
    public interface IEmployeeService
    {
        Task<ServiceResponse<List<GetEmployeeRequestDto>>> GetEmployees();
        Task<ServiceResponse<List<GetEmployeeRequestDto>>> GetEmployeeByFirstName(string firstName);
        Task<ServiceResponse<GetEmployeeRequestDto>> GetEmployeeById(int id);
        Task<ServiceResponse<List<GetEmployeeRequestDto>>> AddEmployee(AddEmployeeRequestDto newEmployee);
        Task<ServiceResponse<GetEmployeeRequestDto>> UpdateEmployee(UpdateEmployeeRequestDto updatedEmployee);
        Task<ServiceResponse<List<GetEmployeeRequestDto>>> DeleteEmployee(int Id);



    }
}