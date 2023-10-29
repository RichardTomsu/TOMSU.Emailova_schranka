using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOMSU.Emailova_schranka.Domain.Entities
{
    public class Uzivatel
    {
        public string Email_Adress { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Heslo { get; set; }
        public string Datum_Narozeni { get; set; }
        public string Created_at { get; set; }
    }
}
