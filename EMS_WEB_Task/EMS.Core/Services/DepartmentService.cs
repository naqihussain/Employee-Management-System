using EMS.Data;
using EMS.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Services
{
    public class DepartmentService: IDepartmentService
    {
        private readonly Context _dbContext;
        public DepartmentService(Context dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _dbContext.Department.ToListAsync();
        }
        public async Task<bool> AddDepartmentAsync(Department dep)
        {
            try
            {
                _dbContext.Department.Add(dep);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;

        }
    }
}
