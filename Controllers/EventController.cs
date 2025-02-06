using EventEase.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.Controllers
{
    public class EventController : Controller
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult Index(int id)
        {
            var eventModel = _eventService.GetEventById(id);
            return View(eventModel);
        }
    }
}