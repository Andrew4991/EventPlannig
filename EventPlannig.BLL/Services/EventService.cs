using EventPlannig.BLL.Interfaces;
using EventPlannig.DAL.Entities;
using EventPlannig.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EventPlannig.BLL.Services
{
    public class EventService  : IEventService
    {
        private readonly IRepository<Event> _eventRepository;

        public EventService(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Event GetById(int id)
        {
            return _eventRepository.Find(t => t.Id == id)
                                         .Include(t => t.CustomFields)
                                         .FirstOrDefault();
        }

        public IEnumerable<Event> GetAll()
        {
            return _eventRepository.GetAll();
        }

        public void Add(Event @event)
        {
            _eventRepository.Add(@event);
        }

        public void Remove(Event @event)
        {
            _eventRepository.Remove(@event);
        }
    }
}
