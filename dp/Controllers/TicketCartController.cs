using dp.Data.Models;
using dp.Models;
using dp.Services;
using dp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace dp.Controllers
{
    public class TicketCartController : Controller
    {
        readonly IEventService _eventService;
        readonly ITicketService _ticketService;
        readonly ITicketCartService _ticketCartService;

        public TicketCartController(IEventService eventService, ITicketService ticketService, ITicketCartService ticketCartService)
        {
            _eventService = eventService;
            _ticketService = ticketService;
            _ticketCartService = ticketCartService;
        }

        [HttpGet]
        public async Task<IActionResult> Buy(int eventId)
        {
            var ev = await _eventService.GetEventByIdAsync(eventId);
            if (ev == null) return NotFound();


            var model = new TicketPurchaseViewModel
            {
                EventId = eventId,
                RemainingTickets = ev.RemainingTickets,
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

            List<Ticket> tickets = [];

            for(int i = 0; i < model.Quantity; i++)
            {
                var ticket = await _ticketService.PurchaseTicketAsync(model.EventId, userId.Value);
                tickets.Add(ticket);
            }

            var ticketCart = await _ticketCartService.PurchaseCartAsync(tickets, userId.Value);

            return RedirectToAction("Confirm", new { ticketCartId = ticketCart.Id });

        }


        [HttpGet]
        public async Task<IActionResult> Confirm(int ticketCartId)
        {
            var ticketCart = await _ticketCartService.GetCartByIdAsync(ticketCartId);
            if (ticketCart == null)
                return NotFound();

            var ticket = await _ticketService.GetTicketByIdAsync(ticketCart.Tickets[0].Id);
            var ev = await _eventService.GetEventByIdAsync(ticket.EventId);


            var ticketCartViewModel = new TicketCartViewModel
            {
                EventTitle = ev.Title,
                EventDateTime = ev.DateTime,
                Location = ev.Location,
                Quantity = ticketCart.Quantity,
                TotalPrice = ticketCart.Quantity * ticket.Price,
                CartId = ticketCart.Id
            };


            return View(ticketCartViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmPayment(int ticketCartId)
        {
            await _ticketCartService.ConfirmPaymentAsync(ticketCartId);
            var ticketCart = await _ticketCartService.GetCartByIdAsync(ticketCartId);
            var tickets = ticketCart.Tickets;
            if(tickets != null) 
            {
                foreach (var t in tickets)
                {
                    await _ticketService.ConfirmPaymentAsync(t.Id);
                }
            } else Console.WriteLine("ErrorNULL");

                return RedirectToAction("MyTickets", "Ticket");
        
        }
    }
}
