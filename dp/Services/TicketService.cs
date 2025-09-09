using dp.Data;
using dp.Models;
using Microsoft.EntityFrameworkCore;

namespace dp.Services
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationContext _context;

        public TicketService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Ticket>> GetTicketsByUserIdAsync(int userId)
            => await _context.Tickets.Where(t => t.UserId == userId).ToListAsync();

        public async Task<Ticket> GetTicketByIdAsync(int id)
            => await _context.Tickets.FindAsync(id);

        public async Task<Ticket> PurchaseTicketAsync(int eventId, int userId)
        {
            var ticket = new Ticket
            {
                EventId = eventId,
                UserId = userId,
                PurchaseDate = DateTime.Now,
                IsPaid = false
            };
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task<bool> ConfirmPaymentAsync(int ticketId)
        {
            var ticket = await _context.Tickets.FindAsync(ticketId);
            if (ticket == null) return false;

            ticket.IsPaid = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
