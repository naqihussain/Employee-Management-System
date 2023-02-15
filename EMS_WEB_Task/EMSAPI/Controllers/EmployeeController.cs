using EMS.Core.Model;
using EMS.Core.Services;
using EMS.Data.DataContext;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EMS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                employees = await _employeeService.GetAllEmployeesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, new { Error = ex.Message });
            }
            return new OkObjectResult(employees);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(string id)
        {
            var data = await _employeeService.GetEmployeesAsync(new Guid(id));
            return new OkObjectResult(data);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> Post(EmployeeHelper obj)
        {
            try
            {
                Employee em = new Employee();
                em.FirstName = obj.FName;
                em.LastName = obj.LName;
                em.Email = obj.Email;
                em.FullName = obj.Name;
                em.DOB = Convert.ToDateTime(obj.DOB);
                em.Department = new Department { Id = new Guid(obj.DeptID) };
                em.Active = true;
                em.CreatedOn = DateTime.Now;
                if (!string.IsNullOrEmpty(obj.Id))
                {
                    em.Id = new Guid(obj.Id);
                }
                bool result = await _employeeService.AddorEditEmployeeAsync(em);
                if (result)
                {
                    return new OkObjectResult("Employee is successfully added.");
                }
                return new OkObjectResult("something went wrong.");
            }
            catch (Exception ex)
            {

                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, new { Error = ex.Message });
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                bool result = await _employeeService.DeleteEmployeeAsync(new Guid(id));
                if (result)
                {
                    return new OkObjectResult("Employee is successfully deleted.");
                }
                return new OkObjectResult("something went wrong.");
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, new { Error = ex.Message });
            }
        }
    }
}
