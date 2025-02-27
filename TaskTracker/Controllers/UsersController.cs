using Microsoft.AspNetCore.Mvc;
using TaskTracker.Models;
using System.Linq;

namespace TaskTracker.Controllers;

public class UsersController : Controller
{
    private readonly TaskTrackerDbContext _dbContext;
    
    public UsersController(TaskTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    // GET: /Users/Index
    public IActionResult Index()
    {
        var users = _dbContext.Users.ToList();
        return View(users);
    }
    
    // GET: /Users/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Users/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(User user)
    {
        if (ModelState.IsValid)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(user);
    }
}