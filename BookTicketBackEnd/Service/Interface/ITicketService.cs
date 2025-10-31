using BookTicketBackEnd.Data.Models;

namespace BookTicketBackEnd.Service.Interface
{
    public interface ITicketService
    {

        Task<List<Ticket>> GetTicketsByUserIdAsync(int userId);

        Task<Ticket> GetTicketByIdAsync(int id);

        Task<Ticket> PurchaseTicketAsync(int eventId, int userId);

        Task<bool> ConfirmPaymentAsync(int ticketId);
    }
}
