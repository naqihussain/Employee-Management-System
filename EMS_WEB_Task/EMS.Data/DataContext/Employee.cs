using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Data.DataContext
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string? FirstName { get; set; }
        [MaxLength(100)]
        public string? LastName { get; set; }
        [MaxLength(200)]
        public string? FullName { get; set; }
        [MaxLength(150)]
        public string? Email { get; set; }
        public DateTime DOB { get; set; }
        public virtual Department? Department { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
