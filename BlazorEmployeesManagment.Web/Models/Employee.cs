using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmployeesManagment.Web.Models
{
    public class Employee
    {
        public int Id { get; set; }

       //Required(ErrorMessage = " Firstname must be provided")]
        public string FirstName { get; set; }
      //[Required]
        public string LastName { get; set; }
     // [Required]
     // [EmailAddress]
        public string Email { get; set; }
     // [Required]
        public DateTime DateOfBrith { get; set; }
     // [Required]
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        public Department Department { get; set; }


    }
}
