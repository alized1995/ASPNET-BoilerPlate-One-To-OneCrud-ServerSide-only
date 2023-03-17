using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneCrud.Employee_Department_DTOs.Department
{
    
    public class UpdateDepartmentDto
    {
        [Required]

        public string Name { get; set; }

        [Required]
        public int EmployeeId { get; set; }
    }
}
