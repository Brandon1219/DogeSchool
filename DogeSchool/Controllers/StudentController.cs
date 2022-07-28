using DogeSchool.Models;
using DogeSchool.Repository.Repositories.StudentRepository;
using Microsoft.AspNetCore.Mvc;

namespace DogeSchool.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentRepository.ReadAll();
            return View(students);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentModel model)
        {
            await _studentRepository.Create(model);
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await _studentRepository.Read(id);

            return View("Create", student);
        }
    }
}
