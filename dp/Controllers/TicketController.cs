using dp.Models;
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

    public async Task<IActionResult> MyTickets()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null) return RedirectToAction("Login", "User");

        var tickets = await _ticketService.GetTicketsByUserIdAsync(userId.Value);
        return View(tickets);
    }

    public async Task<IActionResult> Confirm(int id)
    {
        var ticket = await _ticketService.GetTicketByIdAsync(id);
        if (ticket == null)
            return NotFound();

        var ev = await _eventService.GetEventByIdAsync(ticket.EventId);

        var ticketViewModel = new TicketConfirmViewModel
        {
            TicketId = ticket.Id,
            EventTitle = ev.Title,
            EventDateTime = ev.DateTime,
            Location = ev.Location,
            RemainingTickets = ev.RemainingTickets,
            Price = ticket.Price,
            IsPaid = ticket.IsPaid
        };

        return View(ticketViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ConfirmPayment(int ticketId)
    {
        var tickets = await _ticketService.ConfirmPaymentAsync(ticketId);
        
        return RedirectToAction("MyTickets", "Ticket");

    }
}
