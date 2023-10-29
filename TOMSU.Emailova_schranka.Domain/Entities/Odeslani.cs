using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOMSU.Emailova_schranka.Domain.Entities
{
    public class Odeslani
    {
        public int Zprava_Id { get; set; }
        public string Prijemce_Adress { get; set; }
    }
}
