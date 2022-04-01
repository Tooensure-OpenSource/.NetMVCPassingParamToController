using Microsoft.AspNetCore.Mvc;
using MVController.Models;
using System.Diagnostics;

namespace MVController.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Export([FromBody] string username)
        {
            var users = this.GetUsersWithSameName(username);
            // var export = new ExportCsv<User>();

            // export.SaveToCsv(listOfUsers, "./");
            return View(users);
        }

        public IEnumerable<User> GetUsersWithSameName(string name)
        {
            var users = new List<User>
            {
                new User(){Username = "Mike", Email = "milke1@gmail.com"},
                new User(){Username = "Mike", Email = "milke2@gmail.com"},
                new User(){Username = "Katty", Email = "katty@gmail.com"},
            };
            return users.Where(x => x.Username == name);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}