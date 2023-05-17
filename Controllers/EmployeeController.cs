using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace Employee_WebAPI.Controllers
{
    [ApiController]
    [Route("public/v2/users")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeRequestDto>>>> GetEmployees()
        {
            return Ok(await _employeeService.GetEmployees());
        }

        [HttpGet("first_name")]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeRequestDto>>>> GetEmployeeByFirstName([FromQuery(Name = "firstName")] string firstName)
        {
            var response = await _employeeService.GetEmployeeByFirstName(firstName);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetEmployeeRequestDto>>> GetEmployeeById(int id)
        {
            var response = await _employeeService.GetEmployeeById(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetEmployeeRequestDto>>> AddEmployee(AddEmployeeRequestDto newEmployee)
        {
            return Ok(await _employeeService.AddEmployee(newEmployee));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetEmployeeRequestDto>>> UpdateEmployee(UpdateEmployeeRequestDto updatedEmployee)
        {
            var response = await _employeeService.UpdateEmployee(updatedEmployee);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetEmployeeRequestDto>>> DeleteEmployeeById(int id)
        {
            var response = await _employeeService.DeleteEmployee(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}