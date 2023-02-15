using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Model
{
    public class EmployeeHelper
    {
        public string Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; }
        public string DeptID { get; set; } 

    }
    public class DepartmentHelper
    {
        public string Name { get; set; }
    }
}
