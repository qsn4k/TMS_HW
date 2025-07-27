namespace dp.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public int UserId { get; set; }

        public string Status { get; set; }

        public int Row { get; set; }

        public int Place { get; set; }

        public bool PaymentStatus { get; set; }

    }
}
