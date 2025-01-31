using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.web.Data;
using StudentPortal.web.Log;
using StudentPortal.web.Models;
using StudentPortal.web.Models.Entities;

namespace StudentPortal.web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        private readonly ILoggingService _logger;

        public StudentsController(ApplicationDbContext dbContext, ILoggingService logger)
        {
            this.dbContext = dbContext;
            _logger = logger;
        }



        [HttpGet]
        public IActionResult Add()
        {
            _logger.LogInfo("Add student page loaded");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Club = viewModel.Club,
            };

            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();

            _logger.LogInfo("Student added");

            return RedirectToAction("List", "Students");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            LogEvents.LogToFile("Title", "Total records fetched " + dbContext.Students.Count());

            var students = await dbContext.Students.ToListAsync();
            _logger.LogInfo("List of students fetched");
            return View(students);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);
            _logger.LogInfo("Edit student page loaded");
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student = await dbContext.Students.FindAsync(viewModel.Id);

            if (student is not null)
            {
                student.Name = viewModel.Name;
                student.Email = viewModel.Email;
                student.Phone = viewModel.Phone;
                student.Club = viewModel.Club;

                await dbContext.SaveChangesAsync();
            }
            _logger.LogInfo("Student updated");
            return RedirectToAction("List", "Students");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Student viewModel)
        {
            var student = await dbContext.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(x=> x.Id == viewModel.Id);

            if (student != null)
            {
                dbContext.Students.Remove(student);
                await dbContext.SaveChangesAsync();
            }
            _logger.LogInfo("Student deleted");
            return RedirectToAction("List", "Students");

        }



    }
}
