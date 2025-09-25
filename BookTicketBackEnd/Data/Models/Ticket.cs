using System.ComponentModel.DataAnnotations;

namespace BookTicketBackEnd.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        public int UserId { get; set; }

        public DateTime PurchaseDate { get; set; }

        public bool IsPaid { get; set; }

        public decimal Price { get; set; }
    }
}
