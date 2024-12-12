using lr11.Filters;
using Microsoft.AspNetCore.Mvc;

public class AnimalsController : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public AnimalsController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    [ServiceFilter(typeof(ActionLoggingFilter))]
    [ServiceFilter(typeof(UniqueUsersFilter))]
    public IActionResult Index()
    {
        var animals = new List<string> { "Кіт", "Собака", "Папуга", "Кролик" };
        return View(animals);
    }

    [ServiceFilter(typeof(ActionLoggingFilter))]
    [ServiceFilter(typeof(UniqueUsersFilter))]
    public IActionResult Details(string animalName)
    {
        if (string.IsNullOrEmpty(animalName))
        {
            return RedirectToAction(nameof(Index));
        }
        ViewData["AnimalName"] = animalName;  
        return View("Details"); 
    }

    [ServiceFilter(typeof(ActionLoggingFilter))]
    [ServiceFilter(typeof(UniqueUsersFilter))]
    public IActionResult UserStats()
    {
        var logPath = Path.Combine(_webHostEnvironment.WebRootPath, "unique_users_log.txt");
        var logs = System.IO.File.ReadAllLines(logPath);
        return View(logs);
    }

    [ServiceFilter(typeof(ActionLoggingFilter))]
    [ServiceFilter(typeof(UniqueUsersFilter))]
    public IActionResult ActionLogs()
    {
        var logPath = Path.Combine(_webHostEnvironment.WebRootPath, "action_log.txt");
        var logs = System.IO.File.ReadAllLines(logPath);
        return View(logs);
    }
}