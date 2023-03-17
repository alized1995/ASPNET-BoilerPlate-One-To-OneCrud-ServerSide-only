using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using OneToOneCrud.Company_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneCrud.Employee_Department_DTOs
{
    [AutoMapFrom(typeof(Employee))]
    public class CreateEmployeeDto : EntityDto<int>
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Designation { get; set; }

    }
}
