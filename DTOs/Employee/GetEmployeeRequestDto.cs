using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_WebAPI.DTOs.Employee
{
    public class GetEmployeeRequestDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string Status { get; set; } = "Inactive";
    }
}