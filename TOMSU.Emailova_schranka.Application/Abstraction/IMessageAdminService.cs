﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOMSU.Emailova_schranka.Domain.Entities;
using TOMSU.Emailova_schranka.Infrastructure.Identity;

namespace TOMSU.Emailova_schranka.Application.Abstraction
{
    public interface IMessageAdminService
    {
        IList<Message> Select();
        void Create(Message message);
        bool Delete(int id);
        IList<string> GetUsersAdresses();
        bool SendToBin(int id, string name);
		void SendToSpam(int id, string name);
        bool Remove(string name, int id);
	}
}
