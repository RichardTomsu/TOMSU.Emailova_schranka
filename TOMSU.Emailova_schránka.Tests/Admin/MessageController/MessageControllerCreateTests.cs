using System;
using System.Diagnostics;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Moq;
using TOMSU.Emailova_schranka.Application.Abstraction;
using TOMSU.Emailova_schranka.Application.ViewModels;
using TOMSU.Emailova_schranka.Domain.Entities;
using TOMSU.Emailova_schranka.Infrastructure.Database;
using TOMSU.Emailova_schranka.Infrastructure.Identity;
using TOMSU.Emailova_schranka.Web.Areas.Admin.Controllers;

namespace TOMSU.Emailova_schránka.Tests.Admin.MessageController
{
    public class MessageControllerCreateTests
    {

        [Fact]
        public void Create_success()
        {
            var user = GetUser();
            DatabaseFake.Messages.Clear();
            Mock<IMessageAdminService> mock = new Mock<IMessageAdminService>();
            mock.Setup(messageService => messageService.Create(It.IsAny<Message>()))
                .Callback<Message>(message => DatabaseFake.Messages.Add(message));

            var message = GetMessage();


            var viewmes = GetMessageView();

            //var messageController = new Web.Areas.Admin.Controllers.MessageController(mock.Object);

            /*var actionResult = messageController.Create(viewmes);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(actionResult);
            Assert.NotNull(redirectToActionResult.ActionName);
            Assert.Equal(nameof(Emailova_schranka.Web.Areas.Admin.Controllers.MessageController.Index), redirectToActionResult.ActionName); ;
            
            Assert.NotEmpty(DatabaseFake.Messages);
            Assert.Single(DatabaseFake.Messages);*/
        }

        MessageViewModel GetMessageView()
        {
            return new MessageViewModel
            {
                message = GetMessage()
            };
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
            return new User { 
                UserName = "Test"
            };
        }
    }
}
