using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmployeesManagment.Web.Models
{
    public class EditEmployeeModel : Employee
    {
       [Compare("Email")]
       [Required]
        public string ConfirmEmail { get; set; }
    }
}
