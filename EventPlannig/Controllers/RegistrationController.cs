using EventPlannig.BLL.Interfaces;
using EventPlannig.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EventPlannig.UI.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IEventRequiryService _eventRequiryService;
        private readonly IEmailService _emailService;
        private readonly IEventService _eventService;

        public RegistrationController(IEventRequiryService eventRequiryService,
                                      IEventService eventService,
                                      IEmailService emailService)
        {
            _eventRequiryService = eventRequiryService;
            _emailService = emailService;
            _eventService = eventService;
        }

        public IActionResult Register(int id) => View(new EventRequiry() { EventId = id });

        [HttpPost]
        public IActionResult Register(EventRequiry model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Id = 0;
            model.Key = Guid.NewGuid();
            _eventRequiryService.Add(model);

            //Отправка письма на email
            _emailService.SendMail(model.Email, _eventService.GetById(model.EventId).Title, CreateBodyLetter(model));

            TempData["SM"] = $"Письмо с кодом отправленно на вашу почту.";

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ConfirmByEmail(int id, string name, string key)
        {
            var eventRequiry = _eventRequiryService.GetBykey(Guid.Parse(key));

            if (eventRequiry.Id == id && eventRequiry.Name == name)
            {
                _eventRequiryService.ChangeConfirmation(eventRequiry);

                TempData["SM"] = $"Вы зарегистрировались на событие {_eventService.GetById(eventRequiry.EventId).Name}";
            }
            else
            {
                TempData["SM"] = $"Вы перешли по некорректной ссылке";
            }

            return RedirectToAction("Index", "Home");
        }

        private string CreateBodyLetter(EventRequiry model)
        {
            var url = Url.ActionLink("ConfirmByEmail", "Registration", new { model.Id, model.Name, model.Key });
            return $@"<h2>Перейдите по ссылке для подтверждения регистрации</h2><p>{url}</p>";
        }
    }
}
