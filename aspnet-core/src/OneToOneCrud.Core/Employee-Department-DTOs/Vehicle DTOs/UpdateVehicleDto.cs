﻿using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneCrud.Employee_vehicle_DTOs.vehicle
{
    
    public class UpdateVehicleDto
    {
        [Required]
        public int Id { get; set; }

        [Required]

        public string Name { get; set; }

        [Required]
        public int EmployeeId { get; set; }
    }
}