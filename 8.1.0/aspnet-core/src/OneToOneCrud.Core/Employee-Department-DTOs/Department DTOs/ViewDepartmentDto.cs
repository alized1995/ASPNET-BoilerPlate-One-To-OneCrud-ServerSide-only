using Abp.AutoMapper;
using OneToOneCrud.Company_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneCrud.Employee_Department_DTOs
{
    
    public class ViewDepartmentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int EmployeeId { get; set; }
    }
}
