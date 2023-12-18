using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TOMSU.Emailova_schranka.Application.Abstraction;
using TOMSU.Emailova_schranka.Domain.Entities;
using TOMSU.Emailova_schranka.Infrastructure.Database;
using TOMSU.Emailova_schranka.Infrastructure.Identity;

namespace TOMSU.Emailova_schranka.Application.Implementation
{
    public class MessageAdminService : IMessageAdminService
    {
        EmailDbContext _emailDbContext;
        ISecurityService _securityService;
        public MessageAdminService(EmailDbContext emailDbContext, ISecurityService securityService)
        {
            _emailDbContext = emailDbContext;
            _securityService = securityService;
        }

        public IList<Message> Select()
        {
            return _emailDbContext.Messages.ToList();
        }
        public void Create(Message message, User user)
        {
            if(_emailDbContext.Messages != null)
            {
                message.Created_at = Convert.ToString(DateTime.Now);
                message.Status = "Send";
                string prijemce = message.Odesilatel_Adress;
                message.Odesilatel_Adress = user.UserName;
                _emailDbContext.Messages.Add(message);
                Odeslani odeslani = new Odeslani();
                odeslani.Prijemce_Adress = prijemce;
                _emailDbContext.SaveChanges();
                odeslani.Zprava_Id = _emailDbContext.Messages.ToList().Last().Id;
                _emailDbContext.Odeslani.Add(odeslani);
                _emailDbContext.SaveChanges();
            }
        }
		public bool Delete(int id)
		{
            bool deleted = false;
            Message? message = _emailDbContext.Messages.FirstOrDefault(x => x.Id == id);
            Odeslani? odeslani = _emailDbContext.Odeslani.FirstOrDefault(x => x.Zprava_Id == id);
            if(message != null)
            {
                _emailDbContext.Messages.Remove(message);
                _emailDbContext.Odeslani.Remove(odeslani);
                _emailDbContext.SaveChanges();
                deleted = true;
            }
            return deleted;
		}
	}
}
