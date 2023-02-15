using EMS.Core.Services;
using EMS.Core.Model;
using EMS.Data.DataContext;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using EMS.Data;

namespace EMS.WEB.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            ViewBag.APIEndPoint = WebUtil.EMSAPI;
            return View();
        }
    }
}
