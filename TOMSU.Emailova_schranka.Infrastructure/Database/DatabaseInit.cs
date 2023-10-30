using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOMSU.Emailova_schranka.Domain.Entities;

namespace TOMSU.Emailova_schranka.Infrastructure.Database
{
    internal class DatabaseInit
    {
        public IList<Message> GetMessages() 
        { 
            IList<Message> messages = new List<Message>();
            messages.Add(new Message
            {
                Id = 1,
                Text = "Blakijdhalhfssjfah",
                Title = "Title",
                Odesilatel_Adress = "nkannkdk@sjajs",
                Status = "Send",
                Created_at = "29.10.2023 17:27:58"
            });
            messages.Add(new Message
            {
                Id = 2,
                Text = "Blakijdhasadhdjkgadgajgdsgadgjadgjadjglhfssjfah",
                Title = "Titldadsae",
                Odesilatel_Adress = "nkannkdk@sjajs",
                Status = "Send",
                Created_at = "20.10.2023 17:27:58"
            });
            return messages; 
        }
        public IList<User> GetUsers()
        {
            IList<User> users = new List<User>();
            users.Add(new User
            {
                Jmeno = "Blakijdhalhfssjfah",
                Prijmeni = "Title",
                Email_Adress = "nkannkdk@sjajs",
                Heslo = "Sendsada",
                Datum_Narozeni = "29.10.2023",
                Created_at = "29.10.2023 17:27:58"
            });
            users.Add(new User
            {
                Jmeno = "Bhfssjfah",
                Prijmeni = "Tasle",
                Email_Adress = "nnkdk@sjajs",
                Heslo = "Sada",
                Datum_Narozeni = "29.10.2023",
                Created_at = "29.10.2023 17:27:58"
            });
            return users;

        }
        public IList<Odeslani> GetOdeslani()
        {
            IList<Odeslani> list_odeslani = new List<Odeslani>();
            list_odeslani.Add(new Odeslani
            {
                Zprava_Id = 1,
                Prijemce_Adress = "nkannkdk@sjajs"
            });
            return list_odeslani;
        }
        public IList<Spam> GetSpams()
        {
            IList<Spam> spams = new List<Spam>();
            spams.Add(new Spam
            {
                Uzivatel = "Blakijdhalhfssjfah",
                Blokovany_Uzivatel = "Title"
            });
            return spams;
        }
    }
}
