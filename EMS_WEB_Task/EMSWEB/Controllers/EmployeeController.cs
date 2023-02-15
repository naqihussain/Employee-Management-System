using EMS.Core.Services;
using EMS.Core.Model;
using EMS.Data.DataContext;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using EMS.Data;

namespace EMS.WEB.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            ViewBag.APIEndPoint = WebUtil.EMSAPI;
            return View();
        }
       
        public async Task<JsonResult> GetAllEmployee()
        {
            try
            {
                var _data = await _employeeService.GetAllEmployeesAsync();
                return Json(_data);
            }
            catch (Exception ex)
            {
                return Json(ex.Message.ToString());
            }
        }
        public async Task<JsonResult> GetEmployee(string id)
        {
            try
            {
                var _data = await _employeeService.GetEmployeesAsync(new Guid(id));
                return Json(_data);
            }
            catch (Exception ex)
            {
                return Json(ex.Message.ToString());
            }
        }
        public async Task<JsonResult> GetDepartments()
        {
            try
            {
                var _data = await _employeeService.GetAllDepartmentsAsync();
                return Json(_data);
            }
            catch (Exception ex)
            {
                return Json(ex.Message.ToString());
            }
        }
        public async Task<JsonResult> AddEmployee(string id,string FName, string LName, string Name, string Email, string DOB, string DeptID)
        {
            try
            {
                
                Employee em = new Employee();
                em.FirstName = FName;
                em.LastName = LName;
                em.Email = Email;
                em.FullName = Name;
                em.DOB = Convert.ToDateTime(DOB);
                em.Department = new Department { Id = new Guid(DeptID) };
                em.Active = true;
                em.CreatedOn = DateTime.Now;
                if (!string.IsNullOrEmpty(id))
                {
                    em.Id = new Guid(id);
                }
                bool result = await _employeeService.AddorEditEmployeeAsync(em);
                return Json("successfully saved.");
            }
            catch (Exception ex)
            {
                return Json(ex.Message.ToString());
            }
        }
        public async Task<JsonResult> DeleteEmployee(string id)
        {
            try
            {
                bool result = await _employeeService.DeleteEmployeeAsync(new Guid(id));
                if (result)
                {
                    return Json("Employee is successfully deleted.");
                }
                return Json("something went wrong.");
            }
            catch (Exception ex)
            {
                return Json(ex.Message.ToString());
            }
        }
    }
}
