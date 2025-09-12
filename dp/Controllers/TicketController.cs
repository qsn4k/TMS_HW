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
}
