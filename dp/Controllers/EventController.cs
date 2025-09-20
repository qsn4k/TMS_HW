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

    //[HttpGet]
    //public async Task<IActionResult> Index()
    //{
    //    var events = await _eventService.GetAllEventsAsync();
    //    return View(events);
    //}

    [HttpGet]
    public async Task<IActionResult> Index(SortEnum sort = SortEnum.IdAsc)
    {
        var events = await _eventService.GetAllEventsAsync();

        ViewBag.SortTitle = sort == SortEnum.TitleAsc ? SortEnum.TitleDesc : SortEnum.TitleAsc;
        ViewBag.SortDateTime = sort == SortEnum.DateTimeAsc ? SortEnum.DateTimeDesc : SortEnum.DateTimeAsc;
        ViewBag.SortLocation = sort == SortEnum.LocationAsc ? SortEnum.LocationDesc : SortEnum.LocationAsc;
        ViewBag.SortRemaining = sort == SortEnum.RemainingAsc ? SortEnum.RemainingDesc : SortEnum.RemainingAsc;
        ViewBag.SortPrice = sort == SortEnum.PriceAsc ? SortEnum.PriceDesc : SortEnum.PriceAsc;

        var sortEvents = sort switch
        {
            SortEnum.IdDesc => events.OrderByDescending(s => s.Id),
            SortEnum.TitleAsc => events.OrderBy(s => s.Title),
            SortEnum.TitleDesc => events.OrderByDescending(s => s.Title),
            SortEnum.DateTimeAsc => events.OrderBy(s => s.DateTime),
            SortEnum.DateTimeDesc => events.OrderByDescending(s => s.DateTime),
            SortEnum.LocationAsc => events.OrderBy(s => s.Location),
            SortEnum.LocationDesc => events.OrderByDescending(s => s.Location),
            SortEnum.RemainingAsc => events.OrderBy(s => s.RemainingTickets),
            SortEnum.RemainingDesc => events.OrderByDescending(s => s.RemainingTickets),
            SortEnum.PriceAsc => events.OrderBy(s => s.Price),
            SortEnum.PriceDesc => events.OrderByDescending(s => s.Price),
            _ => events.OrderBy(s => s.Id),
        };

        

        return View(sortEvents);
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
