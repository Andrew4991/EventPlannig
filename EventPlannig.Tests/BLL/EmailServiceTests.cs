using EventPlannig.BLL.Models;
using EventPlannig.BLL.Services;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Xunit;

namespace EventPlannig.Tests.BLL
{
    [TestClass]
    public class EmailServiceTests
    {
        [Fact]
        public void SendMail_Always_NotThrow()
        {
            // arrange
            var mock = new Mock<IOptions<EmailSettings>>();
            mock.Setup(x =>x.Value).Returns(new EmailSettings 
            {
                Host = "smtp.gmail.com",
                Port = 587,
                From = "eventplanning29@gmail.com",
                Password = "1qa3ed5tg7uj"
            });

            var emailService = new EmailService(mock.Object);

            // act
            Action act = () => emailService.SendMail("eventplanning29@gmail.com", "111", "222");

            // assert
            act.Should().NotThrow();
        }

        [Fact]
        public void SendMail_Always_Throw()
        {
            // arrange
            var mock = new Mock<IOptions<EmailSettings>>();
            mock.Setup(x => x.Value).Returns(new EmailSettings());

            var emailService = new EmailService(mock.Object);

            // act
            Action act = () => emailService.SendMail("eventplanning29@gmail.com", "111", "222");

            // assert
            act.Should().Throw<ArgumentNullException>();
        }
    }
}
