using EMS.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Data.DataContext;

namespace EMS.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly Context _dbContext;
        public EmployeeService(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddorEditEmployeeAsync(Employee emp)
        {
            try
            {
                if (emp.Id == null || emp.Id == Guid.Empty)
                {
                    _dbContext.Entry(emp.Department).State = EntityState.Unchanged;
                    _dbContext.Employees.AddAsync(emp);
                }
                else
                {
                    _dbContext.Entry(emp.Department).State = EntityState.Unchanged;
                    _dbContext.Employees.Update(emp);
                }
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return true;    

        }

        public async Task<bool> DeleteEmployeeAsync(Guid Id)
        {
            try
            {
                Employee _record = await _dbContext.Employees.Where(a => a.Id == Id).FirstOrDefaultAsync();
                if (_record!= null)
                {
                    _record.Active = false;
                    _record.UpdatedOn = DateTime.Now;
                     await  _dbContext.SaveChangesAsync();
                }
                
            }catch(Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public async Task<Employee> GetEmployeesAsync(Guid id)
        {
            Employee emp = await _dbContext.Employees.Include("Department").Where(x => x.Id == id && x.Active == true).FirstOrDefaultAsync();
            return emp;
        }
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _dbContext.Employees.Include("Department").Where(x =>  x.Active == true).ToListAsync();
        }
        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _dbContext.Department.ToListAsync();
        }
    }
}
