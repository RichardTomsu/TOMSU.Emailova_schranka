using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TOMSU.Emailova_schranka.Application.Abstraction;
using TOMSU.Emailova_schranka.Domain.Entities;
using TOMSU.Emailova_schranka.Infrastructure.Database;
using TOMSU.Emailova_schranka.Infrastructure.Identity.Enums;
using TOMSU.Emailova_schranka.Web.Controllers;

namespace TOMSU.Emailova_schranka.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = nameof(Roles.Admin))]
    public class MessageController : Controller
    {
        IMessageAdminService _messageAdminService;
        public MessageController(IMessageAdminService messageAdminService) 
        { 
            _messageAdminService = messageAdminService;
        }

        public IActionResult Index()
        {
            IList<Message> messages = _messageAdminService.Select();
            return View(messages);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Message message)
        {
            _messageAdminService.Create(message);
            return RedirectToAction(nameof(HomeController.Index));
        }
        public IActionResult Delete(int id)
        {
            bool deleted = _messageAdminService.Delete(id);
            if(deleted)
            {
                return RedirectToAction(nameof(HomeController.Index));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
