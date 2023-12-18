using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TOMSU.Emailova_schranka.Application.Abstraction;
using TOMSU.Emailova_schranka.Application.ViewModels;
using TOMSU.Emailova_schranka.Infrastructure.Identity;
using TOMSU.Emailova_schranka.Web.Models;

namespace TOMSU.Emailova_schranka.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IHomeService _homeService;
        ISecurityService _securityService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService, ISecurityService securityService)
        {
            _logger = logger;
            _homeService = homeService;
            _securityService = securityService;
        }

        public async Task<IActionResult> Index()
        {
            User user = await _securityService.GetCurrentUser(User);
            MessageViewModel viewmodel = _homeService.GetMessageViewModel(user);
            return View(viewmodel);
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