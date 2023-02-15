using EMS.Core.Model;
using EMS.Core.Services;
using EMS.Data.DataContext;
using Microsoft.AspNetCore.Mvc;

namespace EMSAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _departmentService.GetAllDepartmentsAsync();
                return new OkObjectResult(data);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, new { Error = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(DepartmentHelper obj)
        {
            try
            {
                Department dm = new Department();
                dm.Name = obj.Name;
                bool result = await _departmentService.AddDepartmentAsync(dm);
                if (result)
                {
                    return new OkObjectResult("Department is successfully added.");
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