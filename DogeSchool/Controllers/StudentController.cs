using DogeSchool.Models;
using Microsoft.AspNetCore.Mvc;

namespace DogeSchool.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentModel model)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
