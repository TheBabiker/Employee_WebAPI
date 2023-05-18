using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_WebAPI.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {

        private static List<Employee> employees = new List<Employee>{
             new Employee{Id=0, Name = "Babiker NotSethi", Email = "Babiker@raynor.example", Gender = "male", Status = "active"},
             new Employee {Id=1, Name = "Babiker Sethi", Email = "sethi_mohan@raynor.example", Gender = "male", Status = "inactive"},
             new Employee {Id=2, Name = "Shashikala Ahluwalia", Email = "shashikala_ahluwalia@mann.test", Gender = "female", Status = "active"},

        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public EmployeeService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<ServiceResponse<List<GetEmployeeRequestDto>>> GetEmployeeByFirstName(string firstName)
        {
            var serviceResponse = new ServiceResponse<List<GetEmployeeRequestDto>>();
            try
            {
                var dbEmployees = await _context.Employees.ToListAsync();
                var employeesWithFirstName = dbEmployees.Where(e => e.Name.ToLower().Split(' ')[0]
                .Contains(firstName.ToLower()))
                .ToList();

                if (employeesWithFirstName == null || employeesWithFirstName.Count == 0)
                {
                    string errorMsg = $"Employee/s with firstname:{firstName} not found";
                    throw new Exception(errorMsg);
                }
                serviceResponse.Data = employeesWithFirstName.Select(e => _mapper.Map<GetEmployeeRequestDto>(e)).ToList();
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetEmployeeRequestDto>> GetEmployeeById(int id)
        {
            var serviceResponse = new ServiceResponse<GetEmployeeRequestDto>();

            try
            {
                var dbEmployees = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
                if (dbEmployees == null)
                {
                    string errorMsg = $"Employee with Id:{id} not found.";
                    throw new Exception(errorMsg);
                }
                serviceResponse.Data = _mapper.Map<GetEmployeeRequestDto>(dbEmployees);
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetEmployeeRequestDto>>> GetEmployees()
        {
            var serviceResponse = new ServiceResponse<List<GetEmployeeRequestDto>>();
            var dbEmployees = await _context.Employees.ToListAsync();
            serviceResponse.Data = dbEmployees.Select(e => _mapper.Map<GetEmployeeRequestDto>(e)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetEmployeeRequestDto>>> AddEmployee(AddEmployeeRequestDto newEmployee)
        {
            var serviceResponse = new ServiceResponse<List<GetEmployeeRequestDto>>();
            var employee = _mapper.Map<Employee>(newEmployee);
            employee.Id = employees.Max(e => e.Id) + 1;
            employees.Add(employee);
            serviceResponse.Data = employees.Select(e => _mapper.Map<GetEmployeeRequestDto>(e)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetEmployeeRequestDto>> UpdateEmployee(UpdateEmployeeRequestDto updatedEmployee)
        {
            var serviceResponse = new ServiceResponse<GetEmployeeRequestDto>();
            try
            {
                var employee = employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);

                if (employee is null)
                    throw new Exception($"Employee with Id:{updatedEmployee.Id} not found.");

                _mapper.Map(updatedEmployee, employee);
                serviceResponse.Data = _mapper.Map<GetEmployeeRequestDto>(employee);

            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;

            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetEmployeeRequestDto>>> DeleteEmployee(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetEmployeeRequestDto>>();
            try
            {
                var employee = employees.FirstOrDefault(e => e.Id == id);

                if (employee is null)
                    throw new Exception($"Employee with Id:{id} not found.");

                employees.Remove(employee);
                serviceResponse.Data = employees.Select(e => _mapper.Map<GetEmployeeRequestDto>(e)).ToList();

            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;

            }

            return serviceResponse;
        }
    }
}