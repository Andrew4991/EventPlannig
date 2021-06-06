using EventPlannig.BLL.Services;
using EventPlannig.DAL.Entities;
using EventPlannig.DAL.Interfaces;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace EventPlannig.Tests.BLL
{
    public class EventServiceTests
    {
        
        [Fact]
        public void Add_Always_Successfully()
        {
            // arrange
            var _event = new Event { Id = 1 };
            var mock = new Mock<IRepository<Event>>();

            var eventService = new EventService(mock.Object);

            // act
            eventService.Add(_event);

            // assert
            mock.Verify(x => x.Add(_event));
        }

        [Fact]
        public void Remove_Always_Successfully()
        {
            // arrange
            var _event = new Event { Id = 1 };
            var mock = new Mock<IRepository<Event>>();

            var eventService = new EventService(mock.Object);

            // act
            eventService.Remove(_event);

            // assert
            mock.Verify(x => x.Remove(_event));
        }

        [Fact]
        public void GetAll_Always_Successfully()
        {
            // arrange
            var _event1 = new Event { Id = 1 };
            var _event2 = new Event { Id = 1 };
            var mock = new Mock<IRepository<Event>>();
            mock.Setup(x => x.GetAll()).Returns(new List<Event> { _event1, _event2 });
            var eventService = new EventService(mock.Object);

            // act
            var events = eventService.GetAll();

            // assert
            events.Should().BeEquivalentTo(new List<Event> { _event1, _event2 });
        }

    }
}
