using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOMSU.Emailova_schranka.Domain.Entities
{
    public class Message : Entity<int>
    {
        public string Text { get; set; }
        public string Title { get; set; }
        //[ForeignKey(nameof(Message))]
        public string Odesilatel_Adress { get; set; }
        public string Created_at { get; set; }

    }
}
