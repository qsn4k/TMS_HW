namespace dp.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public int TicketCount { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}
