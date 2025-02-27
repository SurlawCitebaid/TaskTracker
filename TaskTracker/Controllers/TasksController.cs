using Microsoft.AspNetCore.Mvc;
using TaskTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TaskTracker.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskTrackerDbContext _dbContext;

        public TasksController(TaskTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var tasks = _dbContext.Tasks
                .ToList();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            // Optionally, load Users to select who to assign the Task to
            ViewBag.Users = _dbContext.Users.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskItem task)
        {
            ViewBag.Users = _dbContext.Users.ToList();
            if (ModelState.IsValid)
            {
                _dbContext.Tasks.Add(task);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }
    }
}