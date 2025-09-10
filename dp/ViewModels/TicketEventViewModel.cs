using dp.Models;

namespace dp.ViewModels
{
    public class TicketEventViewModel
    {
        public Ticket Ticket { get; set; }

        public Event Event { get; set; }

        public TicketEventViewModel(Ticket ticket, Event @event)
        {
            Ticket = ticket;
            Event = @event;
        }
    }
}
