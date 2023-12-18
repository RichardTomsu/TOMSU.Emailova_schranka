using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOMSU.Emailova_schranka.Application.Abstraction;
using TOMSU.Emailova_schranka.Application.ViewModels;
using TOMSU.Emailova_schranka.Domain.Entities;
using TOMSU.Emailova_schranka.Infrastructure.Database;

namespace TOMSU.Emailova_schranka.Application.Implementation
{
    public class HomeDFService
    {
        public MessageViewModel GetMessageViewModel()
        {
            MessageViewModel viewmodel = new MessageViewModel();
            viewmodel.Messages = DatabaseFake.Messages;
            //viewmodel.Users = DatabaseFake.Users;
            viewmodel.Odeslani = DatabaseFake.Seznam_odeslani;
            return viewmodel;
        }
    }
}
