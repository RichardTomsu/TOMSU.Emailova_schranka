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
    public class MessageAdminDFService
    {
        public IList<Message> Select()
        {
            return DatabaseFake.Messages;
        }
        public void Create(Message message)
        {
            if(DatabaseFake.Messages != null && DatabaseFake.Messages.Count > 0)
            {
                message.Id = DatabaseFake.Messages.Last().Id + 1;
            }
            else
            {
                message.Id = 1;
            }
            if(DatabaseFake.Messages != null)
            {
                message.Created_at = Convert.ToString(DateTime.Now);
                //message.Status = "Send";
                Console.WriteLine("lol");
                DatabaseFake.Messages.Add(message);
            }
        }
		public bool Delete(int id)
		{
            bool deleted = false;
            Message? message = DatabaseFake.Messages.FirstOrDefault(x => x.Id == id);
            if(message != null)
            {
                deleted = DatabaseFake.Messages.Remove(message);
            }
            return deleted;
		}
	}
}
