using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Data.DataContext
{
    public class Department
    {
        public Guid Id { get; set; }
        [MaxLength(150)]
        public string? Name { get; set; }
    }
}
