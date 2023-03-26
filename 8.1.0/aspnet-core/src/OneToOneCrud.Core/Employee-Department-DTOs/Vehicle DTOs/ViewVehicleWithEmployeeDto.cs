using OneToOneCrud.Company_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneCrud.Employee_Department_DTOs.Vehicle_DTOs
{
    public class ViewVehicleWithEmployeeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int EmployeeId { get; set; }
        public string  EmployeeName { get; set; }


    }
}
