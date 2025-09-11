using dp.Services;
using dp.ViewModels;
using Microsoft.AspNetCore.Mvc;

public class TicketController : Controller
{
    private readonly ITicketService _ticketService;
    private readonly IEventService _eventService;

    public TicketController(ITicketService ticketService, IEventService eventService)
    {
        _ticketService = ticketService;
        _eventService = eventService;
    }

    [HttpGet]
    public async Task<IActionResult> Buy(int eventId)
    {
        var ev = await _eventService.GetEventByIdAsync(eventId);
        if (ev == null) return NotFound();

        var model = new TicketPurchaseViewModel
        {
            EventId = eventId,
            Quantity = 1
        };

        ViewData["EventTitle"] = ev.Title;
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Buy(TicketPurchaseViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null) return RedirectToAction("Login", "User");

        var ticket = await _ticketService.PurchaseTicketAsync(model.EventId, userId.Value);
        return RedirectToAction("Confirm", new { ticketId = ticket.Id });
    }

    [HttpGet]
    public async Task<IActionResult> Confirm(int ticketId)
    {
        var ticket = await _ticketService.GetTicketByIdAsync(ticketId);
        if (ticket == null)
            return NotFound();

        var ev = await _eventService.GetEventByIdAsync(ticket.EventId);

        TicketEventViewModel ticketEventViewModel = new TicketEventViewModel(ticket, ev);

        return View(ticketEventViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ConfirmPayment(int ticketId)
    {
        await _ticketService.ConfirmPaymentAsync(ticketId);
        return RedirectToAction("MyTickets");
    }

    public async Task<IActionResult> MyTickets()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null) return RedirectToAction("Login", "User");

        var tickets = await _ticketService.GetTicketsByUserIdAsync(userId.Value);
        return View(tickets);
    }
}
