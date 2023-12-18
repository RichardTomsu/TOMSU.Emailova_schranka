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
            MessageViewModel viewmodel = new MessageViewModel();
            //viewmodel.Odeslani = _emailDbContext.Odeslani.ToList();
            viewmodel.Messages = _emailDbContext.Messages.ToList();
            if (user != null)
            {
                List<Odeslani> odesList = _emailDbContext.Odeslani.Where(x => x.Prijemce_Adress == user.UserName).ToList();
                List<Message> messages = new List<Message>();
                foreach (var item in odesList)
                {
                    Message mes = _emailDbContext.Messages.FirstOrDefault(x => x.Id == item.Zprava_Id);
                    messages.Add(mes);
                    Console.WriteLine(mes.Id);
                }
                if (messages != null)
                {
                    viewmodel.Messages = messages;
                }
                
            }
            return viewmodel;
        }

    }
}
