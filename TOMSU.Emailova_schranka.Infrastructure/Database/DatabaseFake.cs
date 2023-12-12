using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOMSU.Emailova_schranka.Domain.Entities;

namespace TOMSU.Emailova_schranka.Infrastructure.Database
{
    public class DatabaseFake
    {
        public static List<Message> Messages { get; set; }
        public static List<Odeslani> Seznam_odeslani { get; set; }
        public static List<Spam> Spams { get; set; }

        static DatabaseFake()
        {
            DatabaseInit databaseInit = new DatabaseInit();
            Messages = databaseInit.GetMessages().ToList();
            Seznam_odeslani = databaseInit.GetOdeslani().ToList();
            Spams = databaseInit.GetSpams().ToList();

            /*Messages = new List<Message>();
            Messages.Add(new Message
            {
                Id = 1,
                Text = "Blakijdhalhfssjfah",
                Title = "Title",
                Odesilatel_Adress = "nkannkdk@sjajs",
                Status = "Send",
                Created_at = "29.10.2023 17:27:58"
            });
            Messages.Add(new Message
            {
                Id = 2,
                Text = "Blakijdhasadhdjkgadgajgdsgadgjadgjadjglhfssjfah",
                Title = "Titldadsae",
                Odesilatel_Adress = "nkannkdk@sjajs",
                Status = "Send",
                Created_at = "20.10.2023 17:27:58"
            });*/
        }
    }
}
