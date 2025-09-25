using System.ComponentModel.DataAnnotations;

namespace BookTicketBackEnd.Data.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        public int TicketId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        [Required]
        public PaymentStatus Status { get; set; }

        public Ticket Ticket { get; set; }
    }

    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed
    }
}
