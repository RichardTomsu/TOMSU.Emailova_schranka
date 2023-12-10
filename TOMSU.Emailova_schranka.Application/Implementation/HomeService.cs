﻿using System;
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
    public class HomeService : IHomeService
    {
        EmailDbContext _emailDbContext;
        public HomeService(EmailDbContext emailDbContext)
        {
            _emailDbContext = emailDbContext;
        }
        public MessageViewModel GetMessageViewModel()
        {
            MessageViewModel viewmodel = new MessageViewModel();
            viewmodel.Messages = _emailDbContext.Messages.ToList();
            //viewmodel.Users = _emailDbContext.
            viewmodel.Odeslani = _emailDbContext.Odeslani.ToList();
            return viewmodel;
        }
    }
}
