using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskManament.Mvc.Models;
using TaskManament.Mvc.Services;

namespace TaskManament.Mvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationUserService _applicationUserService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationUserService applicationUserService, ILogger<HomeController> logger)
        {
            _applicationUserService = applicationUserService;
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            await _applicationUserService.CaptureApplicationUser(User, new CancellationToken());
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
