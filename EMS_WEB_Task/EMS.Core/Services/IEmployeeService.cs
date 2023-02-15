using EMS.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Services
{
    public interface IEmployeeService
    {
        Task<bool> AddorEditEmployeeAsync(Employee emp);
        Task<Employee> GetEmployeesAsync(Guid id);
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<List<Department>> GetAllDepartmentsAsync();
        Task<bool> DeleteEmployeeAsync(Guid Id);
    }
}
