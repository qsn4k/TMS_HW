using dp.Models;

namespace dp.Data.Models
{
    public class TicketCart
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int Quantity { get; set; }

        public List<Ticket> Tickets { get; set; }

        public decimal TotalPrice { get; set; }

        public bool IsPaid { get; set; }
    }
}
