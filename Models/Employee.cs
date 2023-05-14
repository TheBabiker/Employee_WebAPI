using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_WebAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string LastName { get; set; } = "Babiker";
        public string FirstName { get; set; } = "Candidate";
        public string Email { get; set; } = "babiker@raynor.example";
        public string Position { get; set; } = "Intermediate Developer";
        public string? Gender { get; set; }
        public string Status { get; set; } = "Inactive";

    }
}