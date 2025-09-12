using dp.Data;
using dp.Data.Models;
using dp.Models;
using Microsoft.EntityFrameworkCore;

namespace dp.Services
{
    public class TicketCartService : ITicketCartService
    {
        private readonly ApplicationContext _context;

        public TicketCartService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<TicketCart>> GetCartsByUserIdAsync(int userId)
        {
            var carts = await _context.TicketCarts.Where(t => t.UserId == userId).ToListAsync();
            return carts;
        }


        public async Task<TicketCart> GetTicketByIdAsync(int id)
            => await _context.TicketCarts.FindAsync(id);


        public async Task<TicketCart> PurchaseCartAsync(List<Ticket> tickets, int userId)
        {
            var ticketCart = new TicketCart
            {
                Tickets = tickets,
                Quantity = tickets.Count,
                IsPaid = false,
                UserId = userId
            };
            
            _context.TicketCarts.Add(ticketCart);
            await _context.SaveChangesAsync();
            return ticketCart;
        }

        public async Task<bool> ConfirmPaymentAsync(int ticketCartId)
        {
            var ticketCart = await _context.TicketCarts.FindAsync(ticketCartId);
            if (ticketCart == null) return false;

            foreach (var ticket in ticketCart.Tickets)
            {
                ticket.IsPaid = true;
            }

            ticketCart.IsPaid = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<TicketCart> GetCartByIdAsync(int id)
            => await _context.TicketCarts.FindAsync(id);
    }
}

