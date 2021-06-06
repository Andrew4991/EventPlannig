using EventPlannig.BLL.Interfaces;
using EventPlannig.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;


namespace EventPlannig.Controllers
{
    public class AdminController : Controller
    {
        private readonly IEventService _eventService;

        public AdminController(IEventService eventService) => _eventService = eventService;

        public IActionResult Index() => View(_eventService.GetAll());

        public IActionResult Create() => View(new Event() { Date = DateTime.Today });

        [HttpPost]
        public IActionResult Create(Event @event)
        {
            if (@event.Date.Subtract(DateTime.Now).TotalMinutes < 1 )
            {
                ModelState.AddModelError("Date", "Некорректная дата мереприятия");
            }

            if (!ModelState.IsValid)
            {
                return View(@event);
            }

            _eventService.Add(@event);

            TempData["SM"] = $"Добавленно новое событие {@event.Name}!";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var @event = _eventService.GetById(id);
            _eventService.Remove(@event);

            TempData["SM"] = $"Удалено событие {@event.Name}!";
            return RedirectToAction("Index");
        }

        public IActionResult CreateField(int id) => PartialView(id);
    }
}
