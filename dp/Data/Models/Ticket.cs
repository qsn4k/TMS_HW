using System.ComponentModel.DataAnnotations;

namespace dp.Models
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

        // Навигационные свойства
        public Event Event { get; set; }
        public User User { get; set; }
    }

}
