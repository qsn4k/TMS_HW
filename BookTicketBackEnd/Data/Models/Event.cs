using System.ComponentModel.DataAnnotations;

namespace BookTicketBackEnd.Data.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(200)]
        public string Location { get; set; }

        [Range(0, int.MaxValue)]
        public int TotalTickets { get; set; }

        [Range(0, int.MaxValue)]
        public int RemainingTickets { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
