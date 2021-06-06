using EventPlannig.BLL.Interfaces;
using EventPlannig.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EventPlannig.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventService _eventService;

        public HomeController(IEventService eventService)
        {
            _eventService = eventService;
        }
        public IActionResult Index() => View(_eventService.GetAll());

        public IActionResult Details(int id) => View(_eventService.GetById(id));
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
