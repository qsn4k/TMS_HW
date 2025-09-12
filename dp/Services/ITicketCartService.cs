using dp.Data.Models;
using dp.Models;

namespace dp.Services
{
    public interface ITicketCartService
    {
        Task<TicketCart> PurchaseCartAsync(List<Ticket> tickets, int userId);

        Task<List<TicketCart>> GetCartsByUserIdAsync(int userId);

        Task<TicketCart> GetCartByIdAsync(int id);

        Task<bool> ConfirmPaymentAsync(int ticketId);
    }
}
