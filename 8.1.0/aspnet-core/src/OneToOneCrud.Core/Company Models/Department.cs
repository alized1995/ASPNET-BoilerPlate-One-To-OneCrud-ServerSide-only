﻿
using Abp.Domain.Entities;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneCrud.Company_Models
{
    public class Department : Entity<int>
    {

        [Required]
        [StringLength(20, ErrorMessage = "Maximum Length is 20")]
        public virtual string Name { get; set; }

        public virtual int EmployeeId { get; set; }

        // Navigation Property
        public virtual Employee Employee { get; set; }

    }
}
