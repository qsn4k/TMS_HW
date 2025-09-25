using BookTicketBackEnd.Data.Models;

namespace BookTicketBackEnd.Service.Interface
{
    public interface ITicketCartService
    {
        public Task<TicketCart> PurchaseCartAsync(List<Ticket> tickets, int userId);

        public Task<List<TicketCart>> GetCartsByUserIdAsync(int userId);

        public Task<TicketCart> GetCartByIdAsync(int id);

        public Task<bool> ConfirmPaymentAsync(int ticketId);
    }
}
