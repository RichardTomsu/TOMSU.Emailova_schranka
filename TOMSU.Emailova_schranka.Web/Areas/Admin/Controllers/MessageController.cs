using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TOMSU.Emailova_schranka.Application.Abstraction;
using TOMSU.Emailova_schranka.Domain.Entities;
using TOMSU.Emailova_schranka.Infrastructure.Database;
using TOMSU.Emailova_schranka.Infrastructure.Identity;
using TOMSU.Emailova_schranka.Infrastructure.Identity.Enums;
using TOMSU.Emailova_schranka.Web.Controllers;

namespace TOMSU.Emailova_schranka.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = nameof(Roles.Admin))]
    public class MessageController : Controller
    {
        IMessageAdminService _messageAdminService;
        ISecurityService _securityService;
        User user;

        public MessageController(IMessageAdminService messageAdminService, ISecurityService securityService) 
        { 
            _messageAdminService = messageAdminService;
            _securityService = securityService;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                user = await _securityService.GetCurrentUser(User);
                IList<Message> messages = _messageAdminService.Select();
                return View(messages);
            }
            
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Message message, User user)
        {
            user = await _securityService.GetCurrentUser(User);
            _messageAdminService.Create(message, user);
			return RedirectToAction(
					nameof(HomeController.Index),
					nameof(HomeController).Replace(nameof(Controller), String.Empty), new { area = String.Empty });
		}
        public IActionResult Delete(int id)
        {
            bool deleted = _messageAdminService.Delete(id);
            if(deleted)
            {
                return RedirectToAction(
                    nameof(HomeController.Index),
                    nameof(HomeController).Replace(nameof(Controller), String.Empty), new {area = String.Empty});
            }
            else
            {
                return NotFound();
            }
        }
    }
}
