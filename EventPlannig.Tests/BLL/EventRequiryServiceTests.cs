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

        [Fact]
        public void Add_Always_Successfully()
        {
            // arrange
            var eventRequiry = new EventRequiry { Id = 1 };
            var mock = new Mock<IRepository<EventRequiry>>();

            var eventRequiryService = new EventRequiryService(mock.Object);

            // act
            eventRequiryService.Add(eventRequiry);

            // assert
            mock.Verify(x => x.Add(eventRequiry));
        }

        [Fact]
        public void Remove_Always_Successfully()
        {
            // arrange
            var eventRequiry = new EventRequiry { Id = 1 };
            var mock = new Mock<IRepository<EventRequiry>>();

            var eventRequiryService = new EventRequiryService(mock.Object);

            // act
            eventRequiryService.Remove(eventRequiry);

            // assert
            mock.Verify(x => x.Remove(eventRequiry));
        }

        [Fact]
        public void ChangeConfirmation_Always_Successfully()
        {
            // arrange
            var eventRequiry = new EventRequiry { Id = 1 };
            var mock = new Mock<IRepository<EventRequiry>>();

            var eventRequiryService = new EventRequiryService(mock.Object);

            // act
            eventRequiryService.ChangeConfirmation(eventRequiry);

            // assert
            mock.Verify(x => x.Remove(eventRequiry));
            eventRequiry.IsApproved = true;
            eventRequiry.Id = 0;
            mock.Verify(x => x.Add(eventRequiry));
        }

    }
}
