using EventPlannig.BLL.Services;
using EventPlannig.DAL.Entities;
using EventPlannig.DAL.Interfaces;
using FluentAssertions;
using Moq;
using Xunit;
namespace EventPlannig.Tests.BLL
{
    public class EventRequiryServiceTests
    {
        [Fact]
        public void GetById_For1_Successfully()
        {
            // arrange
            var mock = new Mock<IRepository<EventRequiry>>();
            mock.Setup(x => x.GetById(1)).Returns(new EventRequiry { Id = 1 });

            var eventRequiryService = new EventRequiryService(mock.Object);

            // act
            var eventRequiry = eventRequiryService.GetById(1);

            // assert
            eventRequiry.Id.Should().Be(1);
        }

      
    }
}
