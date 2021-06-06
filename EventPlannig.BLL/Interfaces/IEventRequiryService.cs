using EventPlannig.DAL.Entities;
using System;

namespace EventPlannig.BLL.Interfaces
{
    public interface IEventRequiryService
    {
        EventRequiry GetBykey(Guid key);
        EventRequiry GetById(int id);
        void Add(EventRequiry eventRequiry);
        void Remove(EventRequiry eventRequiry);
        void ChangeConfirmation(EventRequiry eventRequiry);

    }
}
