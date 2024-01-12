using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TOMSU.Emailova_schranka.Application.Abstraction;
using TOMSU.Emailova_schranka.Application.Implementation;
using TOMSU.Emailova_schranka.Application.ViewModels;
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

        //[HttpGet]
        public IActionResult Create(MessageViewModel viewModel)
        {
            viewModel.UsersAdr = _messageAdminService.GetUsersAdresses();
            return View(viewModel);
        }

        //[HttpPost]
        public IActionResult Create2(MessageViewModel viewModel)
        {
            _messageAdminService.Create(viewModel.message);
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
        public async Task<IActionResult> ChangeStatus(int id)
        {
			user = await _securityService.GetCurrentUser(User);
            bool changed = _messageAdminService.SendToBin(id, user.UserName);
            //bool changed = _messageAdminService.Delete(id);
			if (changed)
			{
				return RedirectToAction(
					nameof(HomeController.Index),
					nameof(HomeController).Replace(nameof(Controller), String.Empty), new { area = String.Empty });
			}
			else
			{
				return NotFound();
			}
		}
		public async Task<IActionResult> ChangeToSpam(int id)
		{

			user = await _securityService.GetCurrentUser(User);
			_messageAdminService.SendToSpam(id, user.UserName);
			return RedirectToAction(
					nameof(HomeController.Index),
					nameof(HomeController).Replace(nameof(Controller), String.Empty), new { area = String.Empty });
		}
        public async Task<IActionResult> Remove(int id)
        {
			user = await _securityService.GetCurrentUser(User);
			bool deleted = _messageAdminService.Remove(user.UserName, id);
			if (deleted)
			{
				return RedirectToAction(
					nameof(HomeController.Index),
					nameof(HomeController).Replace(nameof(Controller), String.Empty), new { area = String.Empty });
			}
			else
			{
				return NotFound();
			}
		}
	}
}
