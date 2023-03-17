
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneCrud.Company_Models
{
    [Table("Employees")]
    public class Employee : Entity<int>
    {

        [Required]
        [StringLength(20, ErrorMessage = "Maximum Length is 20")]
        public virtual string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximum Length is 50")]
        public virtual string Address { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Maximum Length is 25")]
        public virtual string Designation { get; set; }

        

        // Navigation Property
        public virtual Department Department { get; set; }
    }
}
