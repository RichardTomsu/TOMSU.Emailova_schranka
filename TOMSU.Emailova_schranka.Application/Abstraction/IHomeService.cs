using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOMSU.Emailova_schranka.Application.ViewModels;
using TOMSU.Emailova_schranka.Infrastructure.Identity;

namespace TOMSU.Emailova_schranka.Application.Abstraction
{
    public interface IHomeService
    {
        MessageViewModel GetMessageViewModel(User user);
    }
}
