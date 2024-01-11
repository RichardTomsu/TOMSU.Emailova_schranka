using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOMSU.Emailova_schranka.Application.Abstraction;
using TOMSU.Emailova_schranka.Application.ViewModels;
using TOMSU.Emailova_schranka.Domain.Entities;
using TOMSU.Emailova_schranka.Infrastructure.Database;
using TOMSU.Emailova_schranka.Infrastructure.Identity;

namespace TOMSU.Emailova_schranka.Application.Implementation
{
    public class HomeService : IHomeService
    {
        EmailDbContext _emailDbContext;
        ISecurityService _securityService;

        public HomeService(EmailDbContext emailDbContext, ISecurityService securityService)
        {
            _emailDbContext = emailDbContext;
            _securityService = securityService;
        }
        public MessageViewModel GetMessageViewModel(User user)
        {
			Console.WriteLine("lol");
            MessageViewModel viewmodel = new MessageViewModel();
            //viewmodel.Odeslani = _emailDbContext.Odeslani.ToList();
            viewmodel.Messages = _emailDbContext.Messages.ToList();
			List<Odeslani> odesList = _emailDbContext.Odeslani.Where(x => x.Prijemce_Adress == user.UserName).ToList();
			List<Message> messages = new List<Message>();
			List<Message> smessages = new List<Message>();
			List<Message> dmessages = new List<Message>();
			List<Message> send_mess = _emailDbContext.Messages.
				Where(x => x.Odesilatel_Adress == user.UserName).OrderByDescending(x => x.Created_at).ToList();
			foreach (var item in odesList)
			{
				Message? mes = _emailDbContext.Messages.FirstOrDefault(
					x => x.Id == item.Zprava_Id);
				if(item.Status == "Spam")
				{
					smessages.Add(mes);
				}
				else if (item.Status == "Delete")
				{
					dmessages.Add(mes);
				}
				else
				{
					messages.Add(mes);
				}
			}
			if (messages != null)
			{
				viewmodel.Messages = messages.OrderByDescending(x => x.Created_at).ToList();
			}
			if (send_mess != null)
			{
				viewmodel.Send_Messages = send_mess;
			}
			if (smessages != null)
			{
				viewmodel.Spam_Messages = smessages.OrderByDescending(x => x.Created_at).ToList();
			}
			if (dmessages != null)
			{
				viewmodel.Delete_Messages = dmessages.OrderByDescending(x => x.Created_at).ToList();
			}
			return viewmodel;
        }

    }
}
