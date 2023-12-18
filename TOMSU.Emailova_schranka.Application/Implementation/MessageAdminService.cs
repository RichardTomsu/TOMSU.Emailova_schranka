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
        public void Create(Message message)
        {
            if(_emailDbContext.Messages != null)
            {
                message.Created_at = Convert.ToString(DateTime.Now);
                message.Status = "Send";
                _emailDbContext.Messages.Add(message);
                _emailDbContext.SaveChanges();
            }
        }
		public bool Delete(int id)
		{
            bool deleted = false;
            Message? message = _emailDbContext.Messages.FirstOrDefault(x => x.Id == id);
            if(message != null)
            {
                _emailDbContext.Messages.Remove(message);
                _emailDbContext.SaveChanges();
                deleted = true;
            }
            return deleted;
		}
	}
}
