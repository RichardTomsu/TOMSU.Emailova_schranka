using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOMSU.Emailova_schranka.Domain.Entities;
using TOMSU.Emailova_schranka.Infrastructure.Database;
using TOMSU.Emailova_schranka.Application.Abstraction;
using TOMSU.Emailova_schranka.Application.Implementation;
using Moq;
using Microsoft.AspNetCore.Http;
using System.IO;
using TOMSU.Emailova_schranka.Infrastructure.Identity;

namespace TOMSU.Emailova_schránka.Tests.ApplicationLayer
{
    public class MessageServiceCreateTests
    {
        [Fact]
        public void Create_success()
        {
            DbContextOptions options = new DbContextOptionsBuilder<EmailDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var databaseContext = new EmailDbContext(options);
            databaseContext.Database.EnsureCreated();
            databaseContext.Messages.RemoveRange(databaseContext.Messages);
            databaseContext.SaveChanges();

            MessageAdminService service = new MessageAdminService(databaseContext);

            Message testmes = GetMessage();
            User tuser = GetUser();

            service.Create(testmes);

            Assert.Single(databaseContext.Messages);

            Message addtest = databaseContext.Messages.First();
            Assert.NotNull(addtest.Title);
            Assert.NotNull(addtest.Odesilatel_Adress);
            Assert.Matches(addtest.Odesilatel_Adress, tuser.UserName);


        }

        Message GetMessage()
        {
            return new Message
            {
                Title = "Test",
                Odesilatel_Adress = "test@emailik.cz",
                Text = "Lorem ipsum dolor sit amet, " +
                "consectetuer adipiscing elit. Nam quis nulla. " +
                "Praesent dapibus. Etiam commodo dui eget wisi. " +
                "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
                "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. " +
                "Vestibulum fermentum tortor id mi. Fusce wisi. Sed elit dui, pellentesque a, " +
                "faucibus vel, interdum nec, diam. Aliquam ornare wisi eu metus. " +
                "Fusce consectetuer risus a nunc. Class aptent taciti sociosqu ad litora torquent per conubia nostra, " +
                "per inceptos hymenaeos. Aliquam erat volutpat. Phasellus enim erat, vestibulum vel, aliquam a, " +
                "posuere eu, velit. Cras elementum. Aliquam id dolor. Aenean id metus id velit ullamcorper pulvinar. " +
                "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur " +
                "magni dolores eos qui ratione voluptatem sequi nesciunt. Curabitur vitae diam non enim vestibulum interdum. ",
            };
        }
        User GetUser()
        {
            return new User
            {
                UserName = "Test"
            };
        }
    }
}
