using EventPlannig.DAL.Entities;
using System.Collections.Generic;

namespace EventPlannig.BLL.Interfaces
{
    public interface IEventService
    {
        IEnumerable<Event> GetAll();
        Event GetById(int id);
        void Add(Event @event);
        void Remove(Event @event);
    }
}
