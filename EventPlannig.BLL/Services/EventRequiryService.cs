using EventPlannig.BLL.Interfaces;
using EventPlannig.DAL.Entities;
using EventPlannig.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace EventPlannig.BLL.Services
{
    public class EventRequiryService : IEventRequiryService
    {
        private readonly IRepository<EventRequiry> _eventRequiryRepository;

        public EventRequiryService(IRepository<EventRequiry> eventRequiryRepository)
        {
            _eventRequiryRepository = eventRequiryRepository;
        }

        public void Add(EventRequiry eventRequiry)
        {
            _eventRequiryRepository.Add(eventRequiry);
        }

        public void Remove(EventRequiry eventRequiry)
        {
            _eventRequiryRepository.Remove(eventRequiry);
        }

        public EventRequiry GetById(int id)
        {
            return _eventRequiryRepository.GetById(id);
        }

        public EventRequiry GetBykey(Guid key)
        {
            return _eventRequiryRepository.Find(t => t.Key == key).FirstOrDefaultAsync().GetAwaiter().GetResult();
        }

        public void ChangeConfirmation(EventRequiry eventRequiry)
        {
            _eventRequiryRepository.Remove(eventRequiry);

            eventRequiry.IsApproved = true;
            eventRequiry.Id = 0;
            _eventRequiryRepository.Add(eventRequiry);
        }
    }
}
