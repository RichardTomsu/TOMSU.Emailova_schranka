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
        public MessageAdminService(EmailDbContext emailDbContext)
        {
            _emailDbContext = emailDbContext;
        }

        public IList<Message> Select()
        {
            return _emailDbContext.Messages.ToList();
        }
        public IList<string> GetUsersAdresses()
        {
            return _emailDbContext.Users.Select(p => p.UserName).ToList();
        }
        public void Create(Message message)
        {
            if (_emailDbContext.Messages != null)
            {
                message.Created_at = Convert.ToString(DateTime.Now);
                IList<string> prijemce = message.Cil_adresa.Split();
                _emailDbContext.Messages.Add(message);
                _emailDbContext.SaveChanges();
                int zprava_Id = _emailDbContext.Messages.ToList().Last().Id;
                foreach (var item in prijemce)
                {
					Odeslani odeslani = new Odeslani();
                    odeslani.Zprava_Id = zprava_Id;
					Spam ? spam = _emailDbContext.Spam.
                        FirstOrDefault(x => x.Uzivatel == item && x.Blokovany_Uzivatel == message.Odesilatel_Adress);
                    if (spam != null)
                    {
						odeslani.Status = "Spam";
					}
                    else
                    {
						odeslani.Status = "Send";
					}
                    odeslani.Prijemce_Adress = item;
					_emailDbContext.Odeslani.Add(odeslani);
				}
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
                while (odeslani != null)
                {
					_emailDbContext.Odeslani.Remove(odeslani);
					odeslani = _emailDbContext.Odeslani.FirstOrDefault(x => x.Zprava_Id == id);
				}
				_emailDbContext.SaveChanges();
                deleted = true;
            }
            return deleted;
		}

        public bool Remove(string name, int id)
        {
            bool removed = false;
			Odeslani? odeslani = _emailDbContext.Odeslani.FirstOrDefault(
                x => x.Zprava_Id == id && x.Prijemce_Adress == name);
			if (odeslani != null)
			{
				_emailDbContext.Odeslani.Remove(odeslani);
				_emailDbContext.SaveChanges();
				removed = true;
			}
			return removed;
        }
        public bool SendToBin(int id, string name)
        {
            bool changed = false;
            Odeslani? odes = _emailDbContext.Odeslani.FirstOrDefault(x => x.Zprava_Id == id && x.Prijemce_Adress == name);
            if (odes != null)
            {
				odes.Status = "Delete";
				_emailDbContext.Odeslani.Update(odes);
				_emailDbContext.SaveChanges();
				changed = true;
			}
			return changed;
        }
        public void SendToSpam(int id, string user)
        {
            Message? mes = _emailDbContext.Messages.FirstOrDefault(x => x.Id == id);
            Spam sp = new Spam();
            sp.Uzivatel = user;
            sp.Blokovany_Uzivatel = mes.Odesilatel_Adress;
            _emailDbContext.Spam.Add(sp);
            Odeslani odes = _emailDbContext.Odeslani.FirstOrDefault(x => x.Zprava_Id == id && x.Prijemce_Adress == user);
            odes.Status ="Spam";
            _emailDbContext.Odeslani.Update(odes);
            _emailDbContext.SaveChanges();
        }
	}
}
