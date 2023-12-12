using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOMSU.Emailova_schranka.Domain.Entities;

namespace TOMSU.Emailova_schranka.Application.ViewModels
{
    public class MessageViewModel
    {
        public IList<Message> Messages { get; set; }
        //public IList<User> Users { get; set; }
        public IList<Odeslani> Odeslani { get; set;}
    }
}
