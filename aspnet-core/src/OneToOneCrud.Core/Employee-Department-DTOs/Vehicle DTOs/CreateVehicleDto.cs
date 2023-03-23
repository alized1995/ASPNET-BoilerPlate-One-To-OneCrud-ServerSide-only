using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using OneToOneCrud.Company_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneCrud.Employee_vehicle_DTOs
{
    
    public class CreateVehicleDto : EntityDto<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int EmployeeId { get; set; }
    }
}
