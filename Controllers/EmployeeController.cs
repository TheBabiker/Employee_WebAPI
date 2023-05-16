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
        private static List<Employee> employees = new List<Employee>{
             new Employee(),
             new Employee {Id= 1 ,Name = "Mohan Sethi", Email = "sethi_mohan@raynor.example", Gender = "male", Status = "active"},
             new Employee {Name = "Shashikala Ahluwalia", Email = "shashikala_ahluwalia@mann.test", Gender = "female", Status = "active"},
             new Employee {Name = "Dr. Chetanaanand Chopra", Email = "dr_chopra_chetanaanand@heidenreich-swaniawski.test", Gender = "male", Status = "inactive"},
             new Employee {Name = "Anjushree Nair IV", Email = "iv_nair_anjushree@haag-langosh.test", Gender = "female", Status = "inactive"},
             new Employee {Name = "Aishani Kaur VM", Email = "kaur_vm_aishani@ortiz.example", Gender = "female", Status = "inactive"},
             new Employee {Name = "Mr. Aasha Dwivedi", Email = "mr_dwivedi_aasha@metz.example", Gender = "male", Status = "active"},
             new Employee {Name = "Radha Dwivedi Ret", Email = "radha_ret_dwivedi@mraz-turcotte.test", Gender = "female", Status = "inactive"},
             new Employee {Name = "Bhupati Rana", Email = "rana_bhupati@friesen.test", Gender = "female", Status = "active"},
        };

        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(employees);
        }

        [HttpGet("first_name")]
        public ActionResult<List<Employee>> GetEmployeeByFirstName([FromQuery(Name = "firstName")] string firstName)
        {
            return Ok(employees.Where(e => e.Name.ToLower().Contains(firstName.ToLower())).ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
    }
}