using dp.Models;
using dp.Services;
using dp.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using dp.Attributes;

public class EventController : Controller
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    public async Task<IActionResult> Index()
    {
        var events = await _eventService.GetAllEventsAsync();
        return View(events);
    }

    public async Task<IActionResult> Details(int id)
    {
        var ev = await _eventService.GetEventByIdAsync(id);
        if (ev == null) return NotFound();
        return View(ev);
    }

    [HttpGet]
    [AdminOnly]
    public IActionResult Create()
    {
        if (HttpContext.Session.GetString("Role") != "Admin")
            return Unauthorized();

        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    [AdminOnly]
    public async Task<IActionResult> Create(EventCreateViewModel model)
    {
        if (HttpContext.Session.GetString("Role") != "Admin")
            return Unauthorized();

        if (!ModelState.IsValid) return View(model);

        var ev = new Event
        {
            Title = model.Title,
            Description = model.Description,
            DateTime = model.DateTime,
            Location = model.Location,
            TotalTickets = model.TotalTickets,
            RemainingTickets = model.TotalTickets,
            Price = model.Price
        };

        await _eventService.AddEventAsync(ev);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    [AdminOnly]
    public async Task<IActionResult> Edit(int id)
    {
        if (HttpContext.Session.GetString("Role") != "Admin")
            return Unauthorized();

        var ev = await _eventService.GetEventByIdAsync(id);
        if (ev == null) return NotFound();


        var model = new EventEditViewModel
        {
            Title = ev.Title,
            Description = ev.Description,
            DateTime = ev.DateTime,
            Location = ev.Location,
            TotalTickets = ev.TotalTickets,
            RemainingTickets = ev.RemainingTickets,
            Price = ev.Price,
            Id = ev.Id
        };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [AdminOnly]
    public async Task<IActionResult> Edit(EventEditViewModel model)
    {
        if (HttpContext.Session.GetString("Role") != "Admin")
            return Unauthorized();

        if (!ModelState.IsValid) return View(model);

        var ev = await _eventService.GetEventByIdAsync(model.Id);
        if (ev == null) return NotFound();

        ev.Title = model.Title;
        ev.Description = model.Description;
        ev.DateTime = model.DateTime;
        ev.Location = model.Location;
        ev.TotalTickets = model.TotalTickets;
        ev.Price = model.Price;

        await _eventService.UpdateEventAsync(ev);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [AdminOnly]
    public async Task<IActionResult> Delete(int id)
    {
        if (HttpContext.Session.GetString("Role") != "Admin")
            return Unauthorized();

        await _eventService.DeleteEventAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
